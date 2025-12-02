using FluentValidation;
using Project.WebApi.Model.RequestModels;

namespace Project.WebApi.Validators.RequestModels
{
    public class CreateOrderDetailRequestModelValidator : AbstractValidator<CreateOrderDetailRequestModel>
    {
        public CreateOrderDetailRequestModelValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Sipariş Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Ürün Id 0'dan büyük olmalıdır.");
        }
    }
}

