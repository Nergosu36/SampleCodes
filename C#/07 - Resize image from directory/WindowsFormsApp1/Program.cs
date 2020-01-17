using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Program
    {
        static string inputdir, outputdir;
        static int width, height;
        static List<Image> images;
        static string[] files;
        public static List<Image> GetImages(string path)
        {
            List<Image> images = new List<Image>();
            files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            for(int i=0; i<files.Count(); i++)
            {
                images.Add(Image.FromFile(files[i]));
            }
            return images;
        }
        public static List<Bitmap> ResizeImage(List<Image> images, int width, int height)
        {
            List<Bitmap> rImages = new List<Bitmap>();
            for (int i = 0; i < images.Count(); i++)
            {
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(images[i].HorizontalResolution, images[i].VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(images[i], destRect, 0, 0, images[i].Width, images[i].Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
                rImages.Add(destImage);
            }
            return rImages;
        }
        public static void SaveImg(List<Bitmap> image)
        {
            for (int j = 0; j < image.Count(); j++)
            {
                string name = Path.GetFileNameWithoutExtension(files[j]);
                string ext = Path.GetExtension(files[j]);
                int i = 1;
                do
                {
                    if (!System.IO.File.Exists(outputdir + name + "." + ext))
                    {
                        image[j].Save(outputdir + name + "_" + i + ext);
                        break;
                    }
                    i++;
                } while (System.IO.File.Exists(outputdir + name + "_" + i + ext));
                image[j].Save(outputdir + name + "_" + i + ext);
            }
        }
        static void Main(string[] args)
        {
            if (args.Count() == 0)
                return;
            if (args.Count() >= 2)
            {
                if (args[0] == "-res")
                {
                    string[] res = args[1].Split('x');
                    width = Int32.Parse(res[0]);
                    height = Int32.Parse(res[1]);
                }
                inputdir = @".\Graphs\";
                outputdir = @".\Graphs\";
            }
            if (args.Count() == 4)
            {
                if (args[2] == "-inputdir")
                {
                    inputdir = args[3];
                    outputdir = @".\Graphs\";
                }
                else if (args[2] == "-outputdir")
                {
                    outputdir = args[3];
                    inputdir = @".\Graphs\";
                }
                else
                {
                    inputdir = @".\Graphs\";
                    outputdir = @".\Graphs\";
                }
            }
            else if (args.Count() == 6)
            {
                if (args[4] == "-inputdir")
                {
                    inputdir = args[5];
                    outputdir = @".\Graphs\";
                }
                else if (args[4] == "-outputdir")
                {
                    outputdir = args[5];
                    inputdir = @".\Graphs\";
                }
                else
                {
                    inputdir = @".\Graphs\";
                    outputdir = @".\Graphs\";
                }
                if (args[2] == "-inputdir")
                {
                    inputdir = args[3];
                    outputdir = @".\Graphs\";
                }
                else if (args[2] == "-outputdir")
                {
                    outputdir = args[3];
                    inputdir = @".\Graphs\";
                }
                else
                {
                    inputdir = @".\Graphs\";
                    outputdir = @".\Graphs\";
                }
            }
            else
                return;    

            images = GetImages(inputdir);
            List<Bitmap> rimages = ResizeImage(images, width, height);
            SaveImg(rimages);

            Console.ReadLine();
        }
    }
}

