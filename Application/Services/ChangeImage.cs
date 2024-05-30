using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Application.Services
{
    public static class ChangeImage
    {
        public static async Task<Image> ResizeSize(Image image, int size)
        {
            var width = size;
            var height = size;
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
    
        public static async Task<Image> BlurImage(Image image,int blurSize)
        { 
            Bitmap blurred = new Bitmap(image.Width, image.Height);


            using (Graphics graphics = Graphics.FromImage(blurred))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }


            for (int xx = 0; xx < blurred.Width; xx++)
            {
                for (int yy = 0; yy < blurred.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    for (int x = xx; (x < xx + blurSize && x < blurred.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < blurred.Height); y++)
                        {
                            Color pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    for (int x = xx; (x < xx + blurSize && x < blurred.Width); x++)
                    {
                        for (int y = yy; (y < yy + blurSize && y < blurred.Height); y++)
                        {
                            blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                        }
                    }
                }
            }

            return blurred;
        }

        public static async Task<Image> RadiusImage(Image image, int cornerRadius)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap roundedImage = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(roundedImage);

            graphics.Clear(Color.Transparent);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); 
                path.AddArc(width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); 
                path.AddArc(width - cornerRadius, height - cornerRadius, cornerRadius, cornerRadius, 0, 90); 
                path.AddArc(0, height - cornerRadius, cornerRadius, cornerRadius, 90, 90); 
                path.CloseAllFigures();

                using (TextureBrush brush = new TextureBrush(image))
                {
                    graphics.FillPath(brush, path);
                }
            }

            return roundedImage;
        }
    

        public static async Task<Image> Effect1Image(Image image)
        {
            //Doing effect1
            //
            return image;
        }

    }
}
