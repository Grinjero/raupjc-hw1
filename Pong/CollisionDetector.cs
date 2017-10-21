using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            if((a.X >= b.X && a.X <= b.X + b.Width && a.Y >= b.Y && a.Y <= b.Y + b.Height) ||
                (b.X >= a.X && b.X <= a.X + a.Width && b.Y >= a.Y && b.Y <= a.Y + a.Height) ||
                (a.X + a.Width >= b.X && a.X + a.Width <= b.X + b.Width && a.Y + a.Height >= b.Y && a.Y + a.Height <= b.Y + b.Height) ||
                (b.X + b.Width >= a.X && b.X + b.Width <= a.X + a.Width && b.Y + b.Height >= a.Y && b.Y + b.Height <= a.Y + a.Height))
            {
                return true;
            }

            return false;
        }
    }
}
