using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxim.Business.ViewModels.Feature
{
    public class UpdateFeatureVm 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? IconUrl { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class UpdateFeatureValidator : AbstractValidator<UpdateFeatureVm>
    {
        public UpdateFeatureValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50).WithMessage("Title length cannot be more than 50 characters.");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(50).WithMessage("Description length cannot be more than 150 characters.");
        }
    }
}
