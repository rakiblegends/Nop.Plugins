using Nop.Core;
using Nop.Data;
using Nop.Plugin.Misc.SupplierList.Domain;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.SupplierList.Services;

/// <summary>
/// Supplier service
/// </summary>
public class SupplierService : ISupplierService
{
    #region Fields

    private readonly IRepository<Supplier> _supplierRepository;

    #endregion

    #region Ctor

    public SupplierService(IRepository<Supplier> supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    #endregion

    #region Methods

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
    public async Task<IPagedList<Supplier>> GetAllSuppliersAsync(string? name = null, string? email = null, string? phoneNumber = null, bool? isActive = null, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        var query = _supplierRepository.Table;

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(s => s.Name.Contains(name));

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(s => s.Email.Contains(email));

        if (!string.IsNullOrWhiteSpace(phoneNumber))
            query = query.Where(s => s.PhoneNumber.Contains(phoneNumber));

        if (isActive.HasValue)
            query = query.Where(s => s.IsActive == isActive.Value);

        query = query.OrderBy(s => s.DisplayOrder).ThenBy(s => s.Name);

        return await query.ToPagedListAsync(pageIndex, pageSize);
    }

    /// <summary>
    /// Gets a supplier by identifier
    /// </summary>
    /// <param name="supplierId">Supplier identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the supplier
    /// </returns>
    public async Task<Supplier> GetSupplierByIdAsync(int supplierId)
    {
        return await _supplierRepository.GetByIdAsync(supplierId);
    }

    /// <summary>
    /// Inserts a supplier
    /// </summary>
    /// <param name="supplier">Supplier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task InsertSupplierAsync(Supplier supplier)
    {
        await _supplierRepository.InsertAsync(supplier);
    }

    /// <summary>
    /// Updates a supplier
    /// </summary>
    /// <param name="supplier">Supplier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task UpdateSupplierAsync(Supplier supplier)
    {
        await _supplierRepository.UpdateAsync(supplier);
    }

    /// <summary>
    /// Deletes a supplier
    /// </summary>
    /// <param name="supplier">Supplier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task DeleteSupplierAsync(Supplier supplier)
    {
        await _supplierRepository.DeleteAsync(supplier);
    }

    /// <summary>
    /// Install the plugin
    /// </summary>
    public async Task InstallAsync()
    {
        await Task.CompletedTask;
    }

    /// <summary>
    /// Uninstall the plugin
    /// </summary>
    public async Task UninstallAsync()
    {
        await Task.CompletedTask;
    }

    #endregion
} 