using System;
using System.Drawing;

namespace Lightfoil
{
    public static class Utilities
    {
        public static string ConvertArgb(Color color)
        {
            var alpha = color.A;

            return $"Rgb({(1 - alpha) * 255 + alpha * color.R}, " +
                $"{(1 - alpha) * 255 + alpha * color.G}, " +
                $"{(1 - alpha) * 255 + alpha * color.B})";
        }
    }
}
