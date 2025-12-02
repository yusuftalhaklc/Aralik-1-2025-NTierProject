using FluentValidation;
using Project.WebApi.Model.RequestModels;

namespace Project.WebApi.Validators.RequestModels
{
    public class CreateOrderRequestModelValidator : AbstractValidator<CreateOrderRequestModel>
    {
        public CreateOrderRequestModelValidator()
        {
            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Teslimat adresi boş olamaz.")
                .MaximumLength(500).WithMessage("Teslimat adresi en fazla 500 karakter olabilir.");

            RuleFor(x => x.AppUserId)
                .GreaterThan(0).When(x => x.AppUserId.HasValue)
                .WithMessage("Kullanıcı Id 0'dan büyük olmalıdır.");
        }
    }
}

