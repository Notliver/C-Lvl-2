using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurganskiy_as_game
{
    class Mmbackground : BaseObject
    {
        /// <summary>
        /// Класс для подключения фона для главного меню. Дублирует backgroung
        /// </summary>

        private Image img = Image.FromFile("Resources\\r-type-cawdvr0wiaavgqf.jpg");

        public Mmbackground() : base(new Point(0, 0), new Point(0, 0), new Size(0, 0))
        {
        }

        public Mmbackground(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(img, 0, 0, SplashScreen.Width, SplashScreen.Height);
        }
        public override void Update()
        {
            
        }
    }
}
