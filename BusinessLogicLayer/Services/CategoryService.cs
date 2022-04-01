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
    public class CategoryService
    {
        private DataAccessLayer.Repositories.CategoryDAL _DAL;
        private Mapper _CategoryMapper;

        public CategoryService()
        {
            _DAL = new DataAccessLayer.Repositories.CategoryDAL();
            var _configInventory = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryModel>().ReverseMap());

            _CategoryMapper = new Mapper(_configInventory);
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            List<Category> categoryFromDb = await _DAL.GetAll();
            List<CategoryModel> categoryModel = _CategoryMapper.Map<List<Category>, List<CategoryModel>>(categoryFromDb);

            return categoryModel;
        }

        public async Task<CategoryModel?> GetCategoryById(int id)
        {
            var data = await _DAL.GetCategoryById(id);
            if (data != null)
            {
                CategoryModel? cM = _CategoryMapper.Map<Category, CategoryModel>(data);
                return cM;
            }
            return null;
        }

        public async Task<bool> PostCategory(CategoryModel categoryModel)
        {
            Category categoryEntity = _CategoryMapper.Map<CategoryModel, Category>(categoryModel);
            if (await _DAL.PostCategory(categoryEntity))
            {
                return true;
            }
            return false;
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel categoryModel)
        {
            Category categoryEntity = _CategoryMapper.Map<CategoryModel, Category>(categoryModel);
            if (categoryEntity != null)
            {
                var data = await _DAL.UpdateCategory(categoryEntity);
                CategoryModel cM = _CategoryMapper.Map<Category, CategoryModel>(data);
                return cM;
            }
            return null;
        }

        public async Task DeleteCategory(CategoryModel categoryModel)
        {
            Category categoryEntity = _CategoryMapper.Map<CategoryModel, Category>(categoryModel);
            await _DAL.DeleteCategory(categoryEntity);
        }
    }
}
