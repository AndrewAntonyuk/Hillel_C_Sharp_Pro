using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Helper.Validators.General.Implements;
using System.Xml.Serialization;

namespace ClinicAppointment.Helper.FileHandlers
{
    public class FileHandlerXml<T> : IFileHandler<T> where T : Auditable
    {
        private readonly IGeneralValidator<string> fileValidator;

        public FileHandlerXml()
        {
            fileValidator = new GeneralValidatorFile();
        }

        public IEnumerable<T> ReadFromFile(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            List<T>? result;

            fileValidator.Validate(path);

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    result = serializer.Deserialize(fileStream) as List<T>;
                }
                catch (InvalidOperationException ex)
                {
                    serializer.Serialize(fileStream, new List<T>());
                    result = new List<T>();
                }
            }

            return result ?? new List<T>();
        }

        public bool WriteToFile(string path, IEnumerable<T> objects)
        {
            if (objects != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                fileValidator.Validate(path);

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    serializer.Serialize(fileStream, objects.ToList());
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
