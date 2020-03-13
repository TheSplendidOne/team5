using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Services
{
    public static class ColorPaletteGenerator
    {
        private static readonly string[] BasicPallette =
        {
            "#808080", 
            "#800000",
            "#FFFF00",
            "#00FF00",
            "#008080",
            "#000080",
            "#800080",
            "#FF0000",
            "#808000",
            "#008000",
            "#00FFFF",
            "#0000FF"
        };
        public static IReadOnlyList<string> CreateHexPalette(int count) //
        {
            if (count > BasicPallette.Length)
                throw new ArgumentOutOfRangeException(nameof(count), $"Max palette length: {BasicPallette.Length}");
            return Array.AsReadOnly<string>(BasicPallette.Take(count).ToArray());
        }

        public static IReadOnlyList<string> CreateHexPalette() //
        {
            return CreateHexPalette(BasicPallette.Length);
        }
        public static int IndexInPalette(IReadOnlyList<string> palette, string hexCode)
        {
            for (int i = 0; i < palette.Count; i++)
            {
                if (palette[i] == hexCode)
                {
                    return i;
                }
            }
            throw new ArgumentException();
        }
    }
}