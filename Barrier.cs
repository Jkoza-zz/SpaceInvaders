using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication1
{
    public class Barrier
    {

        public List<Rectangle> Recs = new List<Rectangle>();
        int XPadding;

        public Barrier(int XPad)
        {
            int row = 1;
            int column = 1;
            this.XPadding = XPad;

            for (int i = 0; i < 50; i++)
            {
                if (i % 10 == 0)
                {
                    row++;
                    column = 1;
                }

                this.Recs.Add(new Rectangle(XPad + (column * 10),((Game.FormHeight - 150) + row * 10), 10, 10));
                column++;
            }
        }

       

        public void Draw(PaintEventArgs e)
        {
            for (int i = 0; i < Recs.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.Green, Recs[i]);
            }
           
            
        }
    }
}
