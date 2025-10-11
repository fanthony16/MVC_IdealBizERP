using IdealBizUI.Data;
using IdealBizUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealBizUI.InterfaceServices
{
    public class UserManager : IUserManager
    {

        
        private IdealBizContext DbContect;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetDbContext(IdealBizContext Db) 
        {
            DbContect = Db;
        }
        public async Task<bool> CreateUser(RegisterViewModel model)
        {

            //var str =_httpContextAccessor.HttpContext.Session.GetString("");

            TblUser nUser = new TblUser();
            nUser.TxtFullName = model.Name;
            nUser.TxtUserName = model.Name;
            nUser.TxtPassword = model.Password;
            nUser.TxtEmail = model.Email;
            //nUser.IntGender = model.Gender;
            nUser.IntGender = 0;

            DbContect.Add(nUser);
            var result = await DbContect.SaveChangesAsync();
            return (result == 1) ? true : false;
            

        }

        //Authenticating Login User
        public async Task<bool> LoginUser(LoginViewModel model)
        {

           
            
            //get a sinlge value
            //var nn = DbContect.TblUsers.Single(b => b.TxtUserName == model.UserName && b.TxtPassword == model.Password);
            //find a single value with primary key
            //var nnn = DbContect.TblUsers.Find(1);

            var nnn = await DbContect.TblUsers.FirstOrDefaultAsync(b => b.TxtUserName == model.UserName && b.TxtPassword == model.Password);
            
            if (nnn is not null) {
                return true;
            }
            else
            {
                return false;
            }

            
            



        }
    }
}
