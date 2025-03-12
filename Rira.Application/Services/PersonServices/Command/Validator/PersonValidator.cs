using FluentValidation;
using Rira.Application.Services.PersonServices.Command.Models;
using Rira.Common.Utilities;

namespace Rira.Application.Services.PersonServices.Command.Validator
{
    public class PersonValidator<T> : AbstractValidator<T> where T : PersonRequestDtoBase
    {
        public PersonValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty()
                .WithMessage(Alert.EmptyValidateAlert(Alert.Field.FirstName));
            RuleFor(u => u.LastName).NotEmpty()
                .WithMessage(Alert.EmptyValidateAlert(Alert.Field.LastName));
            RuleFor(u => u.NationalCode).NotEmpty()
                .WithMessage(Alert.EmptyValidateAlert(Alert.Field.NationalCode))
                .ValidNationalCode();
            RuleFor(u => u.DateOfBirth).NotEmpty()
                .WithMessage(Alert.EmptyValidateAlert(Alert.Field.BithOfDay))
                .Must(PersianDate.IsValidBirthDate)
                .WithMessage(Alert.GetValidateAlert(Alert.Field.BithOfDay));

        }
    }
}
