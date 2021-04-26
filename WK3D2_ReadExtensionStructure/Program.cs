using System;
using System.IO;
using System.Text;

namespace WK3D2_ReadExtensionStructure
{
    class Program
    {  
        static void Main(string[] args)
        {
            string fileName = @"/Users/hanans/Desktop/sample_640×426.bmp";
            byte[] signature = new byte[2];//0-1
            byte[] size = new byte[4];//2-5
            byte[] imageWidth = new byte[4];//18-21
            byte[] imageHeight = new byte[4];//22-25
            byte[] holder = new byte[4];

            using (FileStream fs = new FileStream(@"/Users/hanans/Desktop/sample_640×426.bmp", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(fs, new ASCIIEncoding()))
                {
                    signature = reader.ReadBytes(2);
                    size = reader.ReadBytes(4);
                    holder = reader.ReadBytes(4);
                    holder = reader.ReadBytes(4);
                    holder = reader.ReadBytes(4);
                    imageWidth = reader.ReadBytes(4);
                    imageHeight = reader.ReadBytes(4);

                    Console.WriteLine("Type: "+System.Text.Encoding.Default.GetString(signature));
                    Console.WriteLine("Size: " + BitConverter.ToInt32(size, 0));
                    Console.WriteLine("Width: " + BitConverter.ToInt32(imageWidth, 0));
                    Console.WriteLine("Height: " + BitConverter.ToInt32(imageHeight, 0));
                    
                  
                }
            }
        }
       
    }
}
