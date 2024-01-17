using AutoMapper;
using FluentValidation;
using Maxim.Business.Services.Interfaces;
using Maxim.Business.ViewModels.User;
using Maxim.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Maxim.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _accountService = accountService;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVm vm)
        {
            RegisterUserValidator validationRes = new RegisterUserValidator();
            var result = validationRes.Validate(vm);
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var res = await _accountService.Register(vm);
            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Something Went Wrong!");
                return View(vm);
            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVm vm)
        {
            LoginUserValidator validationRes = new LoginUserValidator();
            var failure = validationRes.Validate(vm);
            foreach (var item in failure.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await _accountService.Login(vm);
            if (user == null)
            {
                ModelState.AddModelError("", "Password or Username/Email is wrong.");
                return View(vm);
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Password or Username/Email is wrong.");
                return View(vm);
            }
            //if (!result.IsLockedOut)
            //{
            //    ModelState.AddModelError("", "Locked out.");
            //    return View(vm);
            //}
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        { 
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> CreateRole()
        {
            await _accountService.CreateRole();
            return RedirectToAction("Index", "Home");
        }
    }
}
