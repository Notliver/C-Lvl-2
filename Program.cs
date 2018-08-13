using System;
using System.Windows.Forms;


namespace Kurganskiy_as_game
{
    class Program
    {

        public static FMain fMain = new FMain();

        static void Main(string[] args)
        {
            fMain.Width = 800;
            fMain.Height = 600;
            SplashScreen.Init(fMain);
            Application.Run(fMain);
        }
    }
}
