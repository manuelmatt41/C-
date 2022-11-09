
namespace bol6_ejer4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImageInfo imageInfo = new ImageInfo("C:\\Users\\Manu\\Documents\\Sin título.bmp");
            InfoBMP info = imageInfo.InfoBMP();
            Console.WriteLine($"Size: {info.pixelWidth}x{info.pixelHeight}\nCompressed: {info.compressed}\nBits per pixel: {info.bitsPerPixel}");
        }
    }
}