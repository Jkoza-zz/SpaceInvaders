using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication1
{
    class Ship
    {
        public Image ShipPic;
        public Rectangle ShipRec;
        public Point ShipPos;
        public int ShipSize;
        public int Score;
        public int Lives;
        
        public Ship(Image Image, Point Position, int Size, int Lives)
        {
            this.ShipPos = Position;
            this.ShipSize = Size;
            this.ShipPic= Image;
            this.Score = 0;
            this.Lives = Lives;
            ShipRec = new Rectangle(Position.X, Position.Y, Size, Size);
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.ShipPic, ShipRec);

            for (int i = 0; i <= Lives; i++)
            {
                e.Graphics.DrawImage(this.ShipPic, new Rectangle(Game.FormWidth - (35 * i), 10, 20, 20));
            }
        }

        public void Move(String Direction)
        {
            switch (Direction)
            {
                case "Left":
                    if (ShipRec.X >= 0)
                    {
                        ShipRec.X -= 10;
                    }
                    break;
                case "Right":
                    if (ShipRec.X <= Game.FormWidth - ShipSize)
                    {
                        ShipRec.X += 10;
                    }
                    break;
                case "None":
                    break;
            }
            
        }
    }
}
