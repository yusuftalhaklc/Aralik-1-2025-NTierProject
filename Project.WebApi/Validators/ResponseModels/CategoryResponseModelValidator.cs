using FluentValidation;
using Project.WebApi.Model.ResponseModels;

namespace Project.WebApi.Validators.ResponseModels
{
    public class CategoryResponseModelValidator : AbstractValidator<CategoryResponseModel>
    {
        public CategoryResponseModelValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.CategoryDescription)
                .MaximumLength(500).WithMessage("Kategori açıklaması en fazla 500 karakter olabilir.");
        }
    }
}

