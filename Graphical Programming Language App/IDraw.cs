using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language_App
{
    interface IDraw
    {
        int getX();

        int getY();

        void moveTo( int x, int y);

        void drawLine(int x, int y);

        void drawRectangle(int width, int height);

        void drawCircle(int radius);

        void drawTriangle(int b, int height);

        void drawPolygon(Point[] p);
    }
}
