using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurganskiy_as_game
{
    class AidKit : BaseObject, IComparable<AidKit>

    {
        public int Power { get; set; }
        public bool Collided { get; set; }

        Image img = Image.FromFile("Pictures\\blue_cross_round_symbol.png");


        public AidKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = -1;
            Collided = false;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
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
        int IComparable<AidKit>.CompareTo(AidKit obj)
        {
            if (Power > obj.Power)
                return 1;
            if (Power < obj.Power)
                return -1;
            return 0;

        }
    }
}
