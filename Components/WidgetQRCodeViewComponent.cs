using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.QRCode.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;
using QRCoder;

namespace Nop.Plugin.Widgets.QRCode.Components;

public class WidgetQRCodeViewComponent : NopViewComponent
{
    private readonly IWebHelper _webHelper;
    private readonly ISettingService _settingService;
    private readonly IStoreContext _storeContext;

    public WidgetQRCodeViewComponent(
        IWebHelper webHelper,
        ISettingService settingService,
        IStoreContext storeContext)
    {
        _webHelper = webHelper;
        _settingService = settingService;
        _storeContext = storeContext;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        var store = await _storeContext.GetCurrentStoreAsync();
        var settings = await _settingService.LoadSettingAsync<QRCodeSettings>(store.Id);

        // Widget etkin değilse boş döndür
        if (!settings.Enabled)
            return Content(string.Empty);

        // Widget zone kontrolü
        if (!string.IsNullOrEmpty(settings.WidgetZone) && 
            !widgetZone.Equals(settings.WidgetZone, StringComparison.InvariantCultureIgnoreCase))
            return Content(string.Empty);

        var productUrl = _webHelper.GetThisPageUrl(true);

        var model = new PublicInfoModel
        {
            ProductUrl = productUrl,
            QRCodeBase64 = GenerateQRCode(productUrl, settings.Size > 0 ? settings.Size / 10 : 15),
            Size = settings.Size > 0 ? settings.Size : 150,
            HintText = !string.IsNullOrEmpty(settings.HintText) ? settings.HintText : "Scan to share",
            ShowBorder = settings.ShowBorder,
            BorderColor = !string.IsNullOrEmpty(settings.BorderColor) ? settings.BorderColor : "#dddddd",
            BorderWidth = settings.BorderWidth > 0 ? settings.BorderWidth : 1,
            BorderRadius = settings.BorderRadius >= 0 ? settings.BorderRadius : 8,
            BackgroundColor = !string.IsNullOrEmpty(settings.BackgroundColor) ? settings.BackgroundColor : "#ffffff"
        };

        return View("~/Plugins/Widgets.QRCode/Views/PublicInfo.cshtml", model);
    }

    private static string GenerateQRCode(string url, int pixelsPerModule)
    {
        if (string.IsNullOrEmpty(url))
            return string.Empty;

        try
        {
            using var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            
            // PngByteQRCode kullanın - platform bağımsız ve daha güvenilir
            using var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(pixelsPerModule);
            
            return $"data:image/png;base64,{Convert.ToBase64String(qrCodeImage)}";
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
}