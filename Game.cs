﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace Kurganskiy_as_game
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        //Расширение игры
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _objs;
        public static Bullet _bullet;
        public static Asteroid[] _asteroids;

        public static Random rnd = new Random();
        static Background background = new Background();
        public static Timer timer = new Timer();

        static Game()
        {
        }
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(20, 10));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Escape) Game.Finish();
        }

        //Алгоритм прорисовки графики через буффер
        public static void Init(Form form)
        {

            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для
            // текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в
            // буфере

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            form.KeyDown += Form_KeyDown;
            Load();
            timer.Start();
            timer.Tick += Timer_Tick;
            Ship.MessageDie += Finish;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[30];
            Star star = new Star();
            _objs = new BaseObject[20];
            for (int i = 0; i < _objs.Length; i++)
            {
                int size = star.GetRandomSize();
                _objs[i] = new Star(new Point(800, rnd.Next(0, 600)), new Point(star.GetSpeed(size), 0), new Size(size, size));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
            }
        }
        //private static void CheckCollisions()
        //{
        //    foreach (Asteroid asteroid in _asteroids)
        //        if (
        //            _bullet.GetPos().Y >= asteroid.GetPos().Y &&
        //            _bullet.GetPos().Y < asteroid.GetPos().Y + asteroid.GetSize().Height &&
        //            _bullet.GetPos().X >= asteroid.GetPos().X)
        //        {
        //            _bullet.Collided = true;
        //            asteroid.Collided = true;
        //        }
        //}


        public static void Draw()
        {
            //Очищаем экран
            Buffer.Graphics.Clear(Color.Black);
            //Рисуем заного заставку
            background.Draw();
            //РИсуем объекты
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid a in _asteroids)
                a?.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);


            //При закрытии окна игры выкидывает ошибку. Не понимаю как убрать.
            //Можно обработать исключениями.
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            _bullet?.Update();
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                _ship?.EnergyLow(rnd.Next(0, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
            //CheckCollisions();
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}