using Aec.Brasil.Application.Common.Attributes;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Aec.Brasil.Application.Common.Helpers
{
    public static class EnumHelper
    {
        public static string Description<TEnum>(this TEnum value) where TEnum : struct, IConvertible
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static string Chave<TEnum>(this TEnum value) where TEnum : struct, IConvertible
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            ChaveAttribute[] attributes = fi.GetCustomAttributes(typeof(ChaveAttribute), false) as ChaveAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Chave;
            }

            return value.ToString();
        }

        public static TEnum GetEnumByName<TEnum>(string name) where TEnum : struct, IConvertible
        {
            try
            {
                var result = Enum.Parse(typeof(TEnum), name);

                return (TEnum)result;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
