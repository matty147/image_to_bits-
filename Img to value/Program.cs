using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace Img_to_value
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> alphaList = new List<int>();
            Console.WriteLine("Please enter the path of the folder");
            string path = Console.ReadLine();
            Console.WriteLine("Please enter the number of images you would like to convert");
            int ImgNumber = int.Parse(Console.ReadLine()); //the files have to be named 1 - X to work
            Console.WriteLine("Please enter the file extencion");
            string extencion = Console.ReadLine();
            Console.WriteLine("Please enter the output destinacion");
            string outputDir = Console.ReadLine();
            Console.WriteLine("Do you want to receive inforamtion when the program finishes a picture? Y/N");
            string Info = Console.ReadLine();

            for (int CurentImg = 1; CurentImg <= ImgNumber; CurentImg++)
            {
                Bitmap image = new Bitmap($"{path}{CurentImg}{extencion}");

                int width = image.Width;
                int height = image.Height;
                Color pixelColor = image.GetPixel(1, 1);

                for (int h = 0; h < height; h++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        pixelColor = image.GetPixel(w, h);
                        int red = pixelColor.R;
                        int green = pixelColor.G;
                        int blue = pixelColor.B;
                        int alpha = pixelColor.A;
                        int add = (red + green + blue) / 3;
                        alphaList.Add(add);
                        //Console.WriteLine($"Pixel at ({w},{h}): R={red}, G={green}, B={blue}, A={alpha}");
                    }
                }
                
                string filePath = Path.Combine(outputDir, $"output{CurentImg}.txt");
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (int a in alphaList)
                    {
                        if (a >= 123) //200 is also good
                        {
                            writer.Write("1 ");
                        }
                        else writer.Write("0 ");
                    }
                }
                if  (Info == "Y" || Info == "y")
                {
                    Console.WriteLine($"Finished image: {CurentImg}");
                }
                alphaList.Clear();
                image.Dispose();
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
