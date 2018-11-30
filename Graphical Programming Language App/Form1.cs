using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Graphical_Programming_Language_App
{
    public partial class Form1 : Form, IDraw
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen myPen = new Pen(System.Drawing.Color.Black);
        int x = 0, y = 0, radius = 0, width = 0, height = 0, counter = 0;
        int loop = 0, kStart = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            string command = textBox1.Text;
            read(command);
        }

        public void read(string command)
        {
            command = command.ToLower();
            String[] commandline = command.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int k = 0; k < commandline.Length; k++)
            {
                string[] commands = commandline[k].Split(' ');

                if (commands[0].Equals("moveto"))
                {
                    string[] coordinates = commands[1].Split(',');
                    int x = 0, y = 0;
                    Int32.TryParse(coordinates[0], out x);
                    Int32.TryParse(coordinates[1], out y);
                    moveTo(x, y);
                    Console.WriteLine(x + "," + y);
                }
                else
                if (commands[0].Equals("drawto"))
                {
                    string[] coordinates = commands[1].Split(',');
                    int x, y;
                    Int32.TryParse(coordinates[0], out x);
                    Int32.TryParse(coordinates[1], out y);
                    drawLine(x, y);
                    Console.WriteLine(x + "," + y);
                }
                else
                if (commands[0].Equals("rectangle"))
                {
                    string[] dimensions = commands[1].Split(',');
                    if (!dimensions[0].Equals("width"))
                    {
                        Int32.TryParse(dimensions[0], out width);
                    }
                    if (!dimensions[1].Equals("height"))
                    {
                        Int32.TryParse(dimensions[1], out height);
                    }
                    drawRectangle(width, height);
                }
                else
                if (commands[0].Equals("circle"))
                {
                    if (!commands[1].Equals("radius"))
                    {
                        Int32.TryParse(commands[1], out radius);
                    }
                    drawCircle(radius);
                }
                else
                if (commands[0].Equals("triangle"))
                {
                    string[] dimensions = commands[1].Split(',');
                    if (!dimensions[0].Equals("width"))
                    {
                        Int32.TryParse(dimensions[0], out width);
                    }
                    if (!dimensions[1].Equals("height"))
                    {
                        Int32.TryParse(dimensions[1], out height);
                    }
                    drawTriangle(width, height);
                }
                else
                 if (commands[0].Equals("polygon"))
                {
                    string[] points = commands[1].Split(',');
                    if (points.Length > 2 && points.Length % 2 == 0)
                    {
                        Point[] p = new Point[points.Length / 2];
                        int j = 0;
                        for (int i = 0; i < points.Length; i = i + 2)
                        {
                            Int32.TryParse(points[i], out int point);
                            p[j].X = point;
                            Int32.TryParse(points[i + 1], out point);
                            p[j].Y = point;
                            j++;
                        }
                        drawPolygon(p);
                    }
                }
                else
                    if (commands[0].Equals("radius"))
                {
                    if (commands[1].Equals("="))
                    {
                        Int32.TryParse(commands[2], out radius);
                        Console.WriteLine(radius);
                    }
                    else
                    if (commands[1].Equals("+"))
                    {
                        int r;
                        Int32.TryParse(commands[2], out r);
                        radius = radius + r;
                        Console.WriteLine(radius);
                    }
                    else
                    if (commands[1].Equals("-"))
                    {
                        int r;
                        Int32.TryParse(commands[2], out r);
                        radius = radius - r;
                    }

                }
                else
                    if (commands[0].Equals("width"))
                {
                    if (commands[1].Equals("="))
                    {
                        Int32.TryParse(commands[2], out width);
                        Console.WriteLine(width);
                    }
                    else
                    if (commands[1].Equals("+"))
                    {
                        int w;
                        Int32.TryParse(commands[2], out w);
                        width = width + w;
                    }
                    else
                    if (commands[1].Equals("-"))
                    {
                        int w;
                        Int32.TryParse(commands[2], out w);
                        width = width - w;
                    }
                }
                else
                    if (commands[0].Equals("height"))
                {
                    if (commands[1].Equals("="))
                    {
                        Int32.TryParse(commands[2], out height);
                        Console.WriteLine(height);
                    }
                    else
                    if (commands[1].Equals("+"))
                    {
                        int h;
                        Int32.TryParse(commands[2], out h);
                        height = height + h;
                    }
                    else
                    if (commands[1].Equals("-"))
                    {
                        int h;
                        Int32.TryParse(commands[2], out h);
                        height = height - h;
                    }
                }
                else
                    if (commands[0].Equals("loop"))
                {
                    if (loop == 0)
                    {
                        Int32.TryParse(commands[1], out counter);
                        kStart = k;
                    }

                }
                else
                    if (commands[0].Equals("if"))
                {
                    if(commands[1].Equals ("counter") && commands[2].Equals("=") && commands[4].Equals("then"))
                    {

                    }

                }
                else
                if (commands[0].Equals("end"))
                {
                    if (counter > 0)
                    {
                        loop++;
                    }
                    if (counter == loop)
                    {
                        counter = 0;
                        loop = 0;

                    }
                    else
                    {
                        k = kStart;
                    }

                }

            }

        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public void moveTo(int toX, int toY)
        {
            x = toX;
            y = toY;
        }

        public void drawLine(int toX, int toY)
        {
            Graphics graphicsObj = this.CreateGraphics();
            graphicsObj.DrawLine(myPen, x, y, toX, toY);
            moveTo(toX, toY);
        }

        public void drawRectangle(int width, int height)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.DrawRectangle(myPen, x, y, width, height);
            x = x + width;
            y = y + height;
        }

        public void drawCircle(int radius)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.DrawEllipse(myPen, x, y, radius, radius);
        }

        public void drawTriangle(int width, int height)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Point[] p = new Point[3];
            p[0].X = x;
            p[0].Y = y;

            p[1].X = x + width;
            p[1].Y = y;

            p[2].X = x + width;
            p[2].Y = y - height;

            graphicsObj.DrawPolygon(myPen, p);

        }

        public void drawPolygon(Point[] sides)
        {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            graphicsObj.DrawPolygon(myPen, sides);
        }

    }
}
