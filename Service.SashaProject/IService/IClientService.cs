using Domain.SashaProject.Entity;
using Domain.SashaProject.Requests;
using Domain.SashaProject.Response;
using Domain.SashaProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SashaProject.IService
{
    public interface IClientService 
    {
        Task<IBaseResponse<IEnumerable<Client>>> GetAllClients();
        Task<IBaseResponse<ClientViewModel>> Get(int id);
        Task<IBaseResponse<ClientViewModel>> CreateClient(ClientCreateRequest model);
        Task<IBaseResponse<bool>> DeleteClient(int id);
        Task<IBaseResponse<Client>> Edit(int id, ClientViewModel model);
    }
}
