using FluentValidation;
using Project.WebApi.Model.ResponseModels;

namespace Project.WebApi.Validators.ResponseModels
{
    public class OrderDetailResponseModelValidator : AbstractValidator<OrderDetailResponseModel>
    {
        public OrderDetailResponseModelValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Sipariş Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Ürün Id 0'dan büyük olmalıdır.");
        }
    }
}

