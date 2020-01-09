using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace SnipeSharp.Serialization
{
    internal sealed class SerializationContractResolver : DefaultContractResolver
    {
        public static bool TryGetConverter(PropertyInfo property, FieldAttribute attribute, out JsonConverter converter)
        {
            switch(attribute.Converter)
            {
                case FieldConverter.CommonModelConverter:
                    converter = CustomCommonModelConverter.Instance;
                    return true;
                case FieldConverter.CommonModelArrayConverter:
                    converter = CustomCommonModelArrayConverter.Instance;
                    return true;
                case FieldConverter.TimeSpanConverter:
                    converter = CustomTimeSpanConverter.Instance;
                    return true;
                case FieldConverter.DateTimeConverter:
                    converter = CustomDateTimeConverter.Instance;
                    return true;
                case FieldConverter.AssetStatusConverter:
                    converter = CustomAssetStatusConverter.Instance;
                    return true;
                case FieldConverter.CustomFieldDictionaryConverter:
                case FieldConverter.AvailableActionsConverter:
                case FieldConverter.PermissionsConverter:
                case FieldConverter.MessagesConverter:
                case FieldConverter.MonthsConverter:
                case FieldConverter.FalseyUriConverter:
                    converter = null;
                    return false;
                case FieldConverter.None:
                default:
                    if(null == property)
                    {
                        converter = null;
                        return false;
                    }
                    if(property.PropertyType.IsAssignableFrom(typeof(bool?)))
                    {
                        converter = CustomNullableBooleanConverter.Instance;
                        return true;
                    }

                    // otherwise
                    converter = null;
                    return false;
            }
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attribute = member.GetCustomAttribute<FieldAttribute>(true);
            if(null != attribute && !string.IsNullOrEmpty(attribute.SerializeAs))
            {
                property.PropertyName = attribute.SerializeAs;
                property.Readable = true;
                if(TryGetConverter(member as PropertyInfo, attribute, out var converter))
                    property.Converter = converter;
            } else
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}
