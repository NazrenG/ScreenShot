using System;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing;

namespace ScreensShot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic key;
            int pictureCount = Convert.ToInt32(File.ReadAllText("../../../SavePictureCount.txt"));
            string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/ScreenShots";
            while (true)
            {
                Console.WriteLine("Press Enter for print screen:");
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (!(Directory.Exists($"{path}")))
                    {
                        Directory.CreateDirectory($@"{path}");
                    }
                    using (Bitmap bmp = new Bitmap(2200, 1200))
                    {
                        using (Graphics graphics =Graphics.FromImage(bmp))
                        {
                            Size size = new Size(bmp.Width, bmp.Height);
                            graphics.CopyFromScreen(0, 0, 0, 0, size);
                        }

                        string name = $"image({pictureCount}).png";
                        pictureCount++;
                        File.WriteAllText("../../../SavePictureCount.txt", $"{pictureCount}");
                        bmp.Save(Path.Combine(path, name),ImageFormat.Png);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("saved the picture");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }
            }
        }
    }
}