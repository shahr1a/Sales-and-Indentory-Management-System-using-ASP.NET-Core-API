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
    public class SaleService
    {
        private DataAccessLayer.Repositories.SaleDAL _DAL;
        private Mapper _SaleMapper;

        public SaleService()
        {
            _DAL = new DataAccessLayer.Repositories.SaleDAL();
            var _configInventory = new MapperConfiguration(cfg => cfg.CreateMap<Sale, SaleModel>().ReverseMap());

            _SaleMapper = new Mapper(_configInventory);
        }

        public async Task<List<SaleModel>> GetAll()
        {
            List<Sale> saleFromDb = await _DAL.GetAll();
            List<SaleModel> saleModel = _SaleMapper.Map<List<Sale>, List<SaleModel>>(saleFromDb);

            return saleModel;
        }

        public async Task<SaleModel?> GetSaleById(int id)
        {
            var data = await _DAL.GetSaleById(id);
            if (data != null)
            {
                SaleModel? sM = _SaleMapper.Map<Sale, SaleModel>(data);
                return sM;
            }
            return null;
        }

        public async Task<bool> PostSale(SaleModel saleModel)
        {
            Sale saleEntity = _SaleMapper.Map<SaleModel, Sale>(saleModel);
            if (await _DAL.PostSale(saleEntity))
            {
                return true;
            }
            return false;
        }

        public async Task<SaleModel> UpdateSale(SaleModel saleModel)
        {
            Sale saleEntity = _SaleMapper.Map<SaleModel, Sale>(saleModel);
            if (saleEntity != null)
            {
                var data = await _DAL.UpdateSale(saleEntity);
                SaleModel sM = _SaleMapper.Map<Sale, SaleModel>(data);
                return sM;
            }
            return null;
        }

        public async Task DeleteSale(SaleModel saleModel)
        {
            Sale saleEntity = _SaleMapper.Map<SaleModel, Sale>(saleModel);
            await _DAL.DeleteSale(saleEntity);
        }
    }
}
