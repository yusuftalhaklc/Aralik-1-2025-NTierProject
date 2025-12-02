using FluentValidation;
using Project.WebApi.Model.RequestModels;

namespace Project.WebApi.Validators.RequestModels
{
    public class UpdateAppUserProfileRequestModelValidator : AbstractValidator<UpdateAppUserProfileRequestModel>
    {
        public UpdateAppUserProfileRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir.");
        }
    }
}

