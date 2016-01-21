using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace WindowsFormsApplication1
{
    public class Enemy
    {
        public Image EnemyPic;
        public Rectangle EnemyRec;
        public Point EnemyPos;
        public String EnemyType;
        public int EnemySize;
        public int ScoreVal;
        public int state = 1;

      public Enemy(Point Position, int Size, String Type)
        {
            this.EnemyPos = Position;
            this.EnemySize = Size;
            this.EnemyType = Type;
            switch (EnemyType)
            {
                case "Top":
                    ScoreVal = 20;
                    break;
                case "Middle":
                    ScoreVal = 10;
                    break;
                case "Bottom":
                    ScoreVal = 5;
                    break;
            }
            EnemyRec = new Rectangle(Position.X, Position.Y, Size, Size);
        }

       

      public void Draw(PaintEventArgs e)
      {
          if (state == 1)
          {
              switch (EnemyType)
              {
                  case "Top":
                      this.EnemyPic = Properties.Resources.MiddleRow_1;
                      break;
                  case "Middle":
                      this.EnemyPic = Properties.Resources.TopRow_1;
                      break;
                  case "Bottom":
                      this.EnemyPic = Properties.Resources.BottomRow_1;
                      break;
              }
          }
          if (state == 2)
          {
              switch (EnemyType)
              {
                  case "Top":
                      this.EnemyPic = Properties.Resources.MiddleRow_2;
                      break;
                  case "Middle":
                      this.EnemyPic = Properties.Resources.TopRow_2;
                      break;
                  case "Bottom":
                      this.EnemyPic = Properties.Resources.BottomRow_2;
                      break;
              }
          }
          if (state == 3)
          {
              this.EnemyPic = Properties.Resources.Dead;
          }
          e.Graphics.DrawImage(this.EnemyPic, EnemyRec);
      }



     

    }
}
