using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LoginRegistartionEntityFramework.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace LoginRegistartionEntityFramework.Controllers
{
    public class IdentityUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _usersmanager;
        private readonly SignInManager<IdentityUser> _signinmanager;

        public IdentityUsersController(UserManager<IdentityUser> usersmanager , SignInManager<IdentityUser> signinmanager)
        {
            _usersmanager = usersmanager;
            _signinmanager = signinmanager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(NewUserClass userclassObj)
        {
            var UserCreden = new IdentityUser { UserName = userclassObj.UserName, Email = userclassObj.Email };

            var InsertUserData = await _usersmanager.CreateAsync(UserCreden, userclassObj.PasswordHash);

            if (InsertUserData.Succeeded)
            {
                ViewBag.message = "User Of Email Id =" + userclassObj.Email + "Has Been Saved Successfully";
            }
            else
            {
                foreach (var error in InsertUserData.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginClass loginclassObj)
        {
            if (ModelState.IsValid)
            {
                var resulVal = await _signinmanager.PasswordSignInAsync(loginclassObj.Email,loginclassObj.Password ,false,false);
                
                if (resulVal.Succeeded)
                {
                    return RedirectToAction("Welcome", "IdentityUsers");
                }
                ModelState.AddModelError("","Invalid User Data");
            }
            return View(loginclassObj);
        }



        [Authorize]
        public IActionResult Welcome()
        {
            ViewBag.message = User.Identity.Name;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Login", "IdentityUsers");
        }
    }
}
