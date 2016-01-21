using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        
        public const int FormWidth = 800;
        public const int FormHeight = 600;
        int row = 1;
        int column = 1;
        public List<Enemy> Enemies = new List<Enemy>();
        enum Movement { None, Left, Right };
        enum Type { Top, Middle, Bottom, Dead };

        public Form1()
        {
            InitializeComponent();
        }

    
        public void Generate(int Amount)
        {
            for (int i = 0; i < Amount; i++)
            {
                if (i % 11 == 0)
                {
                    row += 1;
                    column = 0;
                }
                Enemies.Add(new Enemy(Properties.Resources.BottomRow_1, new Point((column * 50), ((row *50) - 150)), 50));
                column++;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Enemies.Move();
            pbCanvas.Refresh();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Draw(e);
            }
        }

        #region Timers

       
        #endregion




        


    }
}
