using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace CoolWall.Class
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get file by the filename, and return integer representing image formats.
        /// </summary>
        /// <param name="fileName">fileName of the file</param>
        /// <returns>[JPEG return 1][BTP return 2][PNG return 3][Other File return 0][No File return -1][Other Error return -2]</returns>
        public static int IsImageFile(this string fileName)
        {
            /*
             * JPEG         return  1
             * BTP          return  2
             * PNG          return  3
             * Other File   return  0
             * No File      return  -1
             * Other Error  return  -2
             */
            if (File.Exists(fileName)) { /* Do Nothing  */}
            else { return -1; }

            try
            {
                byte[] bytes = File.ReadAllBytes(fileName);
                if (bytes[0] == 0xFF && bytes[1] == 0xD8) { return 1; }
                else if (bytes[0] == 0x42 && bytes[1] == 0x4D) { return 2; }
                else if (bytes[0] == 0x89 && bytes[1] == 0x50 && bytes[2] == 0x4E && bytes[3] == 0x47
                    && bytes[4] == 0x0D && bytes[5] == 0x0A && bytes[6] == 0x1A && bytes[7] == 0x0A) { return 3; }
                else { return 0; }
            }
            catch (Exception) { return -2; }
        }

        public static Image NullImage { get { return "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".ToImage(); } }
        public static Image ErrorImage { get { return "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".ToImage(); } }
        public static Image ToImage(this string base64Str)
        {
            try
            {
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64Str);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            catch (Exception) { return ExtensionMethods.ErrorImage; }
        }

        public static string ToImageString(this Image image, ImageFormat format)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = new Bitmap(image))
                    {
                        // Convert Image to byte[]
                        bmp.Save(ms, format);
                        byte[] imageBytes = ms.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }
            }
            catch (Exception) { return null; }
        }

        public static string ToImageString(this Image image)
        {
            if (image != null)
            {
                ImageFormat format;
                switch (ImageCodecInfo.GetImageEncoders().First(i => i.FormatID == image.RawFormat.Guid).MimeType)
                {
                    case "image/jpeg":
                        format = ImageFormat.Jpeg;
                        break;
                    case "image/bmp":
                        format = ImageFormat.Bmp;
                        break;
                    case "image/png":
                        format = ImageFormat.Png;
                        break;
                    default:
                        format = null;
                        break;
                }
                return image.ToImageString(format);
            }
            else { return null; }
        }

        public static Size Zoom(this Size size, double magRate)
        {
            int newWidth = Convert.ToInt32(size.Width * magRate);
            int newHeight = Convert.ToInt32(size.Height * magRate);
            Size newSize = new Size(newWidth, newHeight);
            return newSize;
        }
        public static void SafeSave(this Image image, string fileName)
        {
            using (Bitmap bmp = new Bitmap(image.Width, image.Height))
            {
                using (Graphics copy = Graphics.FromImage(bmp))
                {
                    copy.DrawImage(image, 0, 0);
                    image.Dispose();
                    bmp.Save(fileName);
                }
            }
        }
        public static Image GetImage(this string fileName)
        {
            if (Uri.IsWellFormedUriString(fileName, UriKind.Absolute))
            {
                try
                {
                    //  fileName is Uri
                    //  Download image
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileName);
                    //request.Timeout = 150000;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    // Check that the remote file was found. The ContentType
                    // check is performed since a request for a non-existent
                    // image file might be redirected to a 404-page, which would
                    // yield the StatusCode "OK", even though the image was not
                    // found.
                    if ((response.StatusCode == HttpStatusCode.OK ||
                        response.StatusCode == HttpStatusCode.Moved ||
                        response.StatusCode == HttpStatusCode.Redirect) &&
                        response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
                    {
                        return Image.FromStream(response.GetResponseStream());
                    }
                    else { return null; }
                }
                catch (Exception) { return null; }
            }
            else
            {
                //  fileName is not Uri
                try
                {
                    //  Try open the file into filestream
                    //  Try load image from stream
                    using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(stream);
                    }
                }
                catch (Exception) { return null; }
            }
        }
        public static bool LargerThan(this Size lhs, Size rhs)
        {
            if (lhs.Width >= rhs.Width && lhs.Height >= rhs.Height) { return true; }
            else { return false; }
        }
        public static bool SmallerThan(this Size lhs, Size rhs)
        {
            if (lhs.Width <= rhs.Width && lhs.Height <= rhs.Height) { return true; }
            else { return false; }
        }
    }
}
