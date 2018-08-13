using System.Drawing;
using System;

namespace Kurganskiy_as_game
{
    class Star : BaseObject
    {
        Image img = Image.FromFile("Pictures\\asteroid 03.png");

        public Star() : base(new Point(0, 0), new Point(0, 0), new Size(0, 0))
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Game.Buffer.Graphics.DrawImage(img, pos);
        }

        //Присваиваем размер звезде
        public int GetRandomSize()
        {
            int size = Game.rnd.Next(1, 4);
            return size;
        }


        //Присваиваем скорость звезде в зависимости от ее размера
        //Хорошо видно без использования картинки (В планах доработать изменение картинок)
        public int GetSpeed(int size)
        {

            int speed = 0;
            if (size < 2)
            {
                speed = Game.rnd.Next(1, 10);
            }
            else if (size == 2)
            {
                speed = Game.rnd.Next(10, 20);
            }
            else if (size >= 3 && size <= 4)
            {
                speed = Game.rnd.Next(20, 30);
            }
            return speed;
        }
        
        //Рисуем присвоенную картинку. Без этого пункта будут кружки.
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }

        public override void Update()
        {
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = Game.rnd.Next(0, 600);
            }
            else Pos.X = Pos.X - Dir.X;
        }

    }
}