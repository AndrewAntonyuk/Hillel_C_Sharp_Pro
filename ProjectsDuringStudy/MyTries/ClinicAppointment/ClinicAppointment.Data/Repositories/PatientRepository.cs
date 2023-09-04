using ClinicAppointment.Data.Configuration;
using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Utils;

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

            _fileHandler = FileUtils.GetFileHandler<Patient>(result);
        }

        public override void ShowInfo(Patient patient)
        {
            if (patient != null)
            {
                Console.WriteLine("Id: " + patient.Id + "; name: " + patient.Name + "; surname: " + patient.Surname
                + "; phone: " + patient.Phone + "; email: " + patient.Email + "; illness: " + patient.IllnessType);
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

        protected override void CheckExist(IEnumerable<Patient> users, Patient userNext)
        {
            bool condition = userNext != null
                            && users.Any(user => user.Name.Equals(userNext.Name)
                                    && user.Surname.Equals(userNext.Surname)
                                    && (user?.Email?.Equals(userNext?.Email) ?? false)
                                    && (user?.Phone?.Equals(userNext.Phone) ?? false)
                                    && user?.IllnessType == userNext?.IllnessType);

            if (condition)
            {
                throw new ArgumentException($"Patient: {userNext?.Name} {userNext?.Surname} already exist!");
            }
        }
    }
}
