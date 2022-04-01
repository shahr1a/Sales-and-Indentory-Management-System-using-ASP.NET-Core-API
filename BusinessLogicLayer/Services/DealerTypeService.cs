using AutoMapper;
using BusinessLogicLayer.BusinessEntities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DealerTypeService
    {
        private DataAccessLayer.Repositories.DealerTypeDAL _DAL;
        private Mapper _DealerTypeMapper;

        public DealerTypeService()
        {
            _DAL = new DataAccessLayer.Repositories.DealerTypeDAL();
            var _configInventory = new MapperConfiguration(cfg => cfg.CreateMap<DealerType, DealerTypeModel>().ReverseMap());

            _DealerTypeMapper = new Mapper(_configInventory);
        }

        public async Task<List<DealerTypeModel>> GetAll()
        {
            List<DealerType> dealerTypeFromDb = await _DAL.GetAll();
            List<DealerTypeModel> dealerTypeModel = _DealerTypeMapper.Map<List<DealerType>, List<DealerTypeModel>>(dealerTypeFromDb);

            return dealerTypeModel;
        }

        public async Task<DealerTypeModel?> GetDealerTypeById(int id)
        {
            var data = await _DAL.GetDealerTypeById(id);
            if (data != null)
            {
                DealerTypeModel? dTM = _DealerTypeMapper.Map<DealerType, DealerTypeModel>(data);
                return dTM;
            }
            return null;
        }

        public async Task<bool> PostDealerType(DealerTypeModel dealerTypeModel)
        {
            DealerType dealerTypeEntity = _DealerTypeMapper.Map<DealerTypeModel, DealerType>(dealerTypeModel);
            if (await _DAL.PostDealerType(dealerTypeEntity))
            {
                return true;
            }
            return false;
        }

        public async Task<DealerTypeModel> UpdateDealerType(DealerTypeModel dealerTypeModel)
        {
            DealerType dealerTypeEntity = _DealerTypeMapper.Map<DealerTypeModel, DealerType>(dealerTypeModel);
            if (dealerTypeEntity != null)
            {
                var data = await _DAL.UpdateDealerType(dealerTypeEntity);
                DealerTypeModel dTM = _DealerTypeMapper.Map<DealerType, DealerTypeModel>(data);
                return dTM;
            }
            return null;
        }

        public async Task DeleteDealerType(DealerTypeModel dealerTypeModel)
        {
            DealerType dealerTypeEntity = _DealerTypeMapper.Map<DealerTypeModel, DealerType>(dealerTypeModel);
            await _DAL.DeleteDealerType(dealerTypeEntity);
        }
    }
}
