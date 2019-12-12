using System;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// GenericEndPointModel is a plain implementation of CommonEndPointModel.
    /// It is used for deserialization only.
    /// </summary>
    public sealed class GenericEndPointModel: CommonEndPointModel
    {
        /// <value>The internal Id of the object.</value>
        [Field("id")]
        public override int Id { get; protected set; }

        /// <value>The name of the object.</value>
        [Field(DeserializeAs = "name")]
        public override string Name { get; set; }

        /// <value>The creation date of this object in Snipe-IT.</value>
        [Field(DeserializeAs = "created_at", Converter = FieldConverter.DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        /// <value>The most recent date this object was modified in Snipe-IT.</value>
        [Field(DeserializeAs = "updated_at", Converter = FieldConverter.DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
    }
}
