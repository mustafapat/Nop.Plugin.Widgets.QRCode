# QR Code Widget for NopCommerce

[![NopCommerce Version](https://img.shields.io/badge/nopCommerce-4.80-blue.svg)](https://www.nopcommerce.com)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

Display customizable QR codes on product detail pages for easy sharing between devices.

## ✨ Features

- **Automatic QR Code Generation**: Creates QR codes for product URLs automatically
- **Customizable Design**: Adjust size, colors, borders, and positioning
- **Multiple Widget Zones**: Choose from 4 different display positions on product pages
- **Multi-Store Support**: Different settings for each store
- **Mobile Friendly**: Responsive design that works on all devices
- **Performance Optimized**: Uses Base64 encoding for fast loading
- **Live Preview**: See changes in real-time in admin panel

## 🎯 Use Cases

- Retail stores bridging physical and online shopping
- B2B product catalogs for easy sharing
- Mobile-first shopping experiences
- Product demonstrations and exhibitions
- Print catalogs with scannable product links

## 📦 Installation

### Via NopCommerce Admin Panel

1. Download the latest release from [NopCommerce Marketplace](https://www.nopcommerce.com/qr-code-widget)
2. Login to your NopCommerce admin panel
3. Navigate to **Configuration → Local Plugins**
4. Click **"Upload plugin or theme"**
5. Select the downloaded ZIP file
6. Click **"Upload"**
7. Find "QR Code Widget" in the list and click **"Install"**
8. Restart your application if prompted

### Via Source Code

1. Clone this repository:
```bash
   git clone https://github.com/mustafapat/Nop.Plugin.Widgets.QRCode.git
```

2. Copy the plugin folder to your NopCommerce solution:
```
   YourNopCommerceSolution/src/Plugins/Nop.Plugin.Widgets.QRCode
```

3. Open your NopCommerce solution in Visual Studio
4. Right-click on the solution → **Add → Existing Project**
5. Select `Nop.Plugin.Widgets.QRCode.csproj`
6. Build the solution in **Release** mode
7. Install the plugin from admin panel

## ⚙️ Configuration

1. Go to **Configuration → Widgets**
2. Click **"Configure"** next to "QR Code Widget"
3. Adjust settings:
   - ✅ Enable/Disable widget
   - 📏 Set QR code size
   - 📍 Choose display position
   - 🎨 Customize colors and borders
   - 💬 Set hint text
4. Click **"Save"**

## 🛠️ Technical Details

- **NopCommerce Version**: 4.80
- **Framework**: .NET 9.0
- **QR Library**: QRCoder
- **Plugin Type**: Widget

## 📋 Requirements

- NopCommerce 4.80 or higher
- .NET 9.0 Runtime
- ASP.NET Core

## 🔧 Development

### Prerequisites

- Visual Studio 2022 or later
- .NET 9.0 SDK
- NopCommerce 4.80 source code

### Building from Source
```bash
# Clone the repository
git clone https://github.com/mustafapat/Nop.Plugin.Widgets.QRCode.git

# Open in Visual Studio
cd Nop.Plugin.Widgets.QRCode
start Nop.Plugin.Widgets.QRCode.csproj

# Build in Release mode
dotnet build -c Release
```

## 📝 Changelog

### Version 2.0.0 (2025-01-18)
- Initial release
- QR code generation for product pages
- Customizable size and positioning
- Border and color customization
- Multi-store support
- Turkish and English localization

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Mustafa - EduFabTech**

- Website: [https://edufabtech.com](https://edufabtech.com)
- GitHub: [@mustafapat](https://github.com/mustafapat)

## ⭐ Support

If you find this plugin helpful, please consider:
- ⭐ Starring this repository
- 🐛 Reporting bugs via [Issues](https://github.com/mustafapat/Nop.Plugin.Widgets.QRCode/issues)
- 💬 Sharing your feedback

## 📞 Contact

For support or questions, create an issue on GitHub or visit [EduFabTech.com](https://edufabtech.com)

---

Made with ❤️ by [EduFabTech](https://edufabtech.com)
