using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageSharpDemo
{
    public static class ImageExporter
    {
        public static Font TagFont { get; set; } = new Font(SystemFonts.Get("Arial"), 200);

        public static void DrawRect(Rectangle bounds, string tag, float tagRotation)
        {
            using Image<Rgba32> image = new Image<Rgba32>(bounds.Width, bounds.Height, Color.Black);

            var textPoint = RectangleF.Center(bounds);
            var rdo = new DrawingOptions { Transform = Matrix3x2Extensions.CreateRotationDegrees(tagRotation, textPoint) };
            image.Mutate(x =>
            {
                x.DrawText(rdo, tag, TagFont, Color.White, textPoint);
            });

            //Optional
            var tMeasure = TextMeasurer.Measure(tag, new TextOptions(TagFont));
            image.Mutate(x =>
            {
                x.Draw(rdo, Color.White, 5.0f, new RectangleF(textPoint, new SizeF(tMeasure.Width, tMeasure.Height)));
            });

            image.SaveAsPng("result.png");
        }
    }
}
