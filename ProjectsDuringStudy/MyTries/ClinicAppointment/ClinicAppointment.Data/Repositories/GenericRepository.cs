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

            List<TSource> users = GetAll() as List<TSource> ?? new List<TSource>();

            CheckExist(users, source);
            _fileHandler.WriteToFile(Path, users.Append(source));
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;

            var newList = GetAll().Where(x => x.Id != id);

            _fileHandler.WriteToFile(Path, newList);

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            return _fileHandler.ReadFromFile(Path);
        }

        public TSource? GetById(int id)
        {
            return (from u in GetAll()
                    where u.Id == id
                    select u).FirstOrDefault();
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

        protected abstract void CheckExist(IEnumerable<TSource> arr, TSource obj);

        protected dynamic ReadFromAppSettings() => JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Constants.AppSettingsPath));
    }
}
