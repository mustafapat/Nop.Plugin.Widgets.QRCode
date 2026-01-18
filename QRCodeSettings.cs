using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.QRCode;

/// <summary>
/// Represents QR Code plugin settings
/// </summary>
public class QRCodeSettings : ISettings
{
    /// <summary>
    /// Gets or sets a value indicating whether the widget is enabled
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the QR code size in pixels
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Gets or sets the widget zone where QR code should be displayed
    /// </summary>
    public string WidgetZone { get; set; }

    /// <summary>
    /// Gets or sets the hint text displayed below QR code
    /// </summary>
    public string HintText { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show border
    /// </summary>
    public bool ShowBorder { get; set; }

    /// <summary>
    /// Gets or sets the border color (hex)
    /// </summary>
    public string BorderColor { get; set; }

    /// <summary>
    /// Gets or sets the border width in pixels
    /// </summary>
    public int BorderWidth { get; set; }

    /// <summary>
    /// Gets or sets the border radius in pixels
    /// </summary>
    public int BorderRadius { get; set; }

    /// <summary>
    /// Gets or sets the background color (hex)
    /// </summary>
    public string BackgroundColor { get; set; }
}