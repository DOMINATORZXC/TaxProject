using Dal.SashaProject.Interfaces;
using Domain.SashaProject.Entity;
using Domain.SashaProject.Enum;
using Domain.SashaProject.Response;
using Domain.SashaProject.ViewModels;
using Service.SashaProject.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
namespace Service.SashaProject.Implementations
{
    public class AutoService : IAutoService
    {
        private readonly IAutoRepository _autoRep;
        
        public AutoService(IAutoRepository autoRep)
        {
            _autoRep = autoRep;
        }
        public async Task<IBaseResponse<AutoViewModel>> CreateEntity(AutoViewModel model)
        {
            var baseResponse = new BaseResponse<AutoViewModel>();
            try
            {
                var auto = new Auto()
                {
                    AutoId = model.AutoId,
                    Color = (Color)Convert.ToInt32(model.Color),
                    CPP = (CPP)Convert.ToInt32(model.CPP),
                    Name = model.Name,
                    Price = model.Price,
                    YearIssue = model.YearIssue
                };
                await _autoRep.Create(auto);
            }
            catch (Exception ex) 
            {
                return new BaseResponse<AutoViewModel>()
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
                var auto = await _autoRep.Get(id);
                if (auto == null) 
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                await _autoRep.Delete(auto);
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
            
        }

        public async Task<IBaseResponse<Auto>> Edit(int id, AutoViewModel Model)
        {
            var baseResponse = new BaseResponse<Auto>();
            try
            {
                var auto = await _autoRep.Get(id);
                if (auto == null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Property not found";
                    return baseResponse;
                }

                auto.AutoId = Model.AutoId;
                auto.Name = Model.Name;
                auto.Price = Model.Price;
                auto.CPP = (CPP)Convert.ToInt32(Model.CPP);
                auto.Color = (Color)Convert.ToInt32(Model.Color);

                await _autoRep.Update(auto);

                return baseResponse;

            }
            catch (Exception ex) 
            {
                return new BaseResponse<Auto>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };

            }
        }

        public async Task<IBaseResponse<AutoViewModel>> Get(int id)
        {
            var baseResponse = new BaseResponse<AutoViewModel>();
            try
            {
                var auto = await _autoRep.Get(id);
                if (auto == null)
                {
                    baseResponse.Description = "Auto not found";
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }
                var data = new AutoViewModel()
                {
                    Name = auto.Name,
                    Price = auto.Price,
                    Color = auto.Color.ToString(),
                    AutoId = auto.AutoId,
                    CPP = auto.CPP.ToString(),
                    YearIssue = auto.YearIssue,
                };
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<AutoViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Auto>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Auto>>();
            try
            {
                var auto = await _autoRep.Select();
                if (auto.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = auto;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Auto>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
