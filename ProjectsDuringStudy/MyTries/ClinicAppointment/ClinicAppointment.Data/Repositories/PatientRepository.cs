using ClinicAppointment.Data.Configuration;
using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.FileHandlers;
using System.Numerics;

namespace ClinicAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override string FileType { get; set; }
        public override int LastId { get; set; }

        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            FileType = result.Database.FileType;
            Path = result.Database.Patients.Path + "." + FileType; 
            LastId = result.Database.Patients.LastId;

            if (FileType.ToLower().Equals("xml"))
                _fileHandler = new FileHandlerXml<Patient>();
            else
                _fileHandler = new FileHandlerJson<Patient>();
        }

        public override void ShowInfo(Patient patient)
        {
            if (patient != null)
            {
                Console.WriteLine("Id: " + patient.Id + "; name: " + patient.Name + "; surname: " + patient.Surname
                + "; email: " + patient.Email + "; phone: " + patient.Phone);
            }
            else
            {
                throw new ArgumentNullException(nameof(patient) + " can't be null");
            }
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
