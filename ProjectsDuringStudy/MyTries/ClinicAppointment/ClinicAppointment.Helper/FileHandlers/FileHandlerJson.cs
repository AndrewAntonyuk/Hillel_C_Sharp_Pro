using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Helper.Validators.General.Implements;
using Newtonsoft.Json;

namespace ClinicAppointment.Helper.FileHandlers
{
    public class FileHandlerJson<T> : IFileHandler<T> where T : Auditable
    {
        private readonly IGeneralValidator<string> fileValidator;

        public FileHandlerJson()
        {
            fileValidator = new GeneralValidatorFile();
        }

        public IEnumerable<T> ReadFromFile(string path)
        {
            string textFromFile = fileValidator.Validate(path);

            if (string.IsNullOrWhiteSpace(textFromFile))
            {
                WriteToFile(path, new List<T>());
                textFromFile = "[]";
            }

            return JsonConvert.DeserializeObject<List<T>>(textFromFile)!;
        }

        public bool WriteToFile(string path, IEnumerable<T> objects)
        {
            fileValidator.Validate(path);

            File.WriteAllText(path, JsonConvert.SerializeObject(objects, Formatting.Indented));

            return true;
        }
    }
}
