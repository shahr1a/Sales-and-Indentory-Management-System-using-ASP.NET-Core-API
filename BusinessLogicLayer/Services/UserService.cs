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
    public class UserService
    {
        //private DataAccessLayer.Repositories.UserDAL _DAL;
        //private Mapper _UserMapper;
        //public UserService()
        //{
        //    _DAL = new DataAccessLayer.Repositories.UserDAL();
        //    var _configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>().ReverseMap());
        //    _UserMapper = new Mapper(_configUser);
        //}

        //public async Task<UserModel?> VerifyUser(UserModel userModel)
        //{
        //    var user = await _DAL.VerifyUser(userModel.UserName, userModel.Password);
        //    if (user != null)
        //    {
        //        return _UserMapper.Map<User, UserModel>(user);
        //    }
        //    return null;
        //}
    }
}
