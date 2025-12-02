using FluentValidation;
using Project.WebApi.Model.RequestModels;

namespace Project.WebApi.Validators.RequestModels
{
    public class UpdateCategoryRequestModelValidator : AbstractValidator<UpdateCategoryRequestModel>
    {
        public UpdateCategoryRequestModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id 0'dan büyük olmalıdır.");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.CategoryDescription)
                .MaximumLength(500).WithMessage("Kategori açıklaması en fazla 500 karakter olabilir.");
        }
    }
}

