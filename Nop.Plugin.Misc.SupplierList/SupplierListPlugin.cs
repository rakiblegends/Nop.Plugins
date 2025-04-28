using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Plugins;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework.Menu;
using Nop.Plugin.Misc.SupplierList.Services;

namespace Nop.Plugin.Misc.SupplierList
{
    public class SupplierListPlugin : BasePlugin, IMiscPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        private readonly ISupplierService _supplierService;

        #endregion

        #region Ctor

        public SupplierListPlugin(
            IWebHelper webHelper,
            ILocalizationService localizationService,
            ISupplierService supplierService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
            _supplierService = supplierService;
        }

        #endregion

        #region Methods

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/SupplierList/Configure";
        }

        private async Task ManageLocaleResourcesAsync(bool remove = false)
        {
            if (remove)
            {
                await _localizationService.DeleteLocaleResourcesAsync("Plugins.Misc.SupplierList");
                return;
            }

            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.PageTitle", "Supplier List");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.AddNewSupplier", "Add new supplier");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.BackToList", "Back to plugin list");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.Fields.Name", "Name");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.Fields.Email", "Email");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.Fields.PhoneNumber", "Phone Number");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.Fields.Address", "Address");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.Fields.IsActive", "Is Active");
            await _localizationService.AddOrUpdateLocaleResourceAsync("Plugins.Misc.SupplierList.Fields.DisplayOrder", "Display Order");
        }

        public override async Task InstallAsync()
        {
            await _supplierService.InstallAsync();
            await ManageLocaleResourcesAsync();
            await base.InstallAsync();
        }

        public override async Task UninstallAsync()
        {
            await _supplierService.UninstallAsync();
            await ManageLocaleResourcesAsync(true);
            await base.UninstallAsync();
        }

        public override async Task UpdateAsync(string currentVersion, string targetVersion)
        {
            await _supplierService.InstallAsync();
            await ManageLocaleResourcesAsync();
            await base.UpdateAsync(currentVersion, targetVersion);
        }

        #endregion
    }
} 