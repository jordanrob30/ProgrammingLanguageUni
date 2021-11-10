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
        Pen Pen;

        /*
         * X and Y Postions for current instance
         */
        public int xPos = 0;
        public int yPos = 0;

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
        }

        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(this.Pen, this.xPos, this.yPos, this.xPos + width, this.yPos + height);
        }


        public void DrawCircle(int radius)
        {
            g.DrawEllipse(this.Pen, this.xPos - radius, this.yPos - radius, radius * 2, radius * 2);
        }

        /**
         * https://stackoverflow.com/questions/54974422/fill-a-drawn-triangle-using-lines
         * */
        public void DrawTriangle(int width, int height)
        {
            int originalX = this.xPos;
            int originalY = this.yPos;

            this.DrawLine(this.xPos + (width / 2), this.yPos + height);
            this.DrawLine(this.xPos - width, this.yPos);
            this.DrawLine(originalX, originalY);
        }

        public void Clear()
        {
            this.g.Clear(Color.Gray);
        }
    }
}
