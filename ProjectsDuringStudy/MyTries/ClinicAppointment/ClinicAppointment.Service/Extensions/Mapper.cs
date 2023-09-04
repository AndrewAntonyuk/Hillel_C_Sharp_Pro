using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Data.Repositories;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Domain.Enums;
using ClinicAppointment.Service.ViewModels;

namespace ClinicAppointment.Service.Extensions
{
    public static class Mapper
    {
        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorViewModel()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DoctorType = doctor.DoctorType.ToString(),
                Experience = doctor.Experience,
                Salary = doctor.Salary
            };
        }

        public static Doctor ConvertTo(this DoctorViewModel doctor)
        {
            if (doctor == null)
                return null;

            DoctorTypes drType;
            drType = Enum.TryParse(doctor.DoctorType, true, out drType) ? drType : 0;

            return new Doctor()
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DoctorType = drType,
                Experience = doctor.Experience,
                Salary = doctor.Salary
            };
        }

        public static PatientViewModel ConvertTo(this Patient patient)
        {
            if (patient == null)
                return null;

            return new PatientViewModel()
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Phone = patient.Phone,
                IllnessType = patient.IllnessType.ToString(),
                AdditionalInfo = patient.AdditionalInfo,
                Address = patient.Address
            };
        }

        public static Patient ConvertTo(this PatientViewModel patient)
        {
            if (patient == null)
                return null;

            IllnessTypes illnessType;
            illnessType = Enum.TryParse(patient.IllnessType, true, out illnessType) ? illnessType : 0;

            return new Patient()
            {
                Id = patient.Id,
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Phone = patient.Phone,
                IllnessType = illnessType,
                AdditionalInfo = patient.AdditionalInfo,
                Address = patient.Address
            };
        }

        public static AppointmentViewModel ConvertTo(this Appointment appointment)
        {
            if (appointment == null)
                return null;

            return new AppointmentViewModel()
            {
                Id = appointment.Id,
                PatientId = appointment.Patient?.Id ?? -1,
                PatientName = appointment.Patient?.Name ?? "",
                PatientSureName = appointment.Patient?.Surname ?? "",
                DoctorId = appointment.Doctor?.Id ?? -1,
                DoctorIdName = appointment.Doctor?.Name ?? "",
                DoctorIdSureName = appointment.Doctor?.Surname ?? "",
                DateTimeFrom = appointment.DateTimeFrom.ToString(),
                DateTimeTo = appointment.DateTimeTo.ToString(),
                Description = appointment.Description
            };
        }

        public static Appointment ConvertTo(this AppointmentViewModel appointment)
        {
            if (appointment == null)
                return null;

            IDoctorRepository doctorRepository = new DoctorRepository();
            IPatientRepository patientRepository = new PatientRepository();

            DateTime from = DateTime.MinValue;
            DateTime.TryParse(appointment.DateTimeFrom, out from);

            DateTime to = DateTime.MinValue;
            DateTime.TryParse(appointment.DateTimeFrom, out to);

            return new Appointment()
            {
                Id = appointment.Id,
                Doctor = doctorRepository.GetById(appointment.DoctorId),
                Patient = patientRepository.GetById(appointment.PatientId),
                DateTimeFrom = from,
                DateTimeTo = to,
                Description = appointment.Description
            };
        }
    }
}
