using System;
using Newtonsoft.Json;
using SnipeSharp.Models;

namespace SnipeSharp.Serialization
{
    internal sealed class CustomCommonModelConverter : JsonConverter
    {
        internal static readonly CustomCommonModelConverter Instance = new CustomCommonModelConverter();
        public override bool CanConvert(Type objectType)
            => true;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (reader.TokenType == JsonToken.StartObject) {
                return (CommonEndPointModel)serializer.Deserialize<GenericEndPointModel>(reader);
            }
            if(reader.TokenType == JsonToken.Integer) {
                return new GenericEndPointModel(Convert.ToInt32(reader.Value));
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = value as CommonEndPointModel;
            writer.WriteValue(item?.Id);
        }
    }
}
