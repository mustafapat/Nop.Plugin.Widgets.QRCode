using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.QRCode;

public class QRCodeSettings : ISettings
{
    public bool Enabled { get; set; }
    public int Size { get; set; }
    public string WidgetZone { get; set; } = string.Empty;
    public string HintText { get; set; } = string.Empty;
    public bool ShowBorder { get; set; }
    public string BorderColor { get; set; } = string.Empty;
    public int BorderWidth { get; set; }
    public int BorderRadius { get; set; }
    public string BackgroundColor { get; set; } = string.Empty;
}