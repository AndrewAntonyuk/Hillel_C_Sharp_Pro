namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorAge : IGeneralValidator<byte> 
    {
        public byte Validate(object? value)
        {
            if (value == null)
                throw new ArgumentNullException("Value can't be null");

            byte valueForCheck = byte.Parse(value.ToString() ?? "0");

            if (valueForCheck < 0 || valueForCheck >= byte.MaxValue)
                throw new ArgumentOutOfRangeException($"Age can't be {valueForCheck}. Available range: 0 - {byte.MaxValue - 1}");

            return valueForCheck;
        }
    }
}
