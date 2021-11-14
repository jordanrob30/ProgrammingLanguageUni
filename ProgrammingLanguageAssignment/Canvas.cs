using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProgrammingLanguageAssignment
{
    public class Canvas
    {
        /// <summary>
        /// Graphics Instance used to draw to the screen
        /// </summary>
        Graphics g;

        /// <summary>
        /// Pen instance used for outputted data
        /// </summary>
        public Pen Pen;

        /// <summary>
        /// Brush used for filling Shapes
        /// </summary>
        public Brush brush;

        /// <summary>
        /// X and Y Postions for current instance
        /// </summary>
        public int xPos, yPos = 0;

        /// <summary>
        /// Local bool to determine if a shape should be filled
        /// </summary>
        public bool fill = false;

        /// <summary>
        /// Constructor responsible for assigning local Graphics object and inital Pen Colour (Black)
        /// </summary>
        /// <param name="g"></param>
        public Canvas(Graphics g)
        {
            this.g = g;
            this.Pen = new Pen(Color.Black, 1);

            this.drawPositionIndicator();
        }

        /// <summary>
        /// TODO: To introduce later
        /// </summary>
        public void drawPositionIndicator()
        {
            //int indicatorSize = 2;
            //g.DrawEllipse(this.Pen, this.xPos - indicatorSize, this.yPos - indicatorSize, indicatorSize * 2, indicatorSize * 2);
        }

        /// <summary>
        /// Draws a line to provided X and Y values
        /// </summary>
        /// <param name="toX">X Position of where to draw to</param>
        /// <param name="toY">Y Position of where to draw to</param>
        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(this.Pen, this.xPos, this.yPos, toX, toY);

            //move positions to end of the line so new shapes are drawn there
            this.xPos = toX;
            this.yPos = toY;
        }

        /// <summary>
        /// Draws a square to the provided bit map
        /// </summary>
        /// <param name="size">size in pixels of square</param>
        public void DrawSquare(int size)
        {
            g.DrawRectangle(this.Pen, this.xPos, this.yPos, this.xPos + size, this.yPos + size);

            if(this.fill)
            {
                g.FillRectangle(this.brush, this.xPos, this.yPos, this.xPos + size, this.yPos + size);
            }
        }

        /// <summary>
        /// Draws a rectangle at the current x,y position with the provided height and width
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(this.Pen, this.xPos, this.yPos, this.xPos + width, this.yPos + height);

            if (this.fill)
            {
                g.FillRectangle(this.brush, this.xPos, this.yPos, this.xPos + width, this.yPos + height);
            }
        }


        /// <summary>
        /// Draws a circle to the screen with the provided radius
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(int radius)
        {
            g.DrawEllipse(this.Pen, this.xPos - radius, this.yPos - radius, radius * 2, radius * 2);

            if (this.fill)
            {
                g.FillEllipse(this.brush, this.xPos - radius, this.yPos - radius, radius * 2, radius * 2);
            }
        }

        /// <summary>
        /// Draws an Equilateral triangle to the screen with the provided width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawTriangle(int width, int height)
        {
            int originalX = this.xPos;
            int originalY = this.yPos;

            Point[] points = new Point[3];

            points[0].X = this.xPos + (width / 2);
            points[0].Y = this.yPos + height;

            this.xPos = points[0].X;
            this.yPos = points[0].Y;

            points[1].X = this.xPos - width;
            points[1].Y = this.yPos;

            this.xPos = this.xPos - width;

            points[2].X = originalX;
            points[2].Y = originalY;

            this.xPos = originalX;
            this.yPos = originalY;

            g.DrawPolygon(this.Pen, points);

            if (this.fill)
            {
                g.FillPolygon(this.brush, points);
            }
        }

        /// <summary>
        /// Clears the bitmap to the original colour
        /// </summary>
        public void Clear()
        {
            this.g.Clear(Color.Gray);
        }
    }
}
