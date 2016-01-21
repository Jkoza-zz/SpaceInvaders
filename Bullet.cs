using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication1
{
    public class Bullet
    {
        public Rectangle BulletRec;
        public Point BulletPos;
        public String BulletType;
        public int BulletWidth;
        public int BulletHeight;
        public bool OutsideWindow;
        public int Vel;
        public int state = 1;

        public Bullet(Point Position, int BulletWidth, int BulletHeight, int Vel)
        {
            this.BulletPos = Position;
            this.BulletWidth = BulletWidth;
            this.BulletHeight = BulletHeight;
            this.OutsideWindow = false;
            this.Vel = Vel;
            BulletRec = new Rectangle(Position.X, Position.Y, BulletWidth, BulletHeight);
        }

        public void Draw(PaintEventArgs e)
        {
            if (state == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.Bullet1, BulletRec);
            }
            if (state == 2)
            {
                e.Graphics.DrawImage(Properties.Resources.Bullet2, BulletRec);
            }
            
        }

        public void Move()
        {
            BulletRec.Y += Vel;

            if (BulletRec.Y<= 0 || BulletRec.Y >= Game.FormHeight)
            {
                OutsideWindow = true;
            }
        }
    }
}
