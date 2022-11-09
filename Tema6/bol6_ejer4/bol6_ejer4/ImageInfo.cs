using System;

namespace bol6_ejer4
{
    public class ImageInfo
    {
        public ImageInfo(String path)
        {
            this.Path = path;
        }

        public bool IsBMP()
        {
            if (!File.Exists(Path))
            {
                return false;
            }
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(Path, FileMode.Open)))
                {
                    if (new string(br.ReadChars(2)) != "BM")
                    {
                        return false;
                    }
                    if (new FileInfo(Path).Length != br.ReadInt32())
                    {
                        return false;
                    }
                    br.BaseStream.Seek(0x0E, SeekOrigin.Begin);
                    if (br.ReadInt32() != 40)
                    {
                        return false;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return true;
        }

        public InfoBMP InfoBMP()
        { 
            if (!IsBMP())
            {
                throw new ArgumentException("Is not a BMP file");
            }
            InfoBMP infoBMP;
            using (BinaryReader br = new BinaryReader(new FileStream(Path, FileMode.Open)))
            {
                br.BaseStream.Seek(0x12, SeekOrigin.Begin);
                infoBMP.pixelWidth = br.ReadInt32();
                infoBMP.pixelHeight = br.ReadInt32();
                br.BaseStream.Seek(0x1E, SeekOrigin.Begin);
                infoBMP.compressed = br.ReadInt32() > 0;
                br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
                infoBMP.bitsPerPixel = br.ReadInt16();
            }
            return infoBMP;
        }

        public string Path;
    }

    public struct InfoBMP
    {
        public int pixelWidth;
        public int pixelHeight;
        public bool compressed;
        public short bitsPerPixel;

    }
}
