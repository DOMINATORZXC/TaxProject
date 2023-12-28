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
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driveRep;

        public DriverService(IDriverRepository driveRep)
        {
            _driveRep = driveRep;
        }
        public async Task<IBaseResponse<DriverViewModel>> CreateEntity(DriverViewModel model)
        {
            var baseResponse = new BaseResponse<DriverViewModel>();
            try
            {
                var driver = new Driver()
                {
                    DriverId = model.DriverId,
                    LastName = model.LastName,
                    auto = model.auto
                };
                await _driveRep.Create(driver);
            }
            catch (Exception ex)
            {
                return new BaseResponse<DriverViewModel>()
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
                var driver = await _driveRep.Get(id);
                if (driver == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                await _driveRep.Delete(driver);
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

        public async Task<IBaseResponse<Driver>> Edit(int id, DriverViewModel Model)
        {
            var baseResponse = new BaseResponse<Driver>();
            try
            {
                var driver = await _driveRep.Get(id);
                if (driver == null)
                {
                    baseResponse.StatusCode = StatusCode.CarNotFound;
                    baseResponse.Description = "Property not found";
                    return baseResponse;
                }

                driver.DriverId = Model.DriverId;
                driver.Name = Model.Name;
                driver.auto = driver.auto;

                await _driveRep.Update(driver);

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Driver>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };

            }
        }

        public async Task<IBaseResponse<DriverViewModel>> Get(int id)
        {
            var baseResponse = new BaseResponse<DriverViewModel>();
            try
            {
                var driver = await _driveRep.Get(id);
                if (driver == null)
                {
                    baseResponse.Description = "Client not found";
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }
                var data = new DriverViewModel()
                {
                   DriverId = driver.DriverId,
                   Name = driver.Name,
                   LastName = driver.LastName,
                   auto = driver.auto
                };
                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<DriverViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Driver>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Driver>>();
            try
            {
                var driver = await _driveRep.Select();
                if (driver.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = driver;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Driver>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
