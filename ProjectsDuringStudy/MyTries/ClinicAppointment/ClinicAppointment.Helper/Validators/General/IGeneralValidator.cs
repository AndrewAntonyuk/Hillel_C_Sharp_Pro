namespace ClinicAppointment.Helper.Validators.General
{
    public interface IGeneralValidator<T>
    {
        T Validate(object? value);
    }
}
