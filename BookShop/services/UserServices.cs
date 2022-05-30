using BookShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.services
{
    public class UserServices: IUserServices
    {
        BookShopContext context;
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        SignInManager<ApplicationUser> signInManager;
        public UserServices(BookShopContext _context, UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager, SignInManager<ApplicationUser> _signInManager)
        {
            context = _context;
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }
        public  List<ApplicationUser> SellectAll ()
        {

            List<ApplicationUser> list =  userManager.Users.Where(e => e.LockoutEnabled != false).Include("country").ToList();
            return list;
        }
        public async Task<IdentityResult> SignUp(ForUser u)
        {
            string name = Guid.NewGuid().ToString() + "." + u.Image.FileName.Split(".")[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UserImage", name);
            u.Image.CopyTo(new FileStream(path, FileMode.Create));
            string ImgPath = "http://localhost/BookShop/UImg/" + name;
            ApplicationUser user = new ApplicationUser();
            user.FullName = u.FullName;
            user.CountryId = u.CountryId;
            user.Email= u.Email;
            user.Gender= u.Gender;
            user.JoinDate = DateTime.Now.Date;
            user.ImagePath = ImgPath;
            user.RoleId = u.RoleId;
            user.UserName = u.Email;
            var result=await userManager.CreateAsync(user, u.Password);
            if(result.Succeeded)
            {
                var role=await roleManager.FindByIdAsync(u.RoleId);
                 await userManager.AddToRoleAsync(user, role.Name);
               
            }
            return result;
        }
        public async Task<IdentityResult> DeleteById(string id)
        {
            ApplicationUser user =await userManager.FindByIdAsync(id);

            var rol =await userManager.GetRolesAsync(user);
            if(rol.Count()>0)
            {
                foreach(var item in rol.ToList())
                {
                  var result=  await userManager.RemoveFromRoleAsync(user, item);
                }
            }
               var result2= await userManager.DeleteAsync(user);
            return result2;
        }
        public async Task<ForUser> SelectById(string id)
        {
            ApplicationUser user = new ApplicationUser();
            ForUser forUser = new ForUser();
            user =await userManager.FindByIdAsync(id);
            if (user != null)
            {
                forUser.Id = user.Id;
                forUser.Email = user.Email;
                forUser.Gender = user.Gender;
                forUser.CountryId= user.CountryId;
                forUser.RoleId = user.RoleId;
                forUser.FullName= user.FullName;
            }
            return forUser;

        }
        public  void DeleteAll()
        {
            List<ApplicationUser> user=new List<ApplicationUser>();
            user =  userManager.Users.ToList();
            
            user.ForEach(async u =>
            {
             await userManager.DeleteAsync(u);
            });

            
        }
        public async Task<IdentityResult> UpdateUser(ForUser x)
        {
            ApplicationUser user1 = context.Users.Where(u => u.Id == x.Id).FirstOrDefault();


            string name = Guid.NewGuid().ToString() + "." + x.Image.FileName.Split(".")[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UserImage", name);
            x.Image.CopyTo(new FileStream(path, FileMode.Create));
            string ImgPath = "http://localhost/BookShop/UImg/" + name;
            ApplicationUser user = new ApplicationUser();
            user1.FullName = x.FullName;
            user1.CountryId = x.CountryId;
            user1.Email = x.Email;
            user1.Gender = x.Gender;
            user1.ImagePath = ImgPath;
            user1.RoleId = x.RoleId;
            user1.UserName = x.Email;
            context.Users.Attach(user1);
            context.Entry(user1).State=EntityState.Modified;
            context.SaveChanges();
            
                var role = await roleManager.FindByIdAsync(x.RoleId);
                 var result = await userManager.CreateAsync(user, role.Name);

            return result;

            /*await userManager.UpdateAsync(user);*/
        }
        public List<ApplicationUser> SelectByName(string username)
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            users = context.Users.Where(n => n.FullName == username).ToList();
            return users;
        }
        public async Task<bool> CheckSignIn (SignIn signIn)
        {
            
            var result =await signInManager.PasswordSignInAsync(signIn.UserName, signIn.Password, signIn.RemeberMe, false);
            if (result.Succeeded)
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }

        public List<Country> countries()
        {
            List<Country> list = context.countries.ToList();
            return list;
        }
        public  List<IdentityRole>  AllRoles()
        {
            List<IdentityRole> list = roleManager.Roles.ToList();
            return list;


        }
        public async Task SingOut()
        {
            await signInManager.SignOutAsync();
            


        }

        public async Task<IdentityResult> EnabeldUserOFF (string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            user.LockoutEnabled = false;
           var result= await userManager.UpdateAsync(user);
            return result;
            
        }
        public string GetPath(string UserName)
        {
            string path=context.Users.Where(n => n.UserName == UserName).Select(e => e.ImagePath).FirstOrDefault();
             
            return path;
        }
    }
}
