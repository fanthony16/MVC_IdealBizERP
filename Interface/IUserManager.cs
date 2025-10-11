using IdealBizUI.Data;
using IdealBizUI.ViewModels;
using System.Threading.Tasks;

namespace IdealBizUI.InterfaceServices
{
    public interface IUserManager
    {
        public Task<bool> CreateUser(RegisterViewModel model);

        public Task<bool> LoginUser(LoginViewModel model);
        public void SetDbContext(IdealBizContext Db);

    }
   
}