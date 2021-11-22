using SixLabors.ImageSharp;

namespace ImageSharpDemo
{
    public class PlottableRect
    {
        public PlottableRect(Rectangle src)
        {
            _Rect = src;
        }

        private Rectangle _Rect;
        public Rectangle Rect
        {
            get => _Rect; //This accessor copies the Rectangle struct isolating _Rect
            protected set
            {
                _Rect = value;
            }
        }
        public Color Color { get; set; }
        public virtual string Tag { get; set; }
    }
}
