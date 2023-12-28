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
    public interface IDriverService 
    {
        Task<IBaseResponse<IEnumerable<Driver>>> GetAll();
        Task<IBaseResponse<DriverViewModel>> Get(int id);
        Task<IBaseResponse<DriverViewModel>> CreateEntity(DriverViewModel model);
        Task<IBaseResponse<bool>> DeleteEntity(int id);
        Task<IBaseResponse<Driver>> Edit(int id, DriverViewModel model);
    }
}
