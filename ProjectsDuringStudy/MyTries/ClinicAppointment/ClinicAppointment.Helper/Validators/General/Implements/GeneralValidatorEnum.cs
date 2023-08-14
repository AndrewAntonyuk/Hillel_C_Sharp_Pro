using System;

namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorEnum<T> : IGeneralValidator<T>
    {
        public T Validate(object? value)
        {
            if (value == null)
                throw new ArgumentNullException("Value can't be null");

            int valueForCheck = int.Parse(value.ToString() ?? "0");

            if (!Enum.IsDefined(typeof(T), valueForCheck))
                throw new ArgumentException($"Value can't be {valueForCheck}");

            return (T)(object)valueForCheck;
        }
    }
}
