using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxField
{
    class Box
    {
        public int x, y, size, colour;
        public SolidBrush brush = new SolidBrush(Color.Black);
        public Boolean collision = false;
        //Need Colour Eventually
        
        public Box (int _x, int _y, int _size, int _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            if (_colour == 1)
            {
                brush = new SolidBrush(Color.Maroon);
            }
            else if (_colour == 2)
            {
                brush = new SolidBrush(Color.Firebrick);
            }
            else if (_colour == 3)
            {
                brush = new SolidBrush(Color.LightCoral);
            }
            else if (_colour == 4)
            {
                brush = new SolidBrush(Color.Red);
            }
            else if (_colour == 7)
            {
                brush = new SolidBrush(Color.Cyan);
            }
            else
            {
                brush = new SolidBrush(Color.IndianRed);
            }

        }

        public void Move(int speed)
        {
            y += speed;
        }
        public void Move(int speed, string direction)
        {
            //Depending on direction, move box
            if (direction == "right"){x += speed;}
            else if (direction == "left") { x -= speed;}
            else {}
        }
        public bool Collision(Box b)
        {
            Rectangle rec1 = new Rectangle(b.x, b.y, b.size, b.size);
            Rectangle rec2 = new Rectangle(x, y, size, size);
            if (rec1.IntersectsWith(rec2))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
