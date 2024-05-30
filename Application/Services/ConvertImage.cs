using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;


namespace Application.Services
{
    public static class ConvertImage
    {
        public  async static Task<Image> ConvertBase64ToImage(string base64)
        {
            if (base64 is not null)
            {
                byte[] imageBytes = Convert.FromBase64String(base64);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    // Create an Image object from the MemoryStream
                    Image image = Image.FromStream(ms);
                    return image;
                }
            }
            return null;
        }
    }
}
