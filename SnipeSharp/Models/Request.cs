using System;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    /// <summary>
    /// A request for an asset or accessory or etc.
    /// </summary>
    public sealed class Request : ApiObject
    {
        /// <summary>The url for the image of the object.</summary>
        [Field(DeserializeAs = "image", Converter = FieldConverter.FalseyUriConverter)]
        public Uri ImageUri { get; private set; }

        /// <summary>The name of the request.</summary>
        /// <remarks>This is related to, but not identical to, the name of the requested object.</remarks>
        [Field(DeserializeAs = "name")]
        public string Name { get; private set; }

        /// <summary>What type the object is.</summary>
        // TODO: get a proper type for this
        [Field(DeserializeAs = "type")]
        public CategoryType Type { get; private set; }

        /// <summary>How many of the object there are.</summary>
        [Field(DeserializeAs = "qty")]
        public int Quantity { get; private set; }

        /// <summary>The name of the location the object is at.</summary>
        [Field(DeserializeAs = "location")]
        public string LocationName { get; private set; }

        /// <summary>The date to the object is expected to be checked back in.</summary>
        [Field(DeserializeAs = "expected_checkin", Converter = FieldConverter.DateTimeConverter)]
        public DateTime? ExpectedCheckIn { get; private set; }

        /// <summary>The date to the object was requested by the current account.</summary>
        [Field(DeserializeAs = "request_date", Converter = FieldConverter.DateTimeConverter)]
        public DateTime? RequestDate { get; private set; }
    }
}