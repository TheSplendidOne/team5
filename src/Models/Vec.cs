using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace thegame.Models
{
    public class Vec
    {
        public Vec(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Vec))
                return false;
            return ((Vec) obj).X == X && ((Vec) obj).Y == Y;
        }

        public readonly int X, Y;

    }
}