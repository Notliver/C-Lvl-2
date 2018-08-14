using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Kurganskiy_as_game
{
    class Asteroid : BaseObject , ICloneable
    {
        public int Power { get; set; }

        public bool Collided { get; set; }
      

        public Point GetPos()
        {
            return Pos;
        }

        public Size GetSize()
        {
            return Size;
        }


        Image img = Image.FromFile("Pictures\\asteroid 03.png");

        public Asteroid(Point pos, Point dir, Size size) : base (pos,dir,size)
        {
            Power = 1;
            Collided = false;
        }

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            asteroid.Power = Power;
            Collided = false;
            return asteroid;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img,Pos);
        }
        public override void Update()
        {
            if (Collided)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = Game.rnd.Next(0, 600);
                Collided = false;
            }
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < -(Size.Width))
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = Game.rnd.Next(0, 600);
            }
        }
    }
}
