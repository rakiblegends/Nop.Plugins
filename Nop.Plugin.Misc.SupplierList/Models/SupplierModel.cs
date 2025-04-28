using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.SupplierList.Models;

/// <summary>
/// Represents a supplier model
/// </summary>
public partial record SupplierModel : BaseNopEntityModel
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.Name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.Email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.PhoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.Address")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the supplier is active
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.IsActive")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.DisplayOrder")]
    public int DisplayOrder { get; set; } = 1;
} 