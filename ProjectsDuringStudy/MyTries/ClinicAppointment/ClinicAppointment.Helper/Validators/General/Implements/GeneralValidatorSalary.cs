namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorSalary : IGeneralValidator<decimal>
    {
        public decimal Validate(object? value)
        {
            if (value == null)
                throw new ArgumentNullException("Value can't be null");

            decimal valueForCheck = decimal.Parse(value.ToString() ?? "0.0");

            if (valueForCheck < 0 || valueForCheck >= decimal.MaxValue)
                throw new ArgumentOutOfRangeException($"Salary can't be {valueForCheck}. Available range: 0 - {decimal.MaxValue}");

            return valueForCheck;
        }
    }
}
