namespace WindowsFormsApplication1
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbCanvas = new WindowsFormsApplication1.Game.MyPanel();
            this.Move = new System.Windows.Forms.Timer(this.components);
            this.BulletSpawn = new System.Windows.Forms.Timer(this.components);
            this.StateSwitch = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.Black;
            this.pbCanvas.Location = new System.Drawing.Point(0, 0);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(800, 600);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint_1);
            // 
            // Move
            // 
            this.Move.Enabled = true;
            this.Move.Interval = 10;
            this.Move.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // BulletSpawn
            // 
            this.BulletSpawn.Enabled = true;
            this.BulletSpawn.Interval = 1000;
            this.BulletSpawn.Tick += new System.EventHandler(this.BulletSpawn_Tick);
            // 
            // StateSwitch
            // 
            this.StateSwitch.Enabled = true;
            this.StateSwitch.Interval = 300;
            this.StateSwitch.Tick += new System.EventHandler(this.StateSwitch_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 603);
            this.Controls.Add(this.pbCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Game.MyPanel pbCanvas;
        private System.Windows.Forms.Timer Move;
        private System.Windows.Forms.Timer BulletSpawn;
        private System.Windows.Forms.Timer StateSwitch;
    }
}