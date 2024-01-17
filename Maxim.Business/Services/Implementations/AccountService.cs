using AutoMapper;
using Maxim.Business.Exceptions.User;
using Maxim.Business.Services.Interfaces;
using Maxim.Business.UserRoles;
using Maxim.Business.ViewModels.User;
using Maxim.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Services.Implementations
{   
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task CreateRole() 
        {
            foreach (var item in Enum.GetValues(typeof(Roles)))
            {
                if(!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = item.ToString()
                    });
                }
            }
        }

        public async Task<AppUser> Login(LoginUserVm vm)
        {
            AppUser user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail) ?? await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            if (user is null) throw new UserNotFoundException();
            return user;
        }

        public async Task<IdentityResult> Register(RegisterUserVm vm)
        {
            AppUser user = _mapper.Map<AppUser>(vm);
            var res = await _userManager.CreateAsync(user, vm.Password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            return res;
        }
    }
}
