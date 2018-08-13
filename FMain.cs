using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurganskiy_as_game
{
    public partial class FMain : Form
    {
        FTopPlrs FTPs = new FTopPlrs();
        FGame FGm = new FGame();

        /// <summary>
        /// Единственный способ которым смог нормально сделать надпись на заставке
        /// это фотошоп. Остальные способы не дают прозрачного фона.
        /// Нашел решение как сделать прозрачным, но не хватило опыта сделать чтобы он активировался сразу,
        /// а не после клика по нему.
        /// Так же убрал из настройки формы фон, криво ложиться.
        /// </summary>

        public FMain()
        {
            InitializeComponent();
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            //Вызываем нажатием кнопки меню "новая игра" инициацию игры
            FGm.Width = 800;
            FGm.Height = 600;
            Game.Init(FGm);
            Game.Load();
            Game.Draw();
            FGm.ShowDialog();
        }

        private void BtnTopPlrs_Click(object sender, EventArgs e)
        {
            FTPs.ShowDialog();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FMain_Load(object sender, EventArgs e)
        {

        }
    }
}
