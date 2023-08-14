using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Helper.Validators.General.Implements;
using System.Text;
using System.Xml;
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
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            List<T>? result;

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                result = (List<T>)serializer.Deserialize(fileStream);

                return result == null ? new List<T>() : result;
            }
        }

        public bool WriteToFile(string path, IEnumerable<T> objects)
        {
            if (objects != null)
            {
                XmlSerializer serializer = new XmlSerializer(objects.GetType());

                //using (var stringWriter = new StringWriter())
                //{
                //    using (XmlWriter writer = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented })
                //    {
                //        serializer.Serialize(writer, objects);
                //    }
                //}

                serializer.Serialize( Console.Out, objects );
                //FileInfo file = new FileInfo(path);
                //StreamWriter sw = file.AppendText();
                //XmlSerializer writer = new XmlSerializer(typeof(T));
                //writer.Serialize(sw, objects);
                //sw.Close();
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
