using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurganskiy_as_game
{
    static class SplashScreen
    {
        /// <summary>
        /// Чтобы адекватно создать движущийся объект на экране меню, 
        /// пришлось для экрана меню прописывать новые классы.
        /// Без этого он начинает использовать одну и туже картинку как для игры так и для заставки меню.
        /// Как сделать без дублирования не сообразил.
        /// </summary>
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        static Mmbackground mmbackground = new Mmbackground();

        //Расширение игры
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static MainObject[] _objs;

        public static Random rnd = new Random();

        static SplashScreen()
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
            Wreck star = new Wreck();
            _objs = new MainObject[1];
            for (int i = 0; i < _objs.Length; i++)
            {
                int size = 20;
                _objs[i] = new Wreck(new Point(800, rnd.Next(0, 600)), new Point(10, 0), new Size(size, size));
            }
        }

        public static void Draw()
        {
            //Очищаем экран
            Buffer.Graphics.Clear(Color.Black);
            mmbackground.Draw();
            //Рисуем объекты
            foreach (MainObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (MainObject obj in _objs)
                obj.Update();
        }
    }
}
