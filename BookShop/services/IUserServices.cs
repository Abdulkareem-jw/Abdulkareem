using BookShop.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.services
{
    public interface IUserServices
    {
        List<ApplicationUser> SellectAll();
         Task<IdentityResult> SignUp(ForUser u);
        Task<IdentityResult> DeleteById(string id);
        void DeleteAll();
        Task SingOut();
        Task<ForUser> SelectById(string id);
        Task<IdentityResult> UpdateUser(ForUser x);
        List<ApplicationUser> SelectByName(string username);
        Task<bool> CheckSignIn(SignIn signIn);
        List<Country> countries();
        List<IdentityRole> AllRoles();
        Task<IdentityResult> EnabeldUserOFF(string id);
        string GetPath(string UserName);
    }
}
