using ClinicAppointment.Domain.Enums;

namespace ClinicAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorTypes DoctorType { get; set; }

        public byte Experiance { get; set; }

        public decimal Salary { get; set; }
    }
}
