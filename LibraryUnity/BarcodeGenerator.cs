using KeepAutomation.Barcode;
using KeepAutomation.Barcode.Crystal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace LibraryUnity
{
    public static class BarcodeGenerator
    {
        public static Bitmap ISBN(string isbnInput)
        {
            BarCode isbn = new BarCode();
            isbn.Symbology = KeepAutomation.Barcode.Symbology.ISBN;

            // Set ISBN valid encoding data: 12 numeric digits, stat with "978" or "979".
            isbn.CodeToEncode = isbnInput;

            // Apply checksum for ISBN barcode. 
            isbn.ChecksumEnabled = true;

            // Display ISBN checksum in the human-readable text      
            isbn.DisplayChecksum = true;

            // ISBN unit of measure, Pixel, Cm and Inch supported.
            isbn.BarcodeUnit = BarcodeUnit.Pixel;

            // ISBN image resolution in DPI.
            isbn.DPI = 72;

            // ISBN module bar width, ie. Width of the narrowest bar (X dimention), default is 1 pixel.
            isbn.X = 3;

            // ISBN module bar height (Y dimention)
            isbn.Y = 60;

            // ISBN margin size, a 10X space is automatically added according to specification.
            isbn.LeftMargin = 0;
            isbn.RightMargin = 0;
            isbn.TopMargin = 0;
            isbn.BottomMargin = 0;

            // ISBN image orientation: 0, 90, 180, 270 degrees supported
            isbn.Orientation = KeepAutomation.Barcode.Orientation.Degree0;

            // Display human readable text        
            isbn.DisplayText = true;
            isbn.TextFont = new Font("Arial", 10f, FontStyle.Regular);
            isbn.TextMargin = 6;

            // Print ISBN barcodes in Png, Jpeg, Gif, Tiff, Bmp, etc. image formats.
            isbn.ImageFormat = ImageFormat.Png;

            // Generate and save ISBN barcodes to image format
            //isbn.generateBarcodeToImageFile("D://barcode-isbn-csharp.gif");

            // Generate ISBN barcodes & encode to System.Drawing.Bitmap object 
            Bitmap barcodeInBitmap = isbn.generateBarcodeToBitmap();

            return barcodeInBitmap;
        }
    }
}
