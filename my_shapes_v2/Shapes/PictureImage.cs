using System;
using System.Drawing;

namespace Shapes
{
    public class PictureImage
    {
        public Bitmap bitmap;
        public int id;

        public PictureImage(string filepath)
        {
            bitmap = new Bitmap(filepath);
        }

        public PictureImage(Type type, string resource)
        {
            bitmap = new Bitmap(type, resource);
        }
    }
}
