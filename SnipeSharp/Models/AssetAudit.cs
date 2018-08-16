using System;
using SnipeSharp.EndPoint;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.Models
{
    /// <summary>
    /// ApiObject for submitting Asset audits.
    /// </summary>
    /// <seealso cref="SnipeSharp.EndPoint.EndPointExtensions.Audit(EndPoint{Asset}, Asset, Location, DateTime?, string)"/>
    internal sealed class AssetAudit : ApiObject
    {
        /// <summary>
        /// The asset tag of the Asset being audited.
        /// </summary>
        /// <remarks>This field is required.</remarks>
        [Field("asset_tag", true, required: true)]
        public string AssetTag { get; set; }

        /// <summary>
        /// The audit location.
        /// </summary>
        [Field("location_id", true, converter: CommonModelConverter)]
        public Location Location { get; set; }

        /// <summary>
        /// The next scheduled audit date.
        /// </summary>
        [Field("next_audit_date", true, converter: DateTimeConverter)]
        public DateTime? NextAuditDate { get; set; }

        /// <summary>
        /// Notes for the audit log.
        /// </summary>
        [Field("note", true)]
        public string Note { get; set; }
    }
}