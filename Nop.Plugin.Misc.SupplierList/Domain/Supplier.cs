using Nop.Core;

namespace Nop.Plugin.Misc.SupplierList.Domain;

/// <summary>
/// Represents a supplier
/// </summary>
public class Supplier : BaseEntity
{
    /// <summary>
    /// Gets or sets the name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the address
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the supplier is active
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
} 