using Nop.Core;
using Nop.Plugin.Misc.SupplierList.Domain;
using Nop.Plugin.Misc.SupplierList.Models;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.SupplierList.Services;

/// <summary>
/// Supplier service interface
/// </summary>
public interface ISupplierService
{
    /// <summary>
    /// Gets all suppliers
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="email">Email</param>
    /// <param name="phoneNumber">Phone number</param>
    /// <param name="isActive">Is active</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the suppliers
    /// </returns>
    Task<IPagedList<Supplier>> GetAllSuppliersAsync(string? name = null, string? email = null, string? phoneNumber = null, bool? isActive = null, int pageIndex = 0, int pageSize = int.MaxValue);

    /// <summary>
    /// Gets a supplier by identifier
    /// </summary>
    /// <param name="supplierId">Supplier identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the supplier
    /// </returns>
    Task<Supplier> GetSupplierByIdAsync(int supplierId);

    /// <summary>
    /// Inserts a supplier
    /// </summary>
    /// <param name="supplier">Supplier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task InsertSupplierAsync(Supplier supplier);

    /// <summary>
    /// Updates a supplier
    /// </summary>
    /// <param name="supplier">Supplier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task UpdateSupplierAsync(Supplier supplier);

    /// <summary>
    /// Deletes a supplier
    /// </summary>
    /// <param name="supplier">Supplier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task DeleteSupplierAsync(Supplier supplier);

    /// <summary>
    /// Install the plugin
    /// </summary>
    Task InstallAsync();

    /// <summary>
    /// Uninstall the plugin
    /// </summary>
    Task UninstallAsync();
} 