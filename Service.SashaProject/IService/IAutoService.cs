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
    public interface IAutoService
    {
        Task<IBaseResponse<IEnumerable<Auto>>> GetAll();
        Task<IBaseResponse<AutoViewModel>> Get(int id);
        Task<IBaseResponse<AutoViewModel>> CreateEntity(AutoViewModel model);
        Task<IBaseResponse<bool>> DeleteEntity(int id);
        Task<IBaseResponse<Auto>> Edit(int id, AutoViewModel model);
    }
}
