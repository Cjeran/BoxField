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

        //Box Timer
        int boxTimer;
        public int location;
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
            location = 25;
            //TODO - set game start values
            Box b1 = new Box(location, 0, 25);
            leftBoxes.Add(b1);
            Box b2 = new Box(this.Width - location - b1.size, 0, 25);
            rightBoxes.Add(b2);
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
            //TODO - update location of all boxes (drop down screen)
            foreach (Box b in leftBoxes)
            {
                b.y = b.y + 5;
            }

            foreach (Box b in rightBoxes)
            {
                b.y = b.y + 5;
            }
            //TODO - remove box if it has gone of screen
            if (leftBoxes[0].y >= this.Height)
            {
                leftBoxes.Remove(leftBoxes[0]);
            }
            if (rightBoxes[0].y >= this.Height)
            {
                rightBoxes.Remove(rightBoxes[0]);
            }
            //TODO - add new box if it is time
            boxTimer++;
            if (boxTimer % 8 == 0)
            {
                Box b1 = new Box(location, 0, 25);
                leftBoxes.Add(b1);
                Box b2 = new Box(this.Width - location - b1.size, 0, 25);
                rightBoxes.Add(b2);
                boxTimer = 0;
            }
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO - draw boxes to screen
            foreach (Box b in leftBoxes)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }
            foreach (Box b in rightBoxes)
            {
                e.Graphics.FillRectangle(boxBrush, b.x, b.y, b.size, b.size);
            }

        }
    }
}
