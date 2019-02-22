using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxField
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown;

        //used to draw boxes on screen
        SolidBrush boxBrush = new SolidBrush(Color.White);

        //lists to hold columns of boxes        
        new List<Box> leftBoxes = new List<Box>();
        new List<Box> rightBoxes = new List<Box>();
        new List<Box> hero = new List<Box>();

        //Custom Variables
        int boxTimer;
        public int location, c, change;
        Random randGen = new Random();
        Boolean moveRight = true;
        int boxSpeed = 5;
        Box p;

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {
            location = this.Width / 2 - 75;
            c = 1;
            //game start values
            Box b1 = new Box(location, 0, 25, c);
            leftBoxes.Add(b1);
            leftBoxes.Add(b1);
            leftBoxes.Add(b1);
            Box b2 = new Box(location + 125, 0, 25, c);
            rightBoxes.Add(b2);
            p = new Box(this.Width / 2 - b1.size, this.Height - 100, 25, 7);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //Moves All Boxes Down Screen
            foreach (Box b in leftBoxes){b.Move(boxSpeed);}
            foreach (Box b in rightBoxes){b.Move(boxSpeed);}

            //Check and remove the bottom box if it has gone off screen
            if (leftBoxes[0].y >= this.Height){leftBoxes.Remove(leftBoxes[0]);}
            if (rightBoxes[0].y >= this.Height){rightBoxes.Remove(rightBoxes[0]);}

            //Randomly change direction, 1 in 50
            change = randGen.Next(1, 101);
            if (change <= 2){moveRight = !moveRight;}

            //If the boxes collide with walls, change direction
            if (location >= this.Width - 300){moveRight = false;}
            else if (location <= 0){moveRight = true;}
            else { }

            //Detect Movement
            if (leftBoxes[2].x + 50 >= p.x){p.Move(2, "right");}
            else if (leftBoxes[2].x + 50 <= p.x){p.Move(2, "left");}

            boxTimer++;
            if (boxTimer % 8 == 0)
            {
                if (moveRight == true)
                {
                    location = location + 10;
                } else
                {
                    location = location - 10;
                }
                c = randGen.Next(1, 6);
                Box b1 = new Box(location, 0, 25, c);
                leftBoxes.Add(b1);
                Box b2 = new Box(location + 125, 0, 25, c);
                rightBoxes.Add(b2);
                boxTimer = 0;
            }

            foreach (Box b in leftBoxes.Union(rightBoxes))
            {
                if (p.Collision(b))
                {
                    gameLoop.Stop();
                }
                else { }
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO - draw boxes to screen
            foreach (Box b in leftBoxes)
            {
                e.Graphics.FillRectangle(b.brush, b.x, b.y, b.size, b.size);
            }
            foreach (Box b in rightBoxes)
            {
                e.Graphics.FillRectangle(b.brush, b.x, b.y, b.size, b.size);
            }
                e.Graphics.FillRectangle(p.brush, p.x, p.y, p.size, p.size);
        }
    }
}
