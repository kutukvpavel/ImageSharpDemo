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

        public static void DrawRect(Rectangle bounds, PlottableRect pRect, float tagRotation)
        {
            RectangleF r = pRect.Rect;
            var textPoint = RectangleF.Center(r);
            var tMeasure = TextMeasurer.Measure(pRect.Tag, new TextOptions(TagFont));
            float tLenOffset = -tMeasure.Width / 2;
            float tHOffset = -tMeasure.Height / 2;
            textPoint.Offset(tHOffset, -tLenOffset); //Right for vertical orientation, doesn't matter since the example uses a square
            var matrix = Matrix3x2Extensions.CreateRotationDegrees(tagRotation, textPoint);

            using Image<Rgba32> image = new Image<Rgba32>(bounds.Width, bounds.Height, Color.Black);

            image.Mutate(x => x.Fill(pRect.Color, r));
            image.Mutate(x =>
            {
                var rdo = new DrawingOptions { Transform = matrix };
                x.DrawText(rdo, pRect.Tag, TagFont, Color.White, textPoint);
                x.Draw(rdo, Color.White, 5.0f, new RectangleF(textPoint, new SizeF(tMeasure.Width, tMeasure.Height)));
            });

            image.SaveAsPng("result.png");
        }
    }
}
