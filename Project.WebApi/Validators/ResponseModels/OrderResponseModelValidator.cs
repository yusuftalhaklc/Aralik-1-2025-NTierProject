using FluentValidation;
using Project.WebApi.Model.ResponseModels;

namespace Project.WebApi.Validators.ResponseModels
{
    public class OrderResponseModelValidator : AbstractValidator<OrderResponseModel>
    {
        public OrderResponseModelValidator()
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

