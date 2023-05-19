using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace spaceRaceGame
{
    public partial class spaceRace : Form
    {
        //player 1 creation
        Rectangle p1 = new Rectangle(300, 550, 20, 20);
        Rectangle p1L1 = new Rectangle(306, 547, 3, 6);
        Rectangle p1L2 = new Rectangle(303, 553, 9, 3);
        Rectangle p1L3 = new Rectangle(300, 556, 15, 9);
        Rectangle p1Red = new Rectangle(300, 559, 15, 3); //red stripe
        Rectangle p1L4 = new Rectangle(303, 565, 9, 3);
        Rectangle p1L5 = new Rectangle(306, 562, 3, 3);
        Rectangle p1L6 = new Rectangle(303, 565, 9, 6);
        Rectangle p1L7 = new Rectangle(300, 571, 15, 3);

        Rectangle p1Fire = new Rectangle(300, 581, 15, 6);
        Rectangle p1MoreFire = new Rectangle(306, 587, 9, 6);
        Rectangle p1ExtraFire = new Rectangle(306, 593, 3, 6);
        Rectangle p1EvenMoreFire = new Rectangle(303, 581, 9, 6);

        //player 2 creation
        Rectangle p2 = new Rectangle(600, 550, 20, 20);
        Rectangle p2L1 = new Rectangle(606, 547, 3, 6);
        Rectangle p2L2 = new Rectangle(603, 553, 9, 3);
        Rectangle p2L3 = new Rectangle(600, 556, 15, 9);
        Rectangle p2Blue = new Rectangle(600, 559, 15, 3); //blue stripe
        Rectangle p2L4 = new Rectangle(603, 565, 9, 3);
        Rectangle p2L5 = new Rectangle(606, 562, 3, 3);
        Rectangle p2L6 = new Rectangle(603, 565, 9, 6);
        Rectangle p2L7 = new Rectangle(600, 571, 15, 3);

        Rectangle p2Fire = new Rectangle(600, 581, 15, 6);
        Rectangle p2MoreFire = new Rectangle(603, 587, 9, 6);
        Rectangle p2ExtraFire = new Rectangle(606, 593, 3, 6);
        Rectangle p2EvenMoreFire = new Rectangle(603, 581, 9, 6);

        //finish line
        Rectangle winLine = new Rectangle(0, -5, 950, 1);

        //set player speed
        int player1Speed = 10;
        int player2Speed = 10;

        //player scores
        int p1Score = 0;
        int p2Score = 0;

        //asteriods exist
        List<Rectangle> asteroidsList = new List<Rectangle>();
        List<Rectangle> asteroidList = new List<Rectangle>();
        List<int> asteroidSpeeds = new List<int>();

        //set asteroid variables
        int asteroidSizeY = 5;
        int asteroidSizeX = 15;
        int asteroidSpeed = 8;

        //middle line thing exists
        Rectangle midLine = new Rectangle(470, 10, 10, 590);

        //set middle line speed/timer
        int timeSpeed = 1;

        //randoms
        int randValue = 0;
        Random randGen = new Random();

        //controls
        bool upDown = false;
        bool downDown = false;
        bool wDown = false;
        bool sDown = false;

        //brushes
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);

        //starting state
        string state = "waiting";

        //sounds
        SoundPlayer levelUpSound = new SoundPlayer(Properties.Resources.levelUpSound);
        SoundPlayer titleScreenSound = new SoundPlayer(Properties.Resources.titleScreenSound);

        public spaceRace()
        {
            InitializeComponent();
        }

        public void InitializeGame()
        {
            state = "playing";

            asteroidsList.Clear();
            asteroidList.Clear();
            asteroidSpeeds.Clear();

            //asteroids start on left side of the screen
            Rectangle asteroid = new Rectangle(0, 100, asteroidSizeX, asteroidSizeY);
            asteroidsList.Add(asteroid);

            //asteroids start on right side of the screen
            Rectangle asteroids = new Rectangle(950, 100, asteroidSizeX, asteroidSizeY);
            asteroidList.Add(asteroids);
            asteroidSpeeds.Add(asteroidSpeed);

            //reset p1 and p2
            p1 = new Rectangle(300, 550, 15, 20);
            p2 = new Rectangle(600, 550, 15, 20);

            p1L1 = new Rectangle(200 + 106, 547, 3, 6);
            p1L2 = new Rectangle(197 + 106, 553, 9, 3);
            p1L3 = new Rectangle(194 + 106, 556, 15, 9);
            p1Red = new Rectangle(194 + 106, 559, 15, 3);
            p1L4 = new Rectangle(197 + 106, 565, 9, 3);
            p1L5 = new Rectangle(200 + 106, 562, 3, 3);
            p1L6 = new Rectangle(197 + 106, 565, 9, 6);
            p1L7 = new Rectangle(194 + 106, 571, 15, 3);

            p1Fire = new Rectangle(300, 581, 15, 6);
            p1MoreFire = new Rectangle(303, 587, 9, 6);
            p1ExtraFire = new Rectangle(306, 593, 3, 6);
            p1EvenMoreFire = new Rectangle(303, 581, 9, 6);

            p2L1 = new Rectangle(700 - 94, 547, 3, 6);
            p2L2 = new Rectangle(697 - 94, 553, 9, 3);
            p2L3 = new Rectangle(694 - 94, 556, 15, 9);
            p2Blue = new Rectangle(694 - 94, 559, 15, 3);
            p2L4 = new Rectangle(697 - 94, 565, 9, 3);
            p2L5 = new Rectangle(700 - 94, 562, 3, 3);
            p2L6 = new Rectangle(697 - 94, 565, 9, 6);
            p2L7 = new Rectangle(694 - 94, 571, 15, 3);

            p2Fire = new Rectangle(600, 581, 15, 6);
            p2MoreFire = new Rectangle(603, 587, 9, 6);
            p2ExtraFire = new Rectangle(606, 593, 3, 6);
            p2EvenMoreFire = new Rectangle(603, 581, 9, 6);

            //reset midline
            midLine = new Rectangle(470, 10, 10, 590);

            //reset player scores
            p1Score = 0;
            p2Score = 0;

            //player score outputs
            p1ScoreLabel.Text = Convert.ToString(p1Score);
            p2ScoreLabel.Text = Convert.ToString(p2Score);

            gameTimer.Enabled = true;

            titleLabel.Visible = false;
            subtitleLabel.Visible = false;
        }

        private void spaceRace_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:
                    if (state == "waiting" || state == "over")
                    {
                        InitializeGame();
                    }
                    if (state == "playing")
                    {

                    }
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
        private void spaceRace_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            state = "playing";

            titleLabel.Visible = false;
            subtitleLabel.Visible = false;

            //line in middle of the screen acts like a timer
            midLine.Y += timeSpeed;

            //move p2
            if (upDown == true && p2.Y >= 0)
            {
                p2.Y -= player2Speed;
                p2L1.Y -= player2Speed;
                p2L2.Y -= player2Speed;
                p2L3.Y -= player2Speed;
                p2Blue.Y -= player2Speed;
                p2L4.Y -= player2Speed;
                p2L5.Y -= player2Speed;
                p2L6.Y -= player2Speed;
                p2L7.Y -= player2Speed;
                p2Fire.Y -= player2Speed;
                p2MoreFire.Y -= player2Speed;
                p2ExtraFire.Y -= player2Speed;
                p2EvenMoreFire.Y -= player2Speed;
            }
            if (downDown == true && p2.Y <= this.Height - 30)
            {
                p2.Y += player2Speed;
                p2L1.Y += player2Speed;
                p2L2.Y += player2Speed;
                p2L3.Y += player2Speed;
                p2Blue.Y += player2Speed;
                p2L4.Y += player2Speed;
                p2L5.Y += player2Speed;
                p2L6.Y += player2Speed;
                p2L7.Y += player2Speed;
                p2Fire.Y += player2Speed;
                p2MoreFire.Y += player2Speed;
                p2ExtraFire.Y += player2Speed;
                p2EvenMoreFire.Y += player2Speed;
            }
            //move p1
            if (wDown == true && p1.Y >= 0)
            {
                p1.Y -= player1Speed;
                p1L1.Y -= player1Speed;
                p1L2.Y -= player1Speed;
                p1L3.Y -= player1Speed;
                p1Red.Y -= player1Speed;
                p1L4.Y -= player1Speed;
                p1L5.Y -= player1Speed;
                p1L6.Y -= player1Speed;
                p1L7.Y -= player1Speed;
                p1Fire.Y -= player1Speed;
                p1MoreFire.Y -= player1Speed;
                p1ExtraFire.Y -= player1Speed;
                p1EvenMoreFire.Y -= player1Speed;
            }
            if (sDown == true && p1.Y <= this.Height - 30)
            {
                p1.Y += player1Speed;
                p1L1.Y += player1Speed;
                p1L2.Y += player1Speed;
                p1L3.Y += player1Speed;
                p1Red.Y += player1Speed;
                p1L4.Y += player1Speed;
                p1L5.Y += player1Speed;
                p1L6.Y += player1Speed;
                p1L7.Y += player1Speed;
                p1Fire.Y += player1Speed;
                p1MoreFire.Y += player1Speed;
                p1ExtraFire.Y += player1Speed;
                p1EvenMoreFire.Y += player1Speed;
            }

            //generate new asteroid object (left side)
            randValue = randGen.Next(0, 101);

            if (randValue <= 20)
            {
                randValue = randGen.Next(10, this.Height - asteroidSizeY - 75);

                Rectangle asteroid = new Rectangle(0, randValue, asteroidSizeX, asteroidSizeY);
                asteroidsList.Add(asteroid);

                asteroidSpeed = randValue;
                asteroidSpeeds.Add(asteroidSpeed);
            }

            //generate new asteroid object (right side)
            randValue = randGen.Next(0, 101);

            if (randValue <= 20)
            {
                randValue = randGen.Next(10, this.Height - asteroidSizeY - 75);

                Rectangle asteroid = new Rectangle(950, randValue, asteroidSizeX, asteroidSizeY);
                asteroidList.Add(asteroid);

                asteroidSpeed = randValue;
                asteroidSpeeds.Add(asteroidSpeed);
            }

            //asteroids move (from left to right)
            randValue = randGen.Next(5, 20);
            for (int i = 0; i < asteroidsList.Count; i++)
            {
                int x = asteroidsList[i].X + asteroidSpeeds[i];
                asteroidsList[i] = new Rectangle(x, asteroidsList[i].Y, asteroidSizeX, asteroidSizeY);

                asteroidSpeed = randValue;
                asteroidSpeeds.Add(asteroidSpeed);
            }

            //asteroids move (from right to left)
            randValue = randGen.Next(5, 20);
            for (int i = 0; i < asteroidList.Count; i++)
            {
                int x = asteroidList[i].X - asteroidSpeeds[i];
                asteroidList[i] = new Rectangle(x, asteroidList[i].Y, asteroidSizeX, asteroidSizeY);

                asteroidSpeed = randValue;
                asteroidSpeeds.Add(asteroidSpeed);
            }

            //make asteroids dissapear at the edge of the screen
            for (int i = 0; i < asteroidsList.Count; i++)
            {
                if (asteroidsList[i].X >= this.Width)
                {
                    asteroidsList.RemoveAt(i);
                    asteroidSpeeds.RemoveAt(i);
                }
            }
            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (asteroidList[i].X <= 0)
                {
                    asteroidList.RemoveAt(i);
                    asteroidSpeeds.RemoveAt(i);
                }
            }

            //check if player 1 intersects with an asteroid
            for (int i = 0; i < asteroidsList.Count; i++)
            {
                if (p1.IntersectsWith(asteroidsList[i]))
                {
                    p1.Y = 550;
                    p1L1.Y = 547;
                    p1L2.Y = 553;
                    p1L3.Y = 556;
                    p1Red.Y = 559;
                    p1L4.Y = 565;
                    p1L5.Y = 562;
                    p1L6.Y = 565;
                    p1L7.Y = 571;

                    p1Fire.Y = 581;
                    p1MoreFire.Y = 587;
                    p1ExtraFire.Y = 593;
                    p1EvenMoreFire.Y = 581;
                }
            }
            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (p1.IntersectsWith(asteroidList[i]))
                {
                    p1.Y = 550;
                    p1L1.Y = 547;
                    p1L2.Y = 553;
                    p1L3.Y = 556;
                    p1Red.Y = 559;
                    p1L4.Y = 565;
                    p1L5.Y = 562;
                    p1L6.Y = 565;
                    p1L7.Y = 571;

                    p1Fire.Y = 581;
                    p1MoreFire.Y = 587;
                    p1ExtraFire.Y = 593;
                    p1EvenMoreFire.Y = 581;
                }
            }

            //check if player 2 intersects with an asteroid
            for (int i = 0; i < asteroidsList.Count; i++)
            {
                if (p2.IntersectsWith(asteroidsList[i]))
                {
                    p2.Y = 550;
                    p2L1.Y = 547;
                    p2L2.Y = 553;
                    p2L3.Y = 556;
                    p2Blue.Y = 559;
                    p2L4.Y = 565;
                    p2L5.Y = 562;
                    p2L6.Y = 565;
                    p2L7.Y = 571;

                    p2Fire.Y = 581;
                    p2MoreFire.Y = 587;
                    p2ExtraFire.Y = 593;
                    p2EvenMoreFire.Y = 581;
                }
            }
            for (int i = 0; i < asteroidList.Count; i++)
            {
                if (p2.IntersectsWith(asteroidList[i]))
                {
                    p2.Y = 550;
                    p2L1.Y = 547;
                    p2L2.Y = 553;
                    p2L3.Y = 556;
                    p2Blue.Y = 559;
                    p2L4.Y = 565;
                    p2L5.Y = 562;
                    p2L6.Y = 565;
                    p2L7.Y = 571;

                    p2Fire.Y = 581;
                    p2MoreFire.Y = 587;
                    p2ExtraFire.Y = 593;
                    p2EvenMoreFire.Y = 581;
                }
            }

            //check if players hit the top and add 1 to total score
            for (int i = 0; i < asteroidsList.Count; i++)
            {
                if (p1.Y < 0)
                {
                    levelUpSound.Play();

                    p1.Y = 550;
                    p1L1.Y = 547;
                    p1L2.Y = 553;
                    p1L3.Y = 556;
                    p1Red.Y = 559;
                    p1L4.Y = 565;
                    p1L5.Y = 562;
                    p1L6.Y = 565;
                    p1L7.Y = 571;

                    p1Fire.Y = 581;
                    p1MoreFire.Y = 587;
                    p1ExtraFire.Y = 593;
                    p1EvenMoreFire.Y = 581;

                    p1Score++;
                    p1ScoreLabel.Text = Convert.ToString(p1Score);
                }
                if (p2.Y < 0)
                {
                    levelUpSound.Play();

                    p2.Y = 550;
                    p2L1.Y = 547;
                    p2L2.Y = 553;
                    p2L3.Y = 556;
                    p2Blue.Y = 559;
                    p2L4.Y = 565;
                    p2L5.Y = 562;
                    p2L6.Y = 565;
                    p2L7.Y = 571;

                    p2Fire.Y = 581;
                    p2MoreFire.Y = 587;
                    p2ExtraFire.Y = 593;
                    p2EvenMoreFire.Y = 581;

                    p2Score++;
                    p2ScoreLabel.Text = Convert.ToString(p2Score);
                }
            }

            //check if time has run out
            for (int i = 0; i < asteroidsList.Count; i++)
            {
                if (midLine.Y > 600)
                {
                    state = "over";

                    gameTimer.Stop();
                }
            }

            //check if a players score reaches 3
            for (int i = 0; i < asteroidsList.Count; i++)
            {
                if (p1Score == 3 || p2Score == 3)
                {
                    state = "over";
                }
            }

            Refresh();
        }

        private void spaceRace_Paint(object sender, PaintEventArgs e)
        {
            if (state == "waiting")
            {
                rocketShipBox.Visible = true;
                titleScreenSound.Play();
            }

            if (state == "playing")
            {
                rocketShipBox.Visible = false;
                //players
                e.Graphics.FillRectangle(whiteBrush, p1L1);
                e.Graphics.FillRectangle(whiteBrush, p1L2);
                e.Graphics.FillRectangle(whiteBrush, p1L3);
                e.Graphics.FillRectangle(redBrush, p1Red);
                e.Graphics.FillRectangle(whiteBrush, p1L4);
                e.Graphics.FillRectangle(whiteBrush, p1L5);
                e.Graphics.FillRectangle(whiteBrush, p1L6);
                e.Graphics.FillRectangle(whiteBrush, p1L7);

                e.Graphics.FillRectangle(whiteBrush, p2L1);
                e.Graphics.FillRectangle(whiteBrush, p2L2);
                e.Graphics.FillRectangle(whiteBrush, p2L3);
                e.Graphics.FillRectangle(blueBrush, p2Blue);
                e.Graphics.FillRectangle(whiteBrush, p2L4);
                e.Graphics.FillRectangle(whiteBrush, p2L5);
                e.Graphics.FillRectangle(whiteBrush, p2L6);
                e.Graphics.FillRectangle(whiteBrush, p2L7);

                //midline
                e.Graphics.FillRectangle(whiteBrush, midLine);

                //asteroids
                for (int i = 0; i < asteroidsList.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, asteroidsList[i]);
                }
                for (int i = 0; i < asteroidList.Count; i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, asteroidList[i]);
                }

                //rocket boosters
                if (wDown == true)
                {
                    e.Graphics.FillRectangle(orangeBrush, p1Fire);
                    e.Graphics.FillRectangle(orangeBrush, p1MoreFire);
                    e.Graphics.FillRectangle(orangeBrush, p1ExtraFire);
                    e.Graphics.FillRectangle(redBrush, p1EvenMoreFire);
                }
                if (upDown == true)
                {
                    e.Graphics.FillRectangle(orangeBrush, p2Fire);
                    e.Graphics.FillRectangle(orangeBrush, p2MoreFire);
                    e.Graphics.FillRectangle(orangeBrush, p2ExtraFire);
                    e.Graphics.FillRectangle(redBrush, p2EvenMoreFire);
                }
            }

            if (state == "over")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;
                rocketShipBox.Visible = true;

                titleScreenSound.Play();

                if (p1Score > p2Score)
                {
                    subtitleLabel.Text = "Player 1 wins! \n Press ESC to exit or SPACE to play again.";
                }
                if (p2Score > p1Score)
                {
                    subtitleLabel.Text = "Player 2 wins! \n Press ESC to exit or SPACE to play again.";
                }
                if (p1Score == p2Score)
                {
                    subtitleLabel.Text = "It's a tie. \n Press ESC to exit or SPACE to play again.";
                }
            }
        }
    }
}
