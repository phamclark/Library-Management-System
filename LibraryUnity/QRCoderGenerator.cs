using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static QRCoder.PayloadGenerator;

namespace LibraryUnity
{
    public class QRCoderGenerator
    {
        public static Bitmap BookFooterQR(string payload)
        {
            Bookmark generator = new Bookmark("http://code-bude.net", "Blog of QRCoder's father");
            payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

        public static string BarCodeConverter(Bitmap bImage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage); //Get Base64
            return SigBase64;
        }
    }
}
