using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductName).MinimumLength(2).NotEmpty();
        RuleFor(p => p.UnitPrice).NotEmpty().GreaterThan(0);
    }
}