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

    [CheckPermission(StandardPermission.Configuration.MANAGE_WIDGETS)]
    public async Task<IActionResult> Configure()
    {
        var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
        var settings = await _settingService.LoadSettingAsync<QRCodeSettings>(storeScope);

        var model = new ConfigurationModel
        {
            Enabled = settings.Enabled,
            Size = settings.Size,
            WidgetZone = settings.WidgetZone,
            HintText = settings.HintText,
            ShowBorder = settings.ShowBorder,
            BorderColor = settings.BorderColor,
            BorderWidth = settings.BorderWidth,
            BorderRadius = settings.BorderRadius,
            BackgroundColor = settings.BackgroundColor,
            ActiveStoreScopeConfiguration = storeScope
        };

        // Widget zone seçenekleri
        model.AvailableWidgetZones = new List<SelectListItem>
        {
            new() { Text = await _localizationService.GetResourceAsync("Plugins.Widgets.QRCode.WidgetZone.OverviewTop"), Value = PublicWidgetZones.ProductDetailsOverviewTop },
            new() { Text = await _localizationService.GetResourceAsync("Plugins.Widgets.QRCode.WidgetZone.OverviewBottom"), Value = PublicWidgetZones.ProductDetailsOverviewBottom },
            new() { Text = await _localizationService.GetResourceAsync("Plugins.Widgets.QRCode.WidgetZone.BeforePictures"), Value = PublicWidgetZones.ProductDetailsBeforePictures },
            new() { Text = await _localizationService.GetResourceAsync("Plugins.Widgets.QRCode.WidgetZone.AfterPictures"), Value = PublicWidgetZones.ProductDetailsAfterPictures }
        };

        if (storeScope > 0)
        {
            model.Enabled_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Enabled, storeScope);
            model.Size_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.Size, storeScope);
            model.WidgetZone_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.WidgetZone, storeScope);
            model.HintText_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.HintText, storeScope);
            model.ShowBorder_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.ShowBorder, storeScope);
            model.BorderColor_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BorderColor, storeScope);
            model.BorderWidth_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BorderWidth, storeScope);
            model.BorderRadius_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BorderRadius, storeScope);
            model.BackgroundColor_OverrideForStore = await _settingService.SettingExistsAsync(settings, x => x.BackgroundColor, storeScope);
        }

        return View("~/Plugins/Widgets.QRCode/Views/Configure.cshtml", model);
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