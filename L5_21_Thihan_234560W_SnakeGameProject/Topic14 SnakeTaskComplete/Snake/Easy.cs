using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Easy : Form
    {

        Snake mySnake;
        Board mainBoard;
        Rewards apples;

        string mode;
        Timer clock;
        int duration; //How long the game has been running
        int speed = 500; //500ms
        int score;
        int level;

        public Easy()
        {
            InitializeComponent();

            //You don't have to worry about the auto-size
            this.AutoSize = true;       //The size of the Form will autoadjust.
            boardPanel.AutoSize = true; //The size of the panel grouping all the squares will auto-adjust

            //Set up the main board
            mainBoard = new Board(this);

            //Set up the game timer at the given speed
            clock = new Timer();
            clock.Interval = speed; //Set the clock to tick every 500ms
            clock.Tick += new EventHandler(refresh); //Call the refresh method at every tick to redraw the board and snake.

            duration = 0;
            score = 0;
            level = 1;
            modeLBL.Text = mode;

            gotoNextLevel(level);

        }

        private void gotoNextLevel(int nextLevel)
        {
            mode = "REST";
            mySnake = new Snake(mainBoard); //Brand new snake with length 1
            apples = new Rewards(nextLevel, mainBoard); //<--- Generate 5 apples
        }

        private void upBTN_Click(object sender, EventArgs e)
        {
            mode = "UP";  //Just record the mode. The moving will be done in refresh method
        }

        private void downBTN_Click(object sender, EventArgs e)
        {
            mode = "DOWN";
        }

        private void leftBTN_Click(object sender, EventArgs e)
        {
            mode = "LEFT";
        }

        private void rightBTN_Click(object sender, EventArgs e)
        {
            mode = "RIGHT";
        }

        private void refresh(Object myObject, EventArgs myEventArgs)
        {
            mySnake.move(mode); //Move the snake based on mode
            modeLBL.Text = mode;

            mainBoard.draw();
            apples.draw();  //<----- draw apples
            mySnake.draw();

            //increment the duration by amount of time that has passed
            //this method is called every speed millisecond
            duration += speed;
            timerLBL.Text = Convert.ToString(duration / 1000); //Show time passed


            //Check if snke is biting itself. If so, call GameOver.
            if (mySnake.checkEatItself() == true)
            {
                GameOver();
            }
            else if (apples.checkIFSnakeHeadEatApple( mySnake.getHeadPosition()) == true)
            {
                score += apples.eatAppleAtPostion(mySnake.getHeadPosition());

                scoreLBL.Text = Convert.ToString(score);


                if (apples.noMoreApples() == true)
                {
                    clock.Stop();
                    level++;
                    levelLBL.Text = Convert.ToString(level);
                    gotoNextLevel(level);
                    MessageBox.Show("Press the start button to go to Level " + level, "Congrats");
                }
                else
                {
                    //Length the snake and continue with the Game
                    mySnake.extendBody();
                }
            }
        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            clock.Start();
        }

        private void pauseBTN_Click(object sender, EventArgs e)
        {
            clock.Stop();
        }

        private void GameOver()
        {
            clock.Stop();
            MessageBox.Show("Your time taken is " + duration/1000 + " seconds. Bye Bye", "Game Over");
            this.Close();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the game?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                // Do nothing, let the Menu page remian open
            }
            else
            {
                Menu form = new Menu();
                form.Show();
                this.Hide();
            }
        }
    }
}
