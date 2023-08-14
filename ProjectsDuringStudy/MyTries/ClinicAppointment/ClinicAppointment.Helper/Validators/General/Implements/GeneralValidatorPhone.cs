using System;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorPhone : IGeneralValidator<string>
    {
        public string Validate(object? value)
        {
            string? checkedValue = value == null ? string.Empty : value.ToString();

            if (string.IsNullOrEmpty(checkedValue))
                throw new ArgumentNullException("Value can't be empty");
            else
            {
                string pattern = "^(?:\\(?)(\\d{3})(?:[\\).\\s]?)(\\d{3})(?:[-\\.\\s]?)(\\d{4})(?!\\d)";

                Match match = Regex.Match(checkedValue, pattern, RegexOptions.IgnoreCase);

                if (!match.Success)
                {
                    throw new ArgumentNullException($"Phone number {checkedValue} is incorrect! Please check it and enter again!");
                }
            }

            return checkedValue;
        }
    }
}
