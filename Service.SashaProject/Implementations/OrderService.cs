using Dal.SashaProject.Interfaces;
using Domain.SashaProject.Entity;
using Domain.SashaProject.Enum;
using Domain.SashaProject.Response;
using Domain.SashaProject.ViewModels;
using Service.SashaProject.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SashaProject.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _ordRep;

        public OrderService(IOrderRepository ordRep)
        {
            _ordRep = ordRep;
        }
        public async Task<IBaseResponse<OrderViewModel>> CreateEntity(OrderViewModel model)
        {
            var baseResponse = new BaseResponse<OrderViewModel>();
            try
            {
                var order = new Order()
                {
                    OrderId = model.OrderId,
                    OrderDate = model.OrderDate,
                    Address = model.Address,
                    auto = model.auto,
                    Price = model.Price,
                };
                await _ordRep.Create(order);
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }

            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteEntity(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var order = await _ordRep.Get(id);
                if (order == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                await _ordRep.Delete(order);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<Order>> Edit(int id, OrderViewModel Model)
        {
            var baseResponse = new BaseResponse<Order>();
            try
            {
                var order = await _ordRep.Get(id);
                if (order == null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Property not found";
                    return baseResponse;
                }

                order.OrderId = Model.OrderId;
                order.Address = Model.Address;
                order.OrderDate = Model.OrderDate;
                order.auto = Model.auto;
                order.Price = Model.Price;

                await _ordRep.Update(order);

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };

            }
        }

        public async Task<IBaseResponse<OrderViewModel>> Get(int id)
        {
            var baseResponse = new BaseResponse<OrderViewModel>();
            try
            {
                var order = await _ordRep.Get(id);
                if (order == null)
                {
                    baseResponse.Description = "Order not found";
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }
                var data = new OrderViewModel()
                {
                    OrderDate = DateTime.Now,
                    OrderId = order.OrderId,
                    Address = order.Address,
                    auto = order.auto,
                    Price = order.Price,
                };
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Order>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Order>>();
            try
            {
                var order = await _ordRep.Select();
                if (order.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = order;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Order>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
