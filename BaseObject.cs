using System;
using System.Drawing;


namespace Kurganskiy_as_game
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public Rectangle Rect => new Rectangle(Pos, Size);

        public delegate void Message();

        

        //Создали массив с объектами и задали им величину и позицию


        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();


        public abstract void Update();
        //{
        //    Pos.X = Pos.X + Dir.X;
        //    Pos.Y = Pos.Y + Dir.Y;
        //    if (Pos.X < 0) Dir.X = -Dir.X;
        //    if (Pos.X > Game.Width) Dir.X = -Dir.X;
        //    if (Pos.Y < 0) Dir.Y = -Dir.Y;
        //    if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        //}


        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);


    }
}