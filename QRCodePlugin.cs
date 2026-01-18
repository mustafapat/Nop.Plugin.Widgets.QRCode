using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Plugin.Widgets.QRCode.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.QRCode;

/// <summary>
/// Represents the QR Code widget plugin
/// </summary>
public class QRCodePlugin : BasePlugin, IWidgetPlugin
{
    private readonly IActionContextAccessor _actionContextAccessor;
    private readonly ILocalizationService _localizationService;
    private readonly ISettingService _settingService;
    private readonly IUrlHelperFactory _urlHelperFactory;
    private readonly IWebHelper _webHelper;
    private readonly WidgetSettings _widgetSettings;

    public QRCodePlugin(
        IActionContextAccessor actionContextAccessor,
        ILocalizationService localizationService,
        ISettingService settingService,
        IUrlHelperFactory urlHelperFactory,
        IWebHelper webHelper,
        WidgetSettings widgetSettings)
    {
        _actionContextAccessor = actionContextAccessor;
        _localizationService = localizationService;
        _settingService = settingService;
        _urlHelperFactory = urlHelperFactory;
        _webHelper = webHelper;
        _widgetSettings = widgetSettings;
    }

    /// <summary>
    /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
    /// </summary>
    public bool HideInWidgetList => false;

    /// <summary>
    /// Gets a configuration page URL
    /// </summary>
    public override string GetConfigurationPageUrl()
    {
        return _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext)
            .RouteUrl(QRCodeDefaults.ConfigurationRouteName);
    }

    /// <summary>
    /// Gets widget zones where this widget should be rendered
    /// </summary>
    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string>
        {
            PublicWidgetZones.ProductDetailsOverviewTop,
            PublicWidgetZones.ProductDetailsOverviewBottom,
            PublicWidgetZones.ProductDetailsBeforePictures,
            PublicWidgetZones.ProductDetailsAfterPictures
        });
    }

    /// <summary>
    /// Gets a type of a view component for displaying widget
    /// </summary>
    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(WidgetQRCodeViewComponent);
    }

    /// <summary>
    /// Install the plugin
    /// </summary>
    public override async Task InstallAsync()
    {
        // Varsayılan ayarlar
        var settings = new QRCodeSettings
        {
            Enabled = true,
            Size = 150,
            WidgetZone = PublicWidgetZones.ProductDetailsOverviewTop,
            HintText = "Scan to share",
            ShowBorder = true,
            BorderColor = "#dddddd",
            BorderWidth = 1,
            BorderRadius = 8,
            BackgroundColor = "#ffffff"
        };
        await _settingService.SaveSettingAsync(settings);

        // Widget'ı aktif listeye ekle
        if (!_widgetSettings.ActiveWidgetSystemNames.Contains(QRCodeDefaults.SystemName))
        {
            _widgetSettings.ActiveWidgetSystemNames.Add(QRCodeDefaults.SystemName);
            await _settingService.SaveSettingAsync(_widgetSettings);
        }

        // Dil kaynakları
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["Plugins.Widgets.QRCode.Configuration"] = "QR Code Settings",
            ["Plugins.Widgets.QRCode.Enabled"] = "Enabled",
            ["Plugins.Widgets.QRCode.Enabled.Hint"] = "Check to enable QR code widget on product pages.",
            ["Plugins.Widgets.QRCode.Size"] = "Size (pixels)",
            ["Plugins.Widgets.QRCode.Size.Hint"] = "Set QR code size in pixels (e.g., 100, 150, 200).",
            ["Plugins.Widgets.QRCode.WidgetZone"] = "Display Position",
            ["Plugins.Widgets.QRCode.WidgetZone.Hint"] = "Select where to display QR code on the product page.",
            ["Plugins.Widgets.QRCode.WidgetZone.OverviewTop"] = "Product Overview - Top",
            ["Plugins.Widgets.QRCode.WidgetZone.OverviewBottom"] = "Product Overview - Bottom",
            ["Plugins.Widgets.QRCode.WidgetZone.BeforePictures"] = "Before Pictures",
            ["Plugins.Widgets.QRCode.WidgetZone.AfterPictures"] = "After Pictures",
            ["Plugins.Widgets.QRCode.HintText"] = "Hint Text",
            ["Plugins.Widgets.QRCode.HintText.Hint"] = "Text displayed below the QR code.",
            ["Plugins.Widgets.QRCode.ShowBorder"] = "Show Border",
            ["Plugins.Widgets.QRCode.ShowBorder.Hint"] = "Check to display a border around QR code.",
            ["Plugins.Widgets.QRCode.BorderColor"] = "Border Color",
            ["Plugins.Widgets.QRCode.BorderColor.Hint"] = "Set the border color using the color picker.",
            ["Plugins.Widgets.QRCode.BorderWidth"] = "Border Width (pixels)",
            ["Plugins.Widgets.QRCode.BorderWidth.Hint"] = "Set the border width in pixels (e.g., 1, 2, 3).",
            ["Plugins.Widgets.QRCode.BorderRadius"] = "Border Radius (pixels)",
            ["Plugins.Widgets.QRCode.BorderRadius.Hint"] = "Set the border radius for rounded corners (e.g., 0, 8, 16).",
            ["Plugins.Widgets.QRCode.BackgroundColor"] = "Background Color",
            ["Plugins.Widgets.QRCode.BackgroundColor.Hint"] = "Set the background color using the color picker."
        });

        await base.InstallAsync();
    }

    /// <summary>
    /// Uninstall the plugin
    /// </summary>
    public override async Task UninstallAsync()
    {
        // Ayarları sil
        await _settingService.DeleteSettingAsync<QRCodeSettings>();

        // Widget'ı aktif listeden kaldır
        if (_widgetSettings.ActiveWidgetSystemNames.Contains(QRCodeDefaults.SystemName))
        {
            _widgetSettings.ActiveWidgetSystemNames.Remove(QRCodeDefaults.SystemName);
            await _settingService.SaveSettingAsync(_widgetSettings);
        }

        // Dil kaynaklarını sil
        await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.QRCode");

        await base.UninstallAsync();
    }
}