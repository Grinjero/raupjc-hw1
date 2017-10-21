using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    interface IPhysicalObject2D
    {
        float X { get; set; }

        float Y { get; set; }

        int Width { get; set; }

        int Height { get; set; }
    }
}
