using System.Security.Cryptography;

namespace thegame.Services
{
    public class RandomFieldGenerator
    {
        public static int[,] Create(int width, int height, int colorCount)
        {
            var result = new int[width, height];
            var buffer = new byte[width * height];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(buffer);
            }

            for (var i = 0; i < buffer.Length; i++)
            {
                result[i / height, i % height] = buffer[i] % colorCount;
            }
            return result;
        }
    }
}