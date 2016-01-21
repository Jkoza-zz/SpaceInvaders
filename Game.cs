using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class Game : Form
    {

        public const int FormWidth = 800;
        public const int FormHeight = 600;
        int row = 1;
        int column = 1;
        int padding = 5;
        int size = 30;
        bool CanShoot;
        Ship Player;
        String Direction;
        public int time = 0;
        public int EnemyVel = 1;

        public List<Barrier> BarrierList = new List<Barrier>();
        public List<Enemy> Enemies = new List<Enemy>();
        public List<Bullet> Bullets = new List<Bullet>();
        public List<Bullet> EnemyBullets = new List<Bullet>();
        enum Movement { None, Left, Right };
        enum Type { Top, Middle, Bottom, Dead };

        SoundPlayer player = new System.Media.SoundPlayer(@"c:\fastinvader1.wav");


        public Game()
        {
            InitializeComponent();
        }

        public void Generate(int Amount)                        // generation form
        {
            for (int i = 0; i < Amount; i++)
            {
                if (i % 11 == 0)
                {
                    row += 1;
                    column = 0;
                }
                if (i < 11)
                {
                    Enemies.Add(new Enemy(new Point((20 + (column * size) + padding * column), (padding * row + (row * size) - (size * 2))), size, "Top"));
                }
                if (i >= 11 && i < 33)
                {
                    Enemies.Add(new Enemy(new Point((20 + (column * size) + padding * column), (padding * row + (row * size) - (size * 2))), size, "Middle"));
                }
                if (i >= 33)
                {
                    Enemies.Add(new Enemy(new Point((20 + (column * size) + padding * column), (padding * row + (row * size) - (size * 2))), size, "Bottom"));
                }

                column++;
            }

            Player = new Ship(Properties.Resources.ship, new Point((FormWidth / 2), (FormHeight - 30)), 30, 3);
            BarrierList.Add(new Barrier(100));
            BarrierList.Add(new Barrier(350));
            BarrierList.Add(new Barrier(600));
        }

        public void EnemyShoot()                                //randomizes where the enemy bullet will come from
        {
            Random rnd = new Random();
            EnemyBullets.Add(new Bullet(new Point((Enemies[rnd.Next(0, Enemies.Count)].EnemyRec.X + 20), Enemies[rnd.Next(0, Enemies.Count)].EnemyRec.Y), 15, 20, 5));

        }

        public class MyPanel : System.Windows.Forms.Panel
        {
            public MyPanel()
            {
                this.SetStyle(
                    System.Windows.Forms.ControlStyles.UserPaint |
                    System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                    System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                    true);
            }
        }   // panel code found online to fix graphic glitches

        private void pbCanvas_Paint_1(object sender, PaintEventArgs e)
        {
            for (int y = 0; y < Bullets.Count; y++)
            {
                Bullets[y].Draw(e);
            }
            for (int q = 0; q < EnemyBullets.Count; q++)
            {
                EnemyBullets[q].Draw(e);
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Draw(e);
            }

            Player.Draw(e);

            for (int t = 0; t < BarrierList.Count; t++)
            {
                BarrierList[t].Draw(e);
            }

            e.Graphics.DrawString("Score = " + Player.Score.ToString(), new System.Drawing.Font("Akbar", 16), Brushes.Green, 10, 10);
            e.Graphics.DrawString("Lives = ", new System.Drawing.Font("Akbar", 16), Brushes.Green, 600, 10);
            

        } // paint code

        private void WinCheck()         //checks for win
        {
            if (Enemies.Count == 0)
            {
                Game.ActiveForm.Hide();
            }
        } 

       
        
        private void Game_Load(object sender, EventArgs e)
        {
            Generate(55);
            player.Play();
        }

        private void MoveAll()
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].EnemyRec.X <= 0)
                {
                    for (int x = 0; x < Enemies.Count; x++)
                    {
                        Enemies[x].EnemyRec.X -= EnemyVel;
                        Enemies[x].EnemyRec.Y += 20;
                    }
                    EnemyVel *= -1;

                }

                else if (Enemies[i].EnemyRec.X >= FormWidth - Enemies[i].EnemySize)
                {
                    for (int t = 0; t < Enemies.Count; t++)
                    {
                        Enemies[t].EnemyRec.X -= EnemyVel;
                        Enemies[t].EnemyRec.Y += 20;
                    }
                    EnemyVel *= -1;
                }

            }
            for (int y = 0; y < Enemies.Count; y++)
            {
                Enemies[y].EnemyRec.X += EnemyVel;
            }

            for (int t = 0; t < Bullets.Count; t++)
            {
                if (Bullets.Count > 0)
                {
                    Bullets[t].Move();

                    if (Bullets[t].OutsideWindow == true)
                    {
                        Bullets.RemoveAt(t);
                    }

                }
            }
            for (int q = 0; q < EnemyBullets.Count; q++)
            {
                if (EnemyBullets.Count > 0)
                {
                    EnemyBullets[q].Move();

                    if (EnemyBullets[q].OutsideWindow == true)
                    {
                        EnemyBullets.RemoveAt(q);
                    }

                }
            }
        } //moves list of enemies opposed to one at a time

        private void LoseCheck()
        {
            if (Player.Lives == 0)
            {
                Game.ActiveForm.Hide();
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].EnemyRec.Y >= Game.FormHeight - 150)
                {
                    Game.ActiveForm.Hide();
                }
            }
        } // checks for loss

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            WinCheck();
            LoseCheck();
            MoveAll();
            CollisionCheck();
            Player.Move(Direction);
            pbCanvas.Refresh();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                Direction = Movement.Left.ToString();
            }
            if (e.KeyData == Keys.Space && CanShoot == true)
            {
                Bullets.Add(new Bullet(new Point((Player.ShipRec.X + (Player.ShipSize / 2)), Player.ShipRec.Y), 5, 20, -10));
                CanShoot = false;
            }
            if (e.KeyData == Keys.D)
            {
                Direction = Movement.Right.ToString();
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            Direction = Movement.None.ToString();
        }

        private void CollisionCheck()
        {

            for (int i = 0; i < EnemyBullets.Count; i++)
            {

                if (EnemyBullets[i].BulletRec.IntersectsWith(Player.ShipRec))
                {
                    Player.Lives -= 1;
                    EnemyBullets.RemoveAt(i);
                }

                for (int y = 0; y < BarrierList.Count; y++)
                {
                    for (int t = 0; t < BarrierList[y].Recs.Count; t++)
                    {
                        if (EnemyBullets.Count != 0)
                        {
                            if (EnemyBullets[i].BulletRec.IntersectsWith(BarrierList[y].Recs[t]))
                            {
                                BarrierList[y].Recs.RemoveAt(t);
                                EnemyBullets.RemoveAt(i);
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < Bullets.Count; i++)
            {
                for (int q = 0; q < BarrierList.Count; q++)
                {
                    for (int t = 0; t < BarrierList[q].Recs.Count; t++)
                    {
                        if (Bullets.Count != 0)
                        {
                            if (Bullets[i].BulletRec.IntersectsWith(BarrierList[q].Recs[t]))
                            {
                                BarrierList[q].Recs.RemoveAt(t);
                                Bullets.RemoveAt(i);
                                WinCheck();
                            }
                        }
                    }

                }

            }
            // Player Bullet to enemy
            for (int i = 0; i < Bullets.Count; i++)
            {
                
                for (int y = 0; y < Enemies.Count; y++)
                {
                    if (Bullets.Count != 0)
                    {
                        if (Bullets[i].BulletRec.IntersectsWith(Enemies[y].EnemyRec))
                        {
                            Player.Score += Enemies[y].ScoreVal;
                            Enemies[y].state = 3;
                            Bullets.RemoveAt(i);
                        }
                    }

                }
            }


           


           
        }


        private void BulletSpawn_Tick(object sender, EventArgs e)
        {
            EnemyShoot();
            if (CanShoot == false)
            {
                CanShoot = true;
            }
            time += 1;
           
        }

        private void StateSwitch_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies[i].state == 1)
                {
                    Enemies[i].state = 2;
                }
                else if (Enemies[i].state == 2)
                {
                    Enemies[i].state = 1;
                }
                else if (Enemies[i].state == 3)
                {
                    Enemies.RemoveAt(i);
                }
            }
            for (int i = 0; i < EnemyBullets.Count; i++)
            {
                if (EnemyBullets[i].state == 1)
                {
                    EnemyBullets[i].state = 2;
                }
                else if (EnemyBullets[i].state == 2)
                {
                    EnemyBullets[i].state = 1;
                }
            }
            
        }


    }
}


