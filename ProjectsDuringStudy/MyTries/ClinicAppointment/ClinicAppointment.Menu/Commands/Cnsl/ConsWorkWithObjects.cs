using ClinicAppointment.Domain.Entities;
using ClinicAppointment.Helper.Validators.General.Implements;
using ClinicAppointment.Helper.Validators.General;
using ClinicAppointment.Service.Interfaces;

namespace ClinicAppointment.Menu.Commands.Cnsl
{
    public static class ConsWorkWithObjects
    {
        public static T CreateUser<T>() where T : UserBase, new()
        {
            T user = new T();

            IGeneralValidator<string> _stringValidator = new GeneralValidatorString();
            Console.WriteLine("Please enter name:");
            user.Name = _stringValidator.Validate(Console.ReadLine());

            Console.WriteLine("Please enter surname:");
            user.Surname = _stringValidator.Validate(Console.ReadLine());

            _stringValidator = new GeneralValidatorPhone();
            Console.WriteLine("Please enter phone:");
            user.Phone = _stringValidator.Validate(Console.ReadLine());

            _stringValidator = new GeneralValidatorEmail();
            Console.WriteLine("Please enter email:");
            user.Email = _stringValidator.Validate(Console.ReadLine());

            return user;
        }

        public static void UpdateUserById<T>(T user) where T : UserBase, new()
        {
            if (user != null)
            {
                IGeneralValidator<string> _stringValidator = new GeneralValidatorString();
                Console.WriteLine("Please enter new name:");
                user.Name = _stringValidator.Validate(Console.ReadLine());

                Console.WriteLine("Please enter new surname:");
                user.Surname = _stringValidator.Validate(Console.ReadLine());

                _stringValidator = new GeneralValidatorPhone();
                Console.WriteLine("Please enter new phone:");
                user.Phone = _stringValidator.Validate(Console.ReadLine());

                _stringValidator = new GeneralValidatorEmail();
                Console.WriteLine("Please enter new email:");
                user.Email = _stringValidator.Validate(Console.ReadLine());
            }
        }

        public static void DeleteObjectById<TI, TA>(TI service) where TI : IService<TA> where TA : Auditable, new()
        {
            int _objId = GetCheckedUserId();
            bool _deleted = service?.Delete(_objId) ?? false;

            if (_deleted)
            {
                Console.WriteLine("\nDeleting is success:");
            }
            else
            {
                Console.WriteLine("\nCouldn't delete");
            }
        }

        public static TA GetUserById<TI, TA>(TI service) where TI : IService<TA> where TA : Auditable, new()
        {
            int _userId = GetCheckedUserId();
            TA? user = service?.Get(_userId);

            if (user == null)
            {
                throw new ArgumentException($"Couldn't find user with id {_userId}");
            }

            return user;
        }

        public static void ShowObjectById<TI, TA>(TI service) where TI : IService<TA> where TA : Auditable
        {
            int _objId = GetCheckedUserId();
            TA? obj = service?.Get(_objId);

            if (obj != null)
            {
                Console.WriteLine("\nDetailed information:");
                service?.ShowInfo(obj);
            }
            else
            {
                Console.WriteLine($"\nCouldn't find instance with id {_objId}");
            }
        }

        public static void ShowAllObjects<TI, TA>(TI service) where TI : IService<TA> where TA : Auditable
        {
            IEnumerable<TA> objects = service?.GetAll() ?? new List<TA>();

            if (objects.Count() > 0)
            {
                objects.ToList().ForEach(x => service?.ShowInfo(x));
            }
            else
            {
                Console.WriteLine($"\nThere aren't any data");
            }
        }

        public static void ResultObjectInform<TI, TA>(TA obj, TI service) where TI : IService<TA> where TA : Auditable
        {
            if (obj == null || service == null)
            {
                Console.WriteLine("Couldn't perform operation");
            }
            else
            {
                Console.WriteLine("\nThe result of operation:");
                service.ShowInfo(obj);
            }
        }

        private static int GetCheckedUserId()
        {
            IGeneralValidator<int> _validator = new GeneralValidatorId();
            return _validator.Validate(Console.ReadLine());
        }
    }
}
