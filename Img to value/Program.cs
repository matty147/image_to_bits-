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
        public static void Color(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            List<int> alphaList = new List<int>();
            Console.WriteLine("Please enter the path of the folder");
            string path = Console.ReadLine();
            Console.WriteLine("Please enter the number of img you would like to convert");
            int ImgNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the file extencion");
            string extencion = Console.ReadLine();
            for (int CurentImg = 1; CurentImg <= ImgNumber; CurentImg++)
            {
                Bitmap image = new Bitmap($"{path}{CurentImg}{extencion}");

                int width = image.Width;
                int height = image.Height;
                int white = 0;
                int black = 0;
                Color pixelColor = image.GetPixel(1, 1);

                for (int h = 0; h < height; h++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        pixelColor = image.GetPixel(w, h);
                        int red = pixelColor.R; //for fun not acualy used
                        int green = pixelColor.G;
                        int blue = pixelColor.B;
                        int alpha = pixelColor.A;
                        //Console.WriteLine($"Pixel at ({w},{h}): R={red}, G={green}, B={blue}, A={alpha}");
                        alphaList.Add(red);
                        //Console.WriteLine(alpha + " " + red + " " + green + " " + blue);
                        if (red == 0 || blue == 0 || green == 0)
                        {
                            black++;
                        } else white++;
                    }
                }
                string directoryPath = @"c:\Users\matty\Source\repos\.bin\";
                string filePath = Path.Combine(directoryPath, $"output{CurentImg}.txt");
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (int a in alphaList)
                    {
                        if (a == 0)
                        {
                            writer.Write("0 ");
                        }
                        else writer.Write("1 ");
                    }
                }
                alphaList.Clear();
                image.Dispose();
            }
            //Console.WriteLine("-------------------------");
            //Console.WriteLine("White: " + white);
            //Console.WriteLine("Black: " + black);
            //Console.WriteLine("* " + height * width);
            Console.WriteLine("Finished");
            Console.ReadKey();

        }
    }
}
