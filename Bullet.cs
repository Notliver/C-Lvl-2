using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Kurganskiy_as_game
{
    class Bullet : BaseObject
    {

        public bool Collided { get; set; }
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Collided = false;
        }

        public Point GetPos()
        {
            return Pos;
        }

        public Size GetSize()
        {
            return Size;
        }


        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            if (Collided)
            {
                Pos.X = 0;
                Pos.Y = Game.rnd.Next(0, Game.Height - Size.Height);
                Collided = false;
            }

            Pos.X = Pos.X + 10;

        }
    }
}
