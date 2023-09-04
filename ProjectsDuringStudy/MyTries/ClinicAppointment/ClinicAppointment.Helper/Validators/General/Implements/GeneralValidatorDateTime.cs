namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorDateTime : IGeneralValidator<DateTime>
    {
        public DateTime Validate(object? value)
        {
            string inputValue = string.IsNullOrEmpty((string?)value) ? DateTime.Now.ToString() : (string)value;
            DateTime checkedValue;

            if (!DateTime.TryParse(inputValue, out checkedValue))
                throw new ArgumentNullException("Incorrect value of date and time");

            return checkedValue;
        }
    }
}
