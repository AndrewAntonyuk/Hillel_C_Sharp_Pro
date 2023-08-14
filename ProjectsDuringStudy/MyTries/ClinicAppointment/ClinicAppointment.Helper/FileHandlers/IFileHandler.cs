using ClinicAppointment.Domain.Entities;

namespace ClinicAppointment.Helper.FileHandlers
{
    public interface IFileHandler<T> where T : Auditable
    {
        IEnumerable<T> ReadFromFile(string path);

        bool WriteToFile(string path, IEnumerable<T> objects);
    }
}
