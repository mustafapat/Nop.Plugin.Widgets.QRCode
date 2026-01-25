using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Plugin.Widgets.QRCode.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.QRCode.Controllers;

[Area(AreaNames.ADMIN)]
[AuthorizeAdmin]
[AutoValidateAntiforgeryToken]
public class WidgetsQRCodeController : BasePluginController
{
    private readonly ILocalizationService _localizationService;
    private readonly INotificationService _notificationService;
    private readonly IPermissionService _permissionService;
    private readonly ISettingService _settingService;
    private readonly IStoreContext _storeContext;

    public WidgetsQRCodeController(
        ILocalizationService localizationService,
        INotificationService notificationService,
        IPermissionService permissionService,
        ISettingService settingService,
        IStoreContext storeContext)
    {
        _localizationService = localizationService;
        _notificationService = notificationService;
        _permissionService = permissionService;
        _settingService = settingService;
        _storeContext = storeContext;
    }

    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Configure(ConfigurationModel model)
    {
        var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        var settings = await _settingService.LoadSettingAsync<QRCodeSettings>(storeScope);

        settings.Enabled = model.Enabled;
        settings.Size = model.Size;
        settings.WidgetZone = model.WidgetZone;
        settings.HintText = model.HintText;
        settings.ShowBorder = model.ShowBorder;
        settings.BorderColor = model.BorderColor;
        settings.BorderWidth = model.BorderWidth;
        settings.BorderRadius = model.BorderRadius;
        settings.BackgroundColor = model.BackgroundColor;

        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Enabled, model.Enabled_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Size, model.Size_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.WidgetZone, model.WidgetZone_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.HintText, model.HintText_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.ShowBorder, model.ShowBorder_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BorderColor, model.BorderColor_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BorderWidth, model.BorderWidth_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BorderRadius, model.BorderRadius_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BackgroundColor, model.BackgroundColor_OverrideForStore, storeScope, true);

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

        return await Configure();
    }

    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Configure(ConfigurationModel model)
    {
        var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        var settings = await _settingService.LoadSettingAsync<QRCodeSettings>(storeScope);

        settings.Enabled = model.Enabled;
        settings.Size = model.Size;
        settings.WidgetZone = model.WidgetZone;
        settings.HintText = model.HintText;
        settings.ShowBorder = model.ShowBorder;
        settings.BorderColor = model.BorderColor;
        settings.BorderWidth = model.BorderWidth;
        settings.BorderRadius = model.BorderRadius;
        settings.BackgroundColor = model.BackgroundColor;

        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Enabled, model.Enabled_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Size, model.Size_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.WidgetZone, model.WidgetZone_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.HintText, model.HintText_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.ShowBorder, model.ShowBorder_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BorderColor, model.BorderColor_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BorderWidth, model.BorderWidth_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BorderRadius, model.BorderRadius_OverrideForStore, storeScope, false);
        await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BackgroundColor, model.BackgroundColor_OverrideForStore, storeScope, false);

        await _settingService.ClearCacheAsync();

        _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

        return await Configure();
    }
}