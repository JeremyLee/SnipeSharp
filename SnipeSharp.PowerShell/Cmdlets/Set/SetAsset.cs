using System;
using System.Collections.Generic;
using System.Management.Automation;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;
using SnipeSharp.Models.Enumerations;
using SnipeSharp.PowerShell.BindingTypes;
using SnipeSharp.PowerShell.Attributes;

namespace SnipeSharp.PowerShell.Cmdlets
{
    /// <summary>Changes the properties of an existing Snipe-IT asset.</summary>
    /// <remarks>The Set-Asset cmdlet changes the properties of an existing Snipe-IT asset object.</remarks>
    /// <example>
    ///   <code>Set-Asset -AssetTag '06514' -Status 'Retired'</code>
    ///   <para>Changes the status of the asset with the asset tag "06541" to "Retired".</para>
    /// </example>
    [Cmdlet(VerbsCommon.Set, nameof(Asset), SupportsShouldProcess = true, DefaultParameterSetName = nameof(SetObject<Asset, AssetBinding>.ParameterSets.ByIdentity))]
    [OutputType(typeof(Asset))]
    public sealed class SetAsset: SetObject<Asset, AssetBinding>
    {
        /// <summary>
        /// Extra parameter sets this cmdlet supports.
        /// </summary>
        internal enum AssetParameterSets
        {
            ByAssetTag,
            BySerial
        }

        /// <summary>The asset tag of the asset to update.</summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(AssetParameterSets.ByAssetTag))]
        [ValidateNotNullOrEmpty]
        public string AssetTag { get; set; }

        /// <summary>The serial number of the asset to update.</summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = nameof(AssetParameterSets.BySerial))]
        [ValidateNotNullOrEmpty]
        public string Serial { get; set; }

        /// <summary>
        /// The updated asset tag of the asset.
        /// </summary>
        [Parameter]
        public string NewAssetTag { get; set; }

        /// <summary>
        /// The updated name of the asset.
        /// </summary>
        [Parameter]
        public string NewName { get; set; }

        /// <summary>
        /// The updated serial number of the asset.
        /// </summary>
        [Parameter]
        public string NewSerial { get; set; }

        /// <summary>
        /// The updated model of the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<Model> Model { get; set; }

        /// <summary>
        /// The updated status label of the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<StatusLabel> Status { get; set; }

        /// <summary>
        /// The updated supplier for the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<Supplier> Supplier { get; set; }

        /// <summary>
        /// Any notes for the asset.
        /// </summary>
        [Parameter]
        public string Notes { get; set; }

        /// <summary>
        /// The updated order number for the asset's purchase.
        /// </summary>
        [Parameter]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The updated owner company of the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<Company> Company { get; set; }

        /// <summary>
        /// The updated location of the asset.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> Location { get; set; }

        /// <summary>
        /// The updated default location the asset will return to when unassigned.
        /// </summary>
        [Parameter]
        public ObjectBinding<Location> DefaultLocation { get; set; }

        /// <summary>
        /// The updated uri of the image for the asset.
        /// </summary>
        [Parameter]
        public Uri ImageUri { get; set; }

        /// <summary>
        /// The updated assignee object.
        /// </summary>
        [Parameter(DontShow = true)]
        public CommonEndPointModel AssignedTo { get; set; }

        /// <summary>
        /// The updated assignee object type.
        /// </summary>
        [Parameter(DontShow = true)]
        public AssignedToType AssignedType { get; set; }

        /// <summary>
        /// The updated purchase date for the asset.
        /// </summary>
        [Parameter]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// The updated purchase cost for the asset.
        /// </summary>
        [Parameter]
        public decimal PurchaseCost { get; set; }

        /// <summary>
        /// The updated warranty period for the asset in months.
        /// </summary>
        [Parameter]
        public int WarrantyMonths { get; set; }

        /// <summary>
        /// Custom fields used by the asset's model's field set.
        /// </summary>
        [Parameter]
        public Dictionary<string, string> CustomFields { get; set; }

        /// <inheritdoc />
        protected override bool PopulateItem(Asset item)
        {
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewAssetTag)))
                item.AssetTag = NewAssetTag;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewName)))
                item.Name = NewName;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(NewSerial)))
                item.Serial = NewSerial;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Model)))
            {
                if(!GetSingleValue(Model, out var model))
                    return false;
                item.Model = model;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Status)))
            {
                if(!GetSingleValue(Status, out var status))
                    return false;
                item.Status = status.ToAssetStatus();
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Supplier)))
            {
                if(!GetSingleValue(Supplier, out var supplier))
                    return false;
                item.Supplier = supplier;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Notes)))
                item.Notes = Notes;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(OrderNumber)))
                item.OrderNumber = OrderNumber;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Company)))
            {
                if(!GetSingleValue(Company, out var company))
                    return false;
                item.Company = company;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(Location)))
            {
                if(!GetSingleValue(Location, out var location))
                    return false;
                item.Location = location;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(DefaultLocation)))
            {
                if(!GetSingleValue(DefaultLocation, out var defaultLocation))
                    return false;
                item.DefaultLocation = defaultLocation;
            }
            if(MyInvocation.BoundParameters.ContainsKey(nameof(ImageUri)))
                item.ImageUri = ImageUri;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AssignedTo)))
                item.AssignedTo = AssignedTo;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(AssignedType)))
                item.AssignedType = AssignedType;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseCost)))
                item.PurchaseCost = PurchaseCost;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(PurchaseDate)))
                item.PurchaseDate = PurchaseDate;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(WarrantyMonths)))
                item.WarrantyMonths = WarrantyMonths;
            if(MyInvocation.BoundParameters.ContainsKey(nameof(CustomFields)) && !(CustomFields is null)) {
                foreach(var pair in CustomFields) {
                    if (item.CustomFields.ContainsKey(pair.Key)) {
                        // We need to preserve the AssetCustomField object, since its Field property
                        // (the custom attribute internal identifier) isn't predictable.
                        item.CustomFields[pair.Key].Value = pair.Value;
                    } else {
                        // When updating an asset, the asset is first retrieved. Therefore, any custom fields assigned
                        // to the asset are already loaded in the CustomFields dictionary, even if they have no value.
                        // If Snipe-IT didn't return the custom field, it's not assigned to the asset model,
                        // and cannot be set.
                        throw new ArgumentException($"CustomAttribute '{pair.Key}' does not exist for this asset.");
                    }
                }
            }
            return true;
        }

        /// <inheritdoc />
        protected override AssetBinding GetBoundObject()
        {
            if(ParameterSetName == nameof(AssetParameterSets.ByAssetTag))
                return AssetBinding.FromTag(AssetTag);
            else
                return AssetBinding.FromSerial(Serial);
        }
    }
}
