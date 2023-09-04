using ClinicAppointment.Data.Configuration;
using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Utils;

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

            _fileHandler = FileUtils.GetFileHandler<Doctor>(result);
        }

        public override void ShowInfo(Doctor doctor)
        {
            if (doctor != null)
            {
                Console.WriteLine("Id: " + doctor.Id + "; name: " + doctor.Name + "; surname: " + doctor.Surname
                 + "; phone: " + doctor.Phone + "; email: " + doctor.Email
                + "; type: " + doctor.DoctorType + "; experience: " + doctor.Experience);
            }
            else
            {
                throw new ArgumentNullException(nameof(doctor) + " can't be null");
            }
        }

        protected override void CheckExist(IEnumerable<Doctor> users, Doctor? userNext)
        {
            bool condition = userNext != null
                             && users.Any(user => user.Name.Equals(userNext.Name)
                                     && user.Surname.Equals(userNext.Surname)
                                     && (user?.Email?.Equals(userNext?.Email) ?? false)
                                     && user.DoctorType == userNext.DoctorType
                                     && (user?.Phone?.Equals(userNext.Phone) ?? false));

            if (condition)
            {
                throw new ArgumentException($"Doctor: {userNext?.Name} {userNext?.Surname} {userNext?.DoctorType} already exist!");
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
