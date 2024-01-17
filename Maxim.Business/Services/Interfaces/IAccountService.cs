using Maxim.Business.ViewModels.User;
using Maxim.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<IdentityResult> Register(RegisterUserVm vm);
        public Task<AppUser> Login(LoginUserVm vm);
        public Task CreateRole();
    }
}
