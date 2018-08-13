using System;
using System.Drawing;

namespace Kurganskiy_as_game
{
    class Background : BaseObject
    {
        //Массив с картинками для фона
		private Image[] imgs =
        {
            Image.FromFile("Pictures\\background01.png"),
            Image.FromFile("Pictures\\background02.png"),
            Image.FromFile("Pictures\\background03.png")
        };

        private Image img;

        //Картинки выбираются рандомно
        public Background() : base(new Point(0, 0), new Point(0, 0), new Size(0, 0))
        {
            img = imgs[Game.rnd.Next(0, 2)];
        }

        public Background(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = imgs[Game.rnd.Next(0, 2)];
        }

        //Рисуем
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, 0, 0, Game.Width, Game.Height);
        }
    }
}
