using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graphical_Programming_Language_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_Programming_Language_App.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void getXTest()
        {
            //arrange
            int x;
            Form1 form = new Form1();

            //act
            x = form.getX();

            //assert
            int xActual = x;
            Assert.AreEqual(0, xActual);
        }
        [TestMethod()]
        public void getYTest()
        {
            //arrange
            int y;
            Form1 form = new Form1();

            //act
            y = form.getY();

            //assert
            int yActual = y;
            Assert.AreEqual(0, yActual);

        }

        [TestMethod()]
        public void moveToTest()
        {
            //arrange
            int x = 20, y = 20;
            int expectedX = x;
            int expectedY = y;
            Form1 form = new Form1();

            //act
            form.moveTo(x,y);

            //assert
            int xActual = form.getX();
            int yActual = form.getY();
            Assert.AreEqual(expectedX, xActual);
            Assert.AreEqual(expectedY, yActual);

        }

        [TestMethod()]
        public void drawLineTest()
        {
            //arrange
            Form1 form = new Form1();
            form.moveTo(0, 0);
            int x = 20, y = 20;
            int expectedX = x;
            int expectedY = y;
            

            //act
            form.drawLine(x, y);

            //assert
            int xActual = form.getX();
            int yActual = form.getY();
            Assert.AreEqual(expectedX, xActual);
            Assert.AreEqual(expectedY, yActual);
        }

        [TestMethod()]
        public void drawRectangleTest()
        {
            //arrange
            Form1 form = new Form1();
            form.moveTo(100, 100);
            int width = 100, height = 50;
            int expectedX = 100 + width;
            int expectedY = 100 + height;
            

            //act
            form.drawRectangle(width, height);

            //assert
            int xActual = form.getX();
            int yActual = form.getY();
            Assert.AreEqual(expectedX, xActual);
            Assert.AreEqual(expectedY, yActual);
        }

        [TestMethod()]
        public void drawCircleTest()
        {
            //arrange
            Form1 form = new Form1();
            form.moveTo(100, 100);
            int radius = 50;
            int expectedX = 100;
            int expectedY = 100;
            

            //act
            form.drawCircle(radius);

            //assert
            int xActual = form.getX();
            int yActual = form.getY();
            Assert.AreEqual(expectedX, xActual);
            Assert.AreEqual(expectedY, yActual);
        }

        [TestMethod()]
        public void drawTriangleTest()
        {

        }

        [TestMethod()]
        public void drawPloygonTest()
        {
            //arrange
            Form1 form = new Form1();
            form.moveTo(100, 100);
            int expectedX = 100;
            int expectedY = 100;
            Point[] p = new Point[4];
            p[0].X = 100;
            p[0].Y = 100;
            p[1].X = 100;
            p[1].Y = 150;
            p[2].X = 50;
            p[2].Y = 150;
            p[3].X = 50;
            p[3].Y = 100;

            //act
            form.drawPolygon(p);

            //assert
            int xActual = form.getX();
            int yActual = form.getY();
            Assert.AreEqual(expectedX, xActual);
            Assert.AreEqual(expectedY, yActual);

        }

    }
}