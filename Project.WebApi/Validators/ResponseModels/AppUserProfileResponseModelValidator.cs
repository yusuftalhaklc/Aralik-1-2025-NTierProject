using FluentValidation;
using Project.WebApi.Model.ResponseModels;

namespace Project.WebApi.Validators.ResponseModels
{
    public class AppUserProfileResponseModelValidator : AbstractValidator<AppUserProfileResponseModel>
    {
        public AppUserProfileResponseModelValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir.");
        }
    }
}

