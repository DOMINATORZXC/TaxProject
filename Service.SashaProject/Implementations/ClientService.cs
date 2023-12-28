using Dal.SashaProject.Interfaces;
using Domain.SashaProject.Entity;
using Domain.SashaProject.Enum;
using Domain.SashaProject.Requests;
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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRep;

        public ClientService(IClientRepository clientRep)
        {
            _clientRep = clientRep;
        }
        public async Task<IBaseResponse<ClientViewModel>> CreateClient(ClientCreateRequest model)
        {
            var baseResponse = new BaseResponse<ClientViewModel>();
            try
            {
                var client = new Client()
                {
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Name = model.Name
                };
                await _clientRep.Create(client);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClientViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
                                                                    
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteClient(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var client = await _clientRep.Get(id);
                if (client == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                await _clientRep.Delete(client);
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

        public async Task<IBaseResponse<Client>> Edit(int id, ClientViewModel Model)
        {
            var baseResponse = new BaseResponse<Client>();
            try
            {
                var client = await _clientRep.Get(id);
                if (client == null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Property not found";
                    return baseResponse;
                }

                client.ClientId = Model.ClientId;
                client.Name = Model.Name;
                client.LastName = Model.LastName;
                client.PhoneNumber = Model.PhoneNumber;

                await _clientRep.Update(client);

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Client>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };

            }
        }

        public async Task<IBaseResponse<ClientViewModel>> Get(int id)
        {
            var baseResponse = new BaseResponse<ClientViewModel>();
            try
            {
                var client = await _clientRep.Get(id);
                if (client == null)
                {
                    baseResponse.Description = "Client not found";
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }
                var data = new ClientViewModel()
                {
                    Name = client.Name,
                    LastName = client.LastName,
                    ClientId = client.ClientId,
                    PhoneNumber = client.PhoneNumber
                };
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClientViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Client>>> GetAllClients()
        {
            var baseResponse = new BaseResponse<IEnumerable<Client>>();
            try
            {
                var client = await _clientRep.Select();
                if (client.Count == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    return baseResponse;
                }

                baseResponse.Data = client;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Client>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
