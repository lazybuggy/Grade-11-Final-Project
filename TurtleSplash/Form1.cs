using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Jessie Diep and Lucia Okeh
//June 18 2013
//Turtle Splash
//Create our own game using C#. The point of this game is to catch the food
//while avoiding turtles.
namespace TurtleSplash
{
    public partial class Form1 : Form
    {
        //Gloabal Variables
        int Playerx = 50;
        int Playery = 370;
        double PlayPoints = 0;

        int Ballx = 50;
        int Bally = 50;

        int Angryx = 670;
        int Computer1x = 20;
        int Computer2x = 650;
        int Computer3x = 5;

        int Direction = 0;
        int Direction1 = 0;
        int Direction2 = 1;
        int Direction3 = 0;
        int Direction4 = 1;
        int Directiona = 0;

        bool Gameover = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Code for player turtle
            Graphics g = this.CreateGraphics();
            Bitmap bm = Resource1.PlayerTurtle;
            g.DrawImage(bm, Playerx, Playery, 70, 70);
            g.Dispose();
            //Code for angry turtle
            Graphics p = this.CreateGraphics();
            Bitmap cm = Resource1.AngryTurtle;
            p.DrawImage(cm, Angryx, 330, 90, 90);
            p.Dispose();

            //Code for computer turtle #1
            Graphics r = this.CreateGraphics();
            Bitmap nm = Resource1.ComputerTurtle1;
            r.DrawImage(nm, Computer1x, 200, 90, 90);
            r.Dispose();

            //Code for computer turtle #2
            Graphics s = this.CreateGraphics();
            Bitmap sm = Resource1.ComputerTurtle2;
            s.DrawImage(sm, Computer2x, 120, 90, 90);
            s.Dispose();

            //Code for computer turtle #3
            Graphics t = this.CreateGraphics();
            Bitmap tm = Resource1.ComputerTurtle3;
            t.DrawImage(tm, Computer3x, 20, 90, 90);
            t.Dispose();

            //Ball (Food)
            Graphics m = CreateGraphics();
            SolidBrush AquaBrush = new SolidBrush(Color.Aqua);
            m.FillEllipse(AquaBrush, Ballx, Bally, 30, 30);
            AquaBrush.Dispose();
            m.Dispose();


        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //X Direction of the green(player turtle)
            if (Direction == 0)
            {
                Playerx = Playerx + 20;
                if (Playerx + 20 > ClientSize.Width)
                {
                    Playerx = ClientSize.Width - 20;
                    Direction = 1;
                }
            }
            else if (Direction == 1)
            {
                Playerx = Playerx - 20;
                if (Playerx < 0)
                {
                    Playerx = 0;
                    Direction = 0;
                }
            }

            //Y Direction of the green (player turtle)
            if (Direction == 2)
            {
                Playery = Playery + 20;
                if (Playery + 20 >= ClientSize.Height)
                {
                    Playery = ClientSize.Height - 20;
                    Direction = 3;
                }
            }
            else if (Direction == 3)
            {
                Playery = Playery - 20;
                if (Playery < 0)
                {
                    Playery = 0;
                    Direction = 2;
                }
            }
            
            //Intersection code
            Rectangle Player = new Rectangle(Playerx, Playery, 50, 50);
            Rectangle Turt1 = new Rectangle(Computer1x, 200, 90, 90);
            Rectangle Turt2 = new Rectangle(Computer2x, 120, 90, 90);
            Rectangle Turt3 = new Rectangle(Computer3x, 20, 90, 90);
            Rectangle Angry = new Rectangle(Angryx, 280, 90, 90);
            Rectangle Ball = new Rectangle(Ballx, Bally, 30, 39);
        
            if (Player.IntersectsWith(Turt1))
            {                                 
                lblEndGame.Visible = true;
                lblEndGame.Text = ("Game Over !!");
                Computer1Timer.Enabled = false;
                GameTimer.Enabled = false;
                CatchTimer.Enabled = false;
                AngryTimer.Enabled = false;
                MessageBox.Show("Game Over. Points = " + PlayPoints + "\n" + "Press start to replay.");
                Gameover = true;
            }

            if (Player.IntersectsWith(Turt2))
            {
                lblEndGame.Visible = true;
                lblEndGame.Text = ("Game Over !!");
                Computer2Timer.Enabled = false;
                Computer3Timer.Enabled = false;
                Computer1Timer.Enabled = false;
                GameTimer.Enabled = false;
                CatchTimer.Enabled = false;
                AngryTimer.Enabled = false;
                MessageBox.Show("Game Over. Points = " + PlayPoints + "\n" + "Press start to replay.");
                Gameover = true;
            }

            if (Player.IntersectsWith(Turt3))
            {
                lblEndGame.Visible = true;
                lblEndGame.Text = ("Game Over !!");
                Computer3Timer.Enabled = false;
                Computer2Timer.Enabled = false;
                Computer1Timer.Enabled = false;
                AngryTimer.Enabled = false;
                GameTimer.Enabled = false;
                CatchTimer.Enabled = false;
                MessageBox.Show("Game Over. Points =  " + PlayPoints + "\n" + "Press start to replay.");
                Gameover = true;
            }

            if (Player.IntersectsWith(Angry))
            {
                lblEndGame.Visible = true;
                lblEndGame.Text = ("Game Over !!");
                GameTimer.Enabled = false;
                CatchTimer.Enabled = false;
                AngryTimer.Enabled = false;
                Computer3Timer.Enabled = false;
                Computer2Timer.Enabled = false;
                Computer1Timer.Enabled = false;
                MessageBox.Show("Game Over. Points = " + PlayPoints +"\n" + "Press start to replay.");
                Gameover = true;
            }
            if (Player.IntersectsWith(Ball))
            {
                lblPoints.Visible = true;
                PlayPoints = PlayPoints + 10;
                lblPoints.Text = ("Points =  " + PlayPoints);
            }

            Refresh();
        }

        private void mnuGameStart_Click(object sender, EventArgs e)
        {
            //What happens when start is clicked
            GameTimer.Enabled = true;
            Computer1Timer.Enabled = true;
            Computer2Timer.Enabled = true;
            Computer3Timer.Enabled = true;
            CatchTimer.Enabled = true;
            AngryTimer.Enabled = true;
            if (Gameover == true)
            {
                Application.Restart();
            }
        }

        private void mnuGamePause_Click(object sender, EventArgs e)
        {
            //What happens when pause the game
            GameTimer.Enabled = false;
            Computer1Timer.Enabled = false;
            Computer2Timer.Enabled = false;
            Computer3Timer.Enabled = false;
            CatchTimer.Enabled = false;
            AngryTimer.Enabled = false;
        }

        private void mnuGameHelp_Click(object sender, EventArgs e)
        {
            //Display help box 
            //What happens when help is clicked
            GameTimer.Enabled = false;
            Computer1Timer.Enabled = false;
            Computer2Timer.Enabled = false;
            Computer3Timer.Enabled = false;
            CatchTimer.Enabled = false;
            AngryTimer.Enabled = false;
            MessageBox.Show("The objective: Earn as many points as possible while avoiding the enemy turtles." + "\n" +
                "To move: Use your arrow keys to move up, down, left and right." + "\n" + "To earn points: Swim and touch the falling food.");
            GameTimer.Enabled = true;
            Computer1Timer.Enabled = true;
            Computer2Timer.Enabled = true;
            Computer3Timer.Enabled = true;
            CatchTimer.Enabled = true;
            AngryTimer.Enabled = true;
        }

        private void mnuGameExit_Click(object sender, EventArgs e)
        {
            //Make the form close
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Code to move green (player) turtle
            if (e.KeyCode == Keys.Down)
            {
                Playery = Playery + 10;
                Direction = 2;
            }
            if (e.KeyCode == Keys.Up)
            {
                Playery = Playery - 10;
                Direction = 3;
            }
            if (e.KeyCode == Keys.Right)
            {
                Playerx = Playerx + 10;
                Direction = 0;
            }
            if (e.KeyCode == Keys.Left)
            {
                Playerx = Playerx - 10;
                Direction = 1;
            }
        }

        private void Computer1Timer_Tick(object sender, EventArgs e)
        {
            //Code for Computer1 turtle
            if (Direction1 == 0)
            {
                Computer1x = Computer1x + 60;
                if (Computer1x + 90 > ClientSize.Width)
                {
                    Computer1x = ClientSize.Width - 60;
                    Direction1 = 1;
                }
            }
            else if (Direction1 == 1)
            {
                Computer1x = Computer1x - 60;
                if (Computer1x < 0)
                {
                    Computer1x = 0;
                    Direction1 = 0;
                }
            }
            Refresh();
        }

        private void Computer2Timer_Tick(object sender, EventArgs e)
        {
            //Code for Computer2 Turtle
            if (Direction2 == 0)
            {
                Computer2x = Computer2x + 5;
                if (Computer2x + 20 > ClientSize.Width)
                {
                    Computer2x = ClientSize.Width - 5;
                    Direction2 = 1;
                }
            }
            else if (Direction2 == 1)
            {
                Computer2x = Computer2x - 5;
                if (Computer2x < 0)
                {
                    Computer2x = 0;
                    Direction2 = 0;
                }
            }
        }

        private void Computer3Timer_Tick(object sender, EventArgs e)
        {
            //Code for Computer2 Turtle
            if (Direction3 == 0)
            {
                Computer3x = Computer3x + 5;
                if (Computer3x + 20 > ClientSize.Width)
                {
                    Computer3x = ClientSize.Width - 5;
                    Direction3 = 1;
                }
            }
            else if (Direction3 == 1)
            {
                Computer3x = Computer3x - 5;
                if (Computer3x < 0)
                {
                    Computer3x = 0;
                    Direction3= 0;
                }
            }
        }

        private void CatchTimer_Tick(object sender, EventArgs e)
        {
            //Blue Ball code
            if (Directiona == 0)
            {
                Ballx = Ballx + 30;
                Bally = Bally + 30;
                if (Ballx + 30 > ClientSize.Width || Bally + 30 >ClientSize.Height)
                {
                    Ballx = ClientSize.Width - Ballx;
                    Bally = ClientSize.Height - Bally;
                }
            }
        }

        private void AngryTimer_Tick(object sender, EventArgs e)
        {
            //Code for Angry Turtle
            if (Direction4 == 0)
            {
                Angryx = Angryx + 15;
                if (Angryx + 20 > ClientSize.Width)
                {
                    Angryx = ClientSize.Width - 15;
                    Direction4 = 1;
                }
            }
            else if (Direction4 == 1)
            {
                Angryx = Angryx - 15;
                if (Angryx < 0)
                {
                    Angryx = 0;
                    Direction4 = 0;
                }
            }
            Refresh();
        }
    }
}
