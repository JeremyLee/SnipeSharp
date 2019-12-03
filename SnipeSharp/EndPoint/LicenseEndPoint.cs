using SnipeSharp.Models;

namespace SnipeSharp.EndPoint
{
    /// <summary>
    /// Provides additional methods for the License endpoint.
    /// </summary>
    public sealed class LicenseEndPoint : EndPoint<License>
    {
        /// <param name="api">The Api to grab the RequestManager from.</param>
        /// <exception cref="SnipeSharp.Exceptions.MissingRequiredAttributeException">When the type parameter does not have the <see cref="PathSegmentAttribute">PathSegmentAttribute</see> attribute.</exception>
        internal LicenseEndPoint(SnipeItApi api) : base(api) {}

        /// <summary>
        /// Get details for the license seats of a license.
        /// </summary>
        /// <param name="license">A license to get the details of.</param>
        /// <returns>A ResponseCollection of LicenseSeats.</returns>
        /// <exception cref="SnipeSharp.Exceptions.ApiErrorException">If there was an error accessing the API, or the license does not exist.</exception>
        public ResponseCollection<LicenseSeat> GetSeats(License license)
            => Api.RequestManager.GetAll<LicenseSeat>($"{EndPointInfo.BaseUri}/{license.Id}/seats").RethrowExceptionIfAny().Value;
    }
}
