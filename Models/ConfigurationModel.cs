using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.QRCode.Models;

/// <summary>
/// Represents a configuration model for QR Code plugin
/// </summary>
public record ConfigurationModel : BaseNopModel
{
    public int ActiveStoreScopeConfiguration { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.Enabled")]
    public bool Enabled { get; set; }
    public bool Enabled_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.Size")]
    public int Size { get; set; }
    public bool Size_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.WidgetZone")]
    public string WidgetZone { get; set; }
    public bool WidgetZone_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.HintText")]
    public string HintText { get; set; }
    public bool HintText_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.ShowBorder")]
    public bool ShowBorder { get; set; }
    public bool ShowBorder_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.BorderColor")]
    public string BorderColor { get; set; }
    public bool BorderColor_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.BorderWidth")]
    public int BorderWidth { get; set; }
    public bool BorderWidth_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.BorderRadius")]
    public int BorderRadius { get; set; }
    public bool BorderRadius_OverrideForStore { get; set; }

    [NopResourceDisplayName("Plugins.Widgets.QRCode.BackgroundColor")]
    public string BackgroundColor { get; set; }
    public bool BackgroundColor_OverrideForStore { get; set; }

    public IList<SelectListItem> AvailableWidgetZones { get; set; } = new List<SelectListItem>();
}