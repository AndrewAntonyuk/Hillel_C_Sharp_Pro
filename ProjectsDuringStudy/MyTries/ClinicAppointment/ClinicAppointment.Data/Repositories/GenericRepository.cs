using ClinicAppointment.Data.Configuration;
using ClinicAppointment.Data.Interfaces;
using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.FileHandlers;
using Newtonsoft.Json;

namespace ClinicAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public abstract string Path { get; set; }

        public abstract string FileType { get; set; }

        public abstract int LastId { get; set; }

        protected IFileHandler<TSource> _fileHandler;

        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;
            source.UpdatedAt = DateTime.Now;

            _fileHandler.WriteToFile(Path, GetAll().Append(source));

            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            _fileHandler.WriteToFile(Path, GetAll().Where(x => x.Id != id));

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            return _fileHandler.ReadFromFile(Path);
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            _fileHandler.WriteToFile(Path, GetAll().Select(x => x.Id == id ? source : x));

            return source;
        }

        public abstract void ShowInfo(TSource user);

        protected abstract void SaveLastId();

        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath));
    }
}
