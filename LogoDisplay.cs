using System;
using System.Drawing;
using System.IO;

namespace CyberSecurityBot_
{

    // constructor
    public class LogoDisplay
    {

        public void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("****************************************");
            Console.WriteLine("Cybersecurity Awareness Bot");
            Console.WriteLine("***************************************");
            Console.ResetColor();


        }

        public void DisplayAsciiLogo()
        {

            //get the full path 
            string path_project = AppDomain.CurrentDomain.BaseDirectory;

            //then replace the bin\\Debug\\
            string new_path_project = path_project.Replace("bin\\Debug\\", "");

            //then combine the project ful path and the image name with format 
            string full_path = Path.Combine(new_path_project, "cyber-security-logo.jpeg");

            //then start working on the logo 
            //with the ASCII 

            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(100, 50));

            //for loop, for inner and the outer nested 
            for (int height = 0; height < image.Height; height++)  
            {
                //then now work on the width 
                for (int width = 0; width < image.Width; width++) 

                {
                    
                    // now lets work on the asci design 
                    Color pixelColor = image.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    //now make use of the char 
                    char ascii_design = color < 100 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@' ;
                    Console.Write(ascii_design);//output the design 
                }// end of the for loop for the inner 
                Console.WriteLine();//skip the line 
            }// end of the for loop outer  


        }

    }
}


