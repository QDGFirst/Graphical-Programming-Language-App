using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language_App
{
    interface IDraw
    {
        void moveTo();

        void drawLine();

        void drawRectangle();

        void drawCircle();

        void drawTriangle();

        void drawPolygon();
    }
}
