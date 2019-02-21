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
        //Need Colour Eventually
        
        public Box (int _x, int _y, int _size, int _colour)
        {
            x = _x;
            y = _y;
            size = _size;
            if (_colour == 1)
            {
                brush = new SolidBrush(Color.Maroon);
            } else if (_colour == 2)
            {
                brush = new SolidBrush(Color.Firebrick);
            } else if (_colour == 3)
            {
                brush = new SolidBrush(Color.LightCoral);
            } else if (_colour == 4)
            {
                brush = new SolidBrush(Color.Red);
            } else
            {
                brush = new SolidBrush(Color.IndianRed);
            }
        }
    }
}
