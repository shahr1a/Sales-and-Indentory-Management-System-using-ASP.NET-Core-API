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
    public class DealerService
    {
        private DataAccessLayer.Repositories.DealerDAL _DAL;
        private Mapper _DealerMapper;
        private Mapper _DealerCreateMapper;

        public DealerService()
        {
            _DAL = new DataAccessLayer.Repositories.DealerDAL();
            var _configDealer = new MapperConfiguration(cfg => cfg.CreateMap<Dealer, DealerModel>().ReverseMap());
            var _cD = new MapperConfiguration(cfg => cfg.CreateMap<Dealer, DealerSelfCreateModel>().ReverseMap());

            _DealerMapper = new Mapper(_configDealer);
            _DealerCreateMapper = new Mapper(_cD);
        }

        public async Task<List<DealerModel>> GetAll()
        {
            List<Dealer> dealerFromDb = await _DAL.GetAll();
            List<DealerModel> dealerModel = _DealerMapper.Map<List<Dealer>, List<DealerModel>>(dealerFromDb);

            return dealerModel;
        }

        public async Task<DealerModel?> GetDealerById(int id)
        {
            var data = await _DAL.GetDealerById(id);
            if (data != null)
            {
                DealerModel? dM = _DealerMapper.Map<Dealer, DealerModel>(data);
                return dM;
            }
            return null;
        }

        public async Task<bool> PostDealer(DealerModel dealerModel)
        {
            Dealer dealerEntity = _DealerMapper.Map<DealerModel, Dealer>(dealerModel);
            if (await _DAL.PostDealer(dealerEntity))
            {
                return true;
            }
            return false;
        }

        public async Task<DealerModel> UpdateDealer(DealerModel dealerModel)
        {
            Dealer dealerEntity = _DealerMapper.Map<DealerModel, Dealer>(dealerModel);
            if (dealerEntity != null)
            {
                var data = await _DAL.UpdateDealer(dealerEntity) ;
                DealerModel dM = _DealerMapper.Map<Dealer, DealerModel>(data);
                return dM;
            }
            return null;
        }

        public async Task DeleteDealer(DealerModel dealerModel)
        {
            Dealer dealerEntity = _DealerMapper.Map<DealerModel, Dealer>(dealerModel);
            await _DAL.DeleteDealer(dealerEntity);
        }

        public async Task<bool> CreateDealerAccount(DealerSelfCreateModel dealerSelfCreate)
        {
            Dealer dealerEntity = _DealerCreateMapper.Map<DealerSelfCreateModel, Dealer>(dealerSelfCreate);
            if (await _DAL.CreateDealerAccount(dealerEntity))
            {
                return true;
            }return false;
        }
    }
}
