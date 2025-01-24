using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class MaterialColor
    {
        public static Material SetColorAlpha(this Material source, float alpha)
        {
            var current = source.color;
            current.a = alpha;
            source.color = current;
            return source;
        }

        public static Material SetColoRGB(this Material source, Color color)
        {
            var current = source.color;
            current.r = color.r;
            current.g = color.g;
            current.b = color.b;
            source.color = current;
            return source;
        }
    }
}