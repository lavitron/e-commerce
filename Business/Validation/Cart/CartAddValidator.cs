using Entity.Dto.Cart;
using FluentValidation;

namespace Business.Validation.Cart
{
    /// <summary>
    /// Sepet ekleme doğrulama sınıfı
    /// </summary>
    public class CartAddValidator : AbstractValidator<CartAddDto>
    {
        public CartAddValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("Kullanıcı seçilmelidir.")
                .GreaterThan(0).WithMessage("Kullanıcı seçilmelidir.")
                .LessThan(int.MaxValue).WithMessage("Geçerli bir değer girilmelidir.")
                .Custom((id, context) =>
                {
                    if (id.ToString().Any(p => !char.IsLetter(p)))
                    {
                        context.AddFailure("Geçerli bir kullanıcı seçilmelidir.");
                    }
                });
            RuleFor(p => p.UserId)
              .GreaterThan(0).WithMessage("Geçerli bir kullanıcı seçilmelidir.")
              .LessThan(int.MaxValue).WithMessage("Geçerli bir değer girilmelidir.")
              .Custom((id, context) =>
              {
                  if (id.ToString().Any(p => !char.IsLetter(p)))
                  {
                      context.AddFailure("Geçerli bir kullanıcı seçilmelidir.");
                  }
              });
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("Ürün seçilmelidir.")
                .GreaterThan(0).WithMessage("Ürün seçilmelidir.")
                .LessThan(int.MaxValue).WithMessage("Geçerli bir değer girilmelidir.")
                .Custom((id, context) =>
                {
                    if (id.ToString().Any(p => !char.IsLetter(p)))
                    {
                        context.AddFailure("Geçerli bir ürün seçilmelidir.");
                    }
                });
            RuleFor(p => p.TotalProductCount).NotEmpty().WithMessage("Ürün sayısı belirtilmelidir.")
                .GreaterThan(0).WithMessage("Kullanıcı seçilmelidir.")
                .LessThan(1000).WithMessage("Ürün sayısı 1000 adetten fazla seçilmemelidir.")
                  .Custom((id, context) =>
                  {
                      if (id.ToString().Any(p => !char.IsLetter(p)))
                      {
                          context.AddFailure("Geçerli bir ürün sayısı seçilmelidir.");
                      }
                  }); ;
        }
    }
}
