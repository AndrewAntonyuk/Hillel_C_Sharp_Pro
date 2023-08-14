using System.ComponentModel;
using System.Reflection;

namespace ClinicAppointment.Helper.Extentions
{
    public static class EnumExtention
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute description = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return description == null ? value.ToString() : description.Description;
        }

        public static void ShowEnumDescription(Enum value)
        {
            Type typeOfEnum = value.GetType();

            foreach (var type in Enum.GetValues(typeOfEnum))
            {
                Console.WriteLine($"{(int)type} - " + ((Enum)type).GetDescription());
            }
        }
    }
}
 