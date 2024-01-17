using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maxim.Business.ViewModels.User
{
    public record LoginUserVm
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserValidator : AbstractValidator<LoginUserVm>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty().MaximumLength(90).WithMessage("Name length cannot be more than 90 characters.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .Must(x =>
                {
                    Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                    bool match = regex.IsMatch(x);
                    return match;
                })
                .WithMessage("Password is not in correct format.");
        }
    }
}
