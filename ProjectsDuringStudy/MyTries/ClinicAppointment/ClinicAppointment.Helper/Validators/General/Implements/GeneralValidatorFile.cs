namespace ClinicAppointment.Helper.Validators.General.Implements
{
    public class GeneralValidatorFile : IGeneralValidator<string>
    {
        public string Validate(object? value)
        {
            string? _path = value == null ? string.Empty : value.ToString();

            if (!string.IsNullOrWhiteSpace(_path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path) ?? "");

                if (!File.Exists(_path))
                {
                    File.Create(_path).Dispose();
                    return string.Empty;
                }

                return File.ReadAllText(_path);
            }
            else
            {
                throw new ArgumentNullException("Target path can't be empty");
            }
        }
    }
}
