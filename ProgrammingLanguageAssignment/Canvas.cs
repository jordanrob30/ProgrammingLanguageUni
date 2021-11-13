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
        //Graphics Instance used to draw to the screen
        Graphics g;

        //Pen instance used for outputted data
        public Pen Pen;

        public Brush brush;

        /*
         * X and Y Postions for current instance
         */
        public int xPos = 0;
        public int yPos = 0;

        public bool fill = false;

        public Canvas(Graphics g)
        {
            this.g = g;
            this.Pen = new Pen(Color.Black, 1);

            this.drawPositionIndicator();
        }

        public void drawPositionIndicator()
        {
            //int indicatorSize = 2;
            //g.DrawEllipse(this.Pen, this.xPos - indicatorSize, this.yPos - indicatorSize, indicatorSize * 2, indicatorSize * 2);
        }

        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(this.Pen, this.xPos, this.yPos, toX, toY);

            //move positions to end of the line so new shapes are drawn there
            this.xPos = toX;
            this.yPos = toY;
        }

        public void DrawSquare(int size)
        {
            g.DrawRectangle(this.Pen, this.xPos, this.yPos, this.xPos + size, this.yPos + size);

            if(this.fill)
            {
                g.FillRectangle(this.brush, this.xPos, this.yPos, this.xPos + size, this.yPos + size);
            }
        }

        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(this.Pen, this.xPos, this.yPos, this.xPos + width, this.yPos + height);

            if (this.fill)
            {
                g.FillRectangle(this.brush, this.xPos, this.yPos, this.xPos + width, this.yPos + height);
            }
        }


        public void DrawCircle(int radius)
        {
            g.DrawEllipse(this.Pen, this.xPos - radius, this.yPos - radius, radius * 2, radius * 2);

            if (this.fill)
            {
                g.FillEllipse(this.brush, this.xPos - radius, this.yPos - radius, radius * 2, radius * 2);
            }
        }

        /**
         * https://stackoverflow.com/questions/54974422/fill-a-drawn-triangle-using-lines
         * */
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

        public void Clear()
        {
            this.g.Clear(Color.Gray);
        }
    }
}
