using System;
using System.Drawing;
using System.Security.Policy;

namespace Kurganskiy_as_game
{
    internal class Wreck : MainObject
    {

        /// <summary>
        /// Класс создает объекты для главного меню
        /// </summary>
        
        Image img = Image.FromFile("Pictures\\Shenzhou_front_white_shadow.png");

        public Wreck() : base(new Point(0, 0), new Point(0, 0), new Size(0, 0))
        {
            SplashScreen.Buffer.Graphics.DrawImage(img, Pos);
        }

        public Wreck(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            SplashScreen.Buffer.Graphics.DrawImage(img, pos);
        }

        //Рисуем картинку
        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(img, Pos);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = SplashScreen.Width + Size.Width;
                Pos.Y = SplashScreen.rnd.Next(0 + Size.Height, 600 - Size.Height);
            }
        }
    }
}