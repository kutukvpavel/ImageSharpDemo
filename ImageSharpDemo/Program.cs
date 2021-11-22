using SixLabors.ImageSharp;
using System;

namespace ImageSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new PlottableRect(new Rectangle(0, 0, 1000, 1000))
            {
                Tag = "0,t=0",
                Color = Color.Blue
            };
            ImageExporter.DrawRect(new Rectangle(0, 0, 1200, 1200), example, -90);
        }
    }
}
