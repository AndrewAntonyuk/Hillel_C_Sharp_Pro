namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorId : IGeneralValidator<int> 
    {
        public int Validate(object? value)
        {
            if (value == null)
                throw new ArgumentNullException("Value can't be null");

            int valueForCheck = int.Parse(value.ToString() ?? "0");

            if (valueForCheck < 0 || valueForCheck >= int.MaxValue)
                throw new ArgumentOutOfRangeException($"Age can't be {valueForCheck}. Available range: 0 - {int.MaxValue - 1}");

            return valueForCheck;
        }
    }
}
