using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Kurganskiy_as_game
{
    interface ICollision
    {
        bool Collision(ICollision obf);
        Rectangle Rect { get; }
    }
}
