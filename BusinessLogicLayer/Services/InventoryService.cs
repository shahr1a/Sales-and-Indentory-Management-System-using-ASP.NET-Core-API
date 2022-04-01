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
    public class InventoryService
    {
        private DataAccessLayer.Repositories.InventoryDAL _DAL;
        private Mapper _InventoryMapper;
        private Mapper _InventoryPostMapper;

        public InventoryService()
        {
            _DAL = new DataAccessLayer.Repositories.InventoryDAL();
            var _configInventory = new MapperConfiguration(cfg => cfg.CreateMap<Inventory, InventoryModel>().ReverseMap());
            var _configInventoryPost = new MapperConfiguration(cfg => cfg.CreateMap<Inventory, InventoryPostModel>().ReverseMap());

            _InventoryMapper = new Mapper(_configInventory);
            _InventoryPostMapper = new Mapper(_configInventoryPost);
        }

        public async Task<List<InventoryModel>> GetAll()
        {
            List<Inventory> inventoryFromDb = await _DAL.GetAll();
            List<InventoryModel> inventoryModel = _InventoryMapper.Map<List<Inventory>, List<InventoryModel>>(inventoryFromDb);

            return inventoryModel;
        }

        public async Task<InventoryModel?> GetProductById(int id)
        {
            var data = await _DAL.GetProductById(id);
            if(data != null)
            {
                InventoryModel? iM = _InventoryMapper.Map<Inventory, InventoryModel>(data);
                return iM;
            } return null;
        }

        public async Task<bool> PostProduct(InventoryPostModel inventoryPostModel)
        {
            Inventory productEntity = _InventoryPostMapper.Map<InventoryPostModel, Inventory>(inventoryPostModel);
            if (await _DAL.PostProduct(productEntity))
            {
                return true;
            }
            return false;
        }

        public async Task<InventoryModel> UpdateProduct(InventoryPostModel inventoryPostModel)
        {
            Inventory productEntity = _InventoryPostMapper.Map<InventoryPostModel, Inventory>(inventoryPostModel);
            if (productEntity != null)
            {
                var data = await _DAL.UpdateProduct(productEntity);
                InventoryModel iM = _InventoryMapper.Map<Inventory, InventoryModel>(data);
                return iM;
            }
            return null;
        }

        public async Task DeleteProduct(InventoryModel inventoryModel)
        {
            Inventory productEntity = _InventoryMapper.Map<InventoryModel, Inventory>(inventoryModel);
            await _DAL.DeleteProduct(productEntity);
        }
    }
}
