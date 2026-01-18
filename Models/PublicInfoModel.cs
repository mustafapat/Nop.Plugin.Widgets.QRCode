using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.QRCode.Models;

/// <summary>
/// Represents a public info model for QR code widget
/// </summary>
public record PublicInfoModel : BaseNopModel
{
    public string QRCodeBase64 { get; set; } = string.Empty;
    public int Size { get; set; } = 150;
    public string ProductUrl { get; set; } = string.Empty;
    public string HintText { get; set; } = string.Empty;
    public bool ShowBorder { get; set; } = true;
    public string BorderColor { get; set; } = "#dddddd";
    public int BorderWidth { get; set; } = 1;
    public int BorderRadius { get; set; } = 8;
    public string BackgroundColor { get; set; } = "#ffffff";
}