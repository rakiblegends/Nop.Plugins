using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Plugin.Misc.SupplierList.Models;
using Nop.Plugin.Misc.SupplierList.Services;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Framework.Models.Extensions;
using Nop.Web.Framework.Mvc;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Plugin.Misc.SupplierList.Domain;

namespace Nop.Plugin.Misc.SupplierList.Controllers
{
    [AuthorizeAdmin]
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class SupplierListController : BaseAdminController
    {
        private readonly ISupplierService _supplierService;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;

        public SupplierListController(
            ISupplierService supplierService,
            INotificationService notificationService,
            ILocalizationService localizationService)
        {
            _supplierService = supplierService;
            _notificationService = notificationService;
            _localizationService = localizationService;
        }

        public virtual IActionResult Configure()
        {
            var model = new SupplierSearchModel();
            return View("~/Plugins/Misc.SupplierList/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> List(SupplierSearchModel searchModel)
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync(
                name: searchModel.Name,
                email: searchModel.Email,
                phoneNumber: searchModel.PhoneNumber,
                isActive: searchModel.IsActive,
                pageIndex: searchModel.Page - 1,
                pageSize: searchModel.PageSize);

            var model = new SupplierListModel().PrepareToGrid(searchModel, suppliers, () =>
            {
                return suppliers.Select(x => new SupplierModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    IsActive = x.IsActive,
                    DisplayOrder = x.DisplayOrder
                });
            });

            return Json(model);
        }

        public virtual IActionResult Create()
        {
            var model = new SupplierModel
            {
                IsActive = true,
                DisplayOrder = 1
            };

            return View("~/Plugins/Misc.SupplierList/Views/Create.cshtml", model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(SupplierModel model, bool save)
        {
            if (ModelState.IsValid)
            {
                var supplier = new Supplier
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    IsActive = model.IsActive,
                    DisplayOrder = model.DisplayOrder
                };

                await _supplierService.InsertSupplierAsync(supplier);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Misc.SupplierList.Added"));

                if (save)
                    return RedirectToAction(nameof(Configure));

                return RedirectToAction(nameof(Edit), new { id = supplier.Id });
            }

            return View("~/Plugins/Misc.SupplierList/Views/Create.cshtml", model);
        }

        public virtual async Task<IActionResult> Edit(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return RedirectToAction(nameof(Configure));

            var model = new SupplierModel
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Email = supplier.Email,
                PhoneNumber = supplier.PhoneNumber,
                Address = supplier.Address,
                IsActive = supplier.IsActive,
                DisplayOrder = supplier.DisplayOrder
            };

            return View("~/Plugins/Misc.SupplierList/Views/Edit.cshtml", model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(SupplierModel model, bool save)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(model.Id);
            if (supplier == null)
                return RedirectToAction(nameof(Configure));

            if (ModelState.IsValid)
            {
                supplier.Name = model.Name;
                supplier.Email = model.Email;
                supplier.PhoneNumber = model.PhoneNumber;
                supplier.Address = model.Address;
                supplier.IsActive = model.IsActive;
                supplier.DisplayOrder = model.DisplayOrder;

                await _supplierService.UpdateSupplierAsync(supplier);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Misc.SupplierList.Updated"));

                if (save)
                    return RedirectToAction(nameof(Configure));

                return RedirectToAction(nameof(Edit), new { id = supplier.Id });
            }

            return View("~/Plugins/Misc.SupplierList/Views/Edit.cshtml", model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return RedirectToAction(nameof(Configure));

            await _supplierService.DeleteSupplierAsync(supplier);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Misc.SupplierList.Deleted"));

            return RedirectToAction(nameof(Configure));
        }
    }
} 