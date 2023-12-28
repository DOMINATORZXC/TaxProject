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
    public interface IManagerService
    {
        Task<IBaseResponse<IEnumerable<Manager>>> GetAll();
        Task<IBaseResponse<ManagerViewModel>> Get(int id);
        Task<IBaseResponse<ManagerViewModel>> CreateEntity(ManagerViewModel model);
        Task<IBaseResponse<bool>> DeleteEntity(int id);
        Task<IBaseResponse<Manager>> Edit(int id, ManagerViewModel model);
    }
}
