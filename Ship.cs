using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Kurganskiy_as_game
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        private int _score = 0;

        public int Energy => _energy;
        public int Score => _score;

        public static event Message MessageDie;

        Image img = Image.FromFile("Pictures\\Karemma_starship.png");

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public void EnergyGain(int n)
        {
            _energy += n;
        }

        public void GetScore()
        {
            _score++;
        }
        

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }

        public override void Update()
        {
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
