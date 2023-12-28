using Domain.SashaProject.Entity;
using Domain.SashaProject.Response;
using Domain.SashaProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SashaProject.IService
{
    public interface IOrderService
    {
        Task<IBaseResponse<IEnumerable<Order>>> GetAll();
        Task<IBaseResponse<OrderViewModel>> Get(int id);
        Task<IBaseResponse<OrderViewModel>> CreateEntity(OrderViewModel model);
        Task<IBaseResponse<bool>> DeleteEntity(int id);
        Task<IBaseResponse<Order>> Edit(int id, OrderViewModel model);
    }
}
