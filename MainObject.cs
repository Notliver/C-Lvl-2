using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurganskiy_as_game
{
    class MainObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        
        /// <summary>
        /// Класс полностью дублирует функционал BaseObject только предназначен для главноего меню
        /// </summary>


        public MainObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }


        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > SplashScreen.Height) Dir.Y = -Dir.Y;
        }
    }
}
