using System;

namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorString : IGeneralValidator<string>
    {
        public string Validate(object? value)
        {
            string? checkedValue = value == null ? string.Empty : value.ToString();

            if (string.IsNullOrEmpty(checkedValue))
                throw new ArgumentNullException("Value can't be empty");

            return checkedValue;
        }
    }
}
