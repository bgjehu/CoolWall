using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Net;
using System.IO;

namespace CoolWall.Class
{
    public static class ExtensionMethods
    {
        public static string[] SubItems(this string[] items, int beginningIndex, int endingIndex)
        {
            if (endingIndex >= beginningIndex)
            {
                string[] subItems = new string[endingIndex - beginningIndex + 1];
                for (int i = beginningIndex; i <= endingIndex; i++)
                {
                    subItems[i - beginningIndex] = items[i];
                }
                return subItems;
            }
            else
            {
                return null;
            }
        }
        public static string[] SubItems(this string[] items, int beginningIndex)
        {
            int endingIndex = items.Length - 1;
            return items.SubItems(beginningIndex, endingIndex);
        }
        public static void SafeSave(this Image image, string fileName)
        {
            using(Bitmap bmp = new Bitmap(image.Width, image.Height))
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
                //  fileName is Uri
                //  Download image
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileName);
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
            else
            {
                //  fileName is not Uri
                try
                {
                    //  Try open the file into filestream
                    //  Try load image from stream
                    using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        return  Image.FromStream(stream);
                    }
                }
                catch (Exception) { return null; }
            }
        }
    }
}
