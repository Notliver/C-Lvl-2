using System;
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

        public static Random rnd = new Random();
        static Background background = new Background();
        
        static Game()
        {
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

            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            Star star = new Star();
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length; i++)
            {
                int size = star.GetRandomSize();
                _objs[i] = new Star(new Point(800, rnd.Next(0, 600)), new Point(star.GetSpeed(size), 0), new Size(size, size));
            }
        }
        
        public static void Draw()
        {
            //Очищаем экран
            Buffer.Graphics.Clear(Color.Black);
            //Рисуем заного заставку
            background.Draw();
            //РИсуем объекты
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}