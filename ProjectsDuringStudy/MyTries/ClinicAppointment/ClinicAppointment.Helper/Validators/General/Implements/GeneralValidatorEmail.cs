using System.Text.RegularExpressions;

namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorEmail : IGeneralValidator<string>
    {
        public string Validate(object? value)
        {
            string? checkedValue = value == null ? string.Empty : value.ToString();

            if (string.IsNullOrEmpty(checkedValue))
                throw new ArgumentNullException("Value can't be empty");
            else
            {
                string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

                Match match = Regex.Match(checkedValue, pattern, RegexOptions.IgnoreCase);

                if (!match.Success)
                {
                    throw new ArgumentNullException($"Email {checkedValue} is incorrect! Please check it and enter again!");
                }
            }

            return checkedValue;
        }
    }
}
