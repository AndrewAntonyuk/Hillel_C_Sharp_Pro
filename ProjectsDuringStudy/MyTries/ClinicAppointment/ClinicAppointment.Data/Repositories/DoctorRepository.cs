using ClinicAppointment.Data.Configuration;
using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.FileHandlers;
using ClinicAppointment.Helper.Utils;
using Microsoft.VisualBasic.FileIO;

namespace ClinicAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }
        public override string FileType { get; set; }
        public override int LastId { get; set; }

        public DoctorRepository()
        {
            dynamic result = ReadFromAppSettings();

            FileType = result.Database.FileType;

            Path = result.Database.Doctors.Path + "." + FileType;            

            LastId = result.Database.Doctors.LastId;

            if (FileType.ToLower().Equals("xml"))
                _fileHandler = new FileHandlerXml<Doctor>();
            else
                _fileHandler = new FileHandlerJson<Doctor>();
        }

        public override void ShowInfo(Doctor doctor)
        {
            if (doctor != null)
            {
                Console.WriteLine("Id: " + doctor.Id + "; name: " + doctor.Name + "; surname: " + doctor.Surname
                + "; email: " + doctor.Email + "; phone: " + doctor.Phone
                + "; type: " + doctor.DoctorType + "; experiance: " + doctor.Experiance);
            }
            else
            {
                throw new ArgumentNullException(nameof(doctor) + " can't be null");
            }
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
