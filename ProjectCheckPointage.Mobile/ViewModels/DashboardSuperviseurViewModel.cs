using CommunityToolkit.Mvvm.ComponentModel;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckPointage.Mobile.ViewModels
{
    public partial class DashboardSuperviseurViewModel: ObservableObject
    {
        [ObservableProperty]
        private ImageSource qrCodeImage;
        public DashboardSuperviseurViewModel()
        {
            // Génère un QR Code avec ID superviseur, zone, date
            GenerateQrCode("SUP-001|ZONE-A|" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
        }

        private void GenerateQrCode(string content)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            var qrCodeBytes = qrCode.GetGraphic(10);

            qrCodeImage = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
        }
    }
}
