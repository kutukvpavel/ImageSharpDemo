using SixLabors.ImageSharp;
using System;

namespace ImageSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageExporter.DrawRect(new Rectangle(0, 0, 1200, 1200), "0,t=0", -90);
        }
    }
}
