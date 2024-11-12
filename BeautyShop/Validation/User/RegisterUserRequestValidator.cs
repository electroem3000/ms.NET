using BeautyShop.Controllers.Entities.UserEntities;
using FluentValidation;

namespace BeautyShop.Validation.User;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is required");
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Email is required");
        RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200)
            .WithMessage("UserName is required");
        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role is required");
    }
}