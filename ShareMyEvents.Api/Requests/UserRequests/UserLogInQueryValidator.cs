using FluentValidation;
using ShareMyEvents.Api.Requests.UserRequests;
namespace ShareMyEvents.Api.Validators;

public class UserLogInQueryValidator : AbstractValidator<UserLogInQuery>
{
    public UserLogInQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty.");
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("Password cannot be empty.");
    }
}
