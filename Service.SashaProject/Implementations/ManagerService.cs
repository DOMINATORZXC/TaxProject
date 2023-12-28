using Dal.SashaProject.Interfaces;
using Domain.SashaProject.Entity;
using Domain.SashaProject.Enum;
using Domain.SashaProject.Response;
using Domain.SashaProject.ViewModels;
using Service.SashaProject.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.SashaProject.Implementations
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _mngRep;

        public ManagerService(IManagerRepository mngRep)
        {
            _mngRep = mngRep;
        }
        public async Task<IBaseResponse<ManagerViewModel>> CreateEntity(ManagerViewModel model)
        {
            var baseResponse = new BaseResponse<ManagerViewModel>();
            try
            {
                var mng = new Manager()
                {
                    ManagerId = model.ManagerId, 
                    Name = model.Name,
                    LastName = model.LastName,
                    PhoneManager = model.PhoneManager
                };
                await _mngRep.Create(mng);
            }
            catch (Exception ex)
            {
                return new BaseResponse<ManagerViewModel>()
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
                var mng = await _mngRep.Get(id);
                if (mng == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                await _mngRep.Delete(mng);
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

        public async Task<IBaseResponse<Manager>> Edit(int id, ManagerViewModel Model)
        {
            var baseResponse = new BaseResponse<Manager>();
            try
            {
                var mng = await _mngRep.Get(id);
                if (mng == null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Property not found";
                    return baseResponse;
                }

                mng.ManagerId = Model.ManagerId; 
                mng.Name = Model.Name;
                mng.PhoneManager = Model.PhoneManager;
                mng.LastName = Model.LastName;
               

                await _mngRep.Update(mng);

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Manager>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };

            }
        }

        public async Task<IBaseResponse<ManagerViewModel>> Get(int id)
        {
            var baseResponse = new BaseResponse<ManagerViewModel>();
            try
            {
                var mng = await _mngRep.Get(id);
                if (mng == null)
                {
                    baseResponse.Description = "Manager not found";
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }
                var data = new ManagerViewModel()
                {
                   ManagerId = mng.ManagerId,
                   PhoneManager = mng.PhoneManager,
                   LastName = mng.LastName,
                   Name = mng.Name,
                };
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ManagerViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Manager>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Manager>>();
            try
            {
                var mng = await _mngRep.Select();
                if (mng.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = mng;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Manager>>()
                {
                    Description = $"[GetMng] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
