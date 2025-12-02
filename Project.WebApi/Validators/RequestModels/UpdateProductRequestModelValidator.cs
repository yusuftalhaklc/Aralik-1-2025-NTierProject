using FluentValidation;
using Project.WebApi.Model.RequestModels;

namespace Project.WebApi.Validators.RequestModels
{
    public class UpdateProductRequestModelValidator : AbstractValidator<UpdateProductRequestModel>
    {
        public UpdateProductRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Birim fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).When(x => x.CategoryId.HasValue)
                .WithMessage("Kategori Id 0'dan büyük olmalıdır.");
        }
    }
}

