using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.SupplierList.Models;

/// <summary>
/// Represents a supplier search model
/// </summary>
public partial record SupplierSearchModel : BaseSearchModel
{
    #region Ctor

    public SupplierSearchModel()
    {
        Name = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the name
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.Name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.Email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.PhoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the supplier is active
    /// </summary>
    [NopResourceDisplayName("Plugins.Misc.SupplierList.Fields.IsActive")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to hide the search block
    /// </summary>
    public bool HideSearchBlock { get; set; }

    #endregion
} 