using Nop.Services.Plugins;
using Nop.Web.Framework.Events;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.SupplierList.Services;

/// <summary>
/// Represents plugin event consumer
/// </summary>
public class EventConsumer : BaseAdminMenuCreatedEventConsumer
{
    public EventConsumer(IPluginManager<IPlugin> pluginManager) :
        base(pluginManager)
    {
    }

    /// <summary>
    /// Checks if the current customer has rights to access this menu item
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the true if access is granted, otherwise false
    /// </returns>
    protected override Task<bool> CheckAccessAsync()
    {
        return Task.FromResult(true);
    }

    /// <summary>
    /// Gets the plugin system name
    /// </summary>
    protected override string PluginSystemName => "Misc.SupplierList";

    /// <summary>
    /// The system name of the menu item before which we need to insert the current one
    /// </summary>
    protected override string BeforeMenuSystemName => "Configuration";

    /// <summary>
    /// Gets the menu item
    /// </summary>
    /// <param name="plugin">The instance of <see cref="IPlugin"/> interface</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the instance of <see cref="AdminMenuItem"/>
    /// </returns>
    protected override Task<AdminMenuItem> GetAdminMenuItemAsync(IPlugin plugin)
    {
        var descriptor = plugin.PluginDescriptor;

        return Task.FromResult(new AdminMenuItem
        {
            Visible = true,
            SystemName = descriptor.SystemName,
            Title = descriptor.FriendlyName,
            IconClass = "fas fa-truck",
            Url = plugin.GetConfigurationPageUrl()
        });
    }
} 