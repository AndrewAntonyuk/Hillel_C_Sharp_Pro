using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.FileHandlers;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Serialization;

namespace ClinicAppointment.Helper.Utils
{
    public static class FileUtils
    {
        public static IFileHandler<T> GetFileHandler<T>(dynamic? settings) where T : Auditable
        {
            string fileType = settings?.Database.FileType ?? "";

            if (fileType.ToLower().Contains("xml"))
            {
                return new FileHandlerXml<T>();
            }

            return new FileHandlerJson<T>();
        }
    }
}
