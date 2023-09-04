namespace ClinicAppointment.Service.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string? PatientName { get; set; }

        public string? PatientSureName { get; set; }

        public int DoctorId { get; set; }

        public string? DoctorIdName { get; set; }

        public string? DoctorIdSureName { get; set; }

        public string? DateTimeFrom { get; set; }

        public string? DateTimeTo { get; set; }

        public string? Description { get; set; }
    }
}
