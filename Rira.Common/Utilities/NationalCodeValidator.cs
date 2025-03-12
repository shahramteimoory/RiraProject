using FluentValidation;

namespace Rira.Common.Utilities
{
    public static class NationalCodeValidator
    {
        public static IRuleBuilderOptions<T, string> ValidNationalCode<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(IsValidNationalCode)
                .WithMessage(Alert.GetValidateAlert(Alert.Field.NationalCode));
        }

        private static bool IsValidNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10)
                return false;

            if (nationalCode.All(ch => ch == nationalCode[0]))
                return false;

            var numArray = nationalCode.Select(ch => (int)char.GetNumericValue(ch)).ToArray();
            int checksum = numArray[9];

            int sum = numArray.Take(9).Select((n, i) => n * (10 - i)).Sum();
            int remainder = sum % 11;
            int expectedCheckDigit = remainder < 2 ? remainder : 11 - remainder;

            return checksum == expectedCheckDigit;
        }
    }
}
