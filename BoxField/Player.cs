using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxField
{
    class Player
    {
        public int x, y;
        public PointF[] drawHero;
        public SolidBrush heroBrush = new SolidBrush(Color.Blue);

        public Player (int _x, int _y)
        {
            x = _x;
            y = _y;
            PointF[] points = {
                new Point(_x, _y),
                new Point(_x - 5, _y + 20),
                new Point(_x + 5, _y + 20)
            };

        }
        
    
    }
}
