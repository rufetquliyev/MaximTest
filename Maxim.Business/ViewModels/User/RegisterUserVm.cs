using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maxim.Business.ViewModels.User
{
    public record RegisterUserVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterUserValidator : AbstractValidator<RegisterUserVm>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30).WithMessage("Name length cannot be more than 30 characters.");
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(60).WithMessage("Surname length cannot be more than 60 characters.");
            RuleFor(x => x.Username).NotEmpty().MaximumLength(90).WithMessage("Usernam length cannot be more than 90 characters.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty()
                .Must(x =>
                {
                    Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                    bool match = regex.IsMatch(x);
                    return match;
                })
                .WithMessage("Password is not in correct format.");
            RuleFor(x => x.ConfirmPassword).NotEmpty()
               .Equal(x => x.Password)
               .WithMessage("Confirm password must be the same wih password");
        }
    }
}
