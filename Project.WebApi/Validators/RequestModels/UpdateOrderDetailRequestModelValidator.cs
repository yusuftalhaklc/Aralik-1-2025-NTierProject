using FluentValidation;
using Project.WebApi.Model.RequestModels;

namespace Project.WebApi.Validators.RequestModels
{
    public class UpdateOrderDetailRequestModelValidator : AbstractValidator<UpdateOrderDetailRequestModel>
    {
        public UpdateOrderDetailRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("Sipariş Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Ürün Id 0'dan büyük olmalıdır.");
        }
    }
}

