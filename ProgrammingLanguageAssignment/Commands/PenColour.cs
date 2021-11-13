using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProgrammingLanguageAssignment
{

    class PenColour : DrawCommand
    {
        public string canvasColour;

        List<string> allowedColours = new List<string> { "red", "blue", "green", "black" };

        public override bool Execute(Canvas canvas)
        {
            switch(this.canvasColour)
            {
                case "red":
                    canvas.Pen.Color = Color.Red;
                    canvas.brush = new SolidBrush(Color.Red);
                    break;
                case "blue":
                    canvas.Pen.Color = Color.Blue;
                    canvas.brush = new SolidBrush(Color.Blue);
                    break;
                case "green":
                    canvas.Pen.Color = Color.Green;
                    canvas.brush = new SolidBrush(Color.Green);
                    break;
                case "black":
                    canvas.Pen.Color = Color.Black;
                    canvas.brush = new SolidBrush(Color.Black);
                    break;
            }

            return true;
        }

        public override void ParseArguments(string[] args)
        {
            String chosenColour = args[0];


            foreach(string colour in this.allowedColours)
            {
                if(chosenColour == colour)
                {
                    this.canvasColour = chosenColour;
                    break;
                } else
                {
                    //add validation
                    this.canvasColour = "black";
                }
            }
        }

        public override string validateArguments(string[] args)
        {
            try
            {
                String chosenColour = args[0];
                bool validColour = false;
                foreach (String color in this.allowedColours)
                {
                    if(chosenColour == color)
                    {
                        validColour = true;
                        break;
                    }
                }

                if (!validColour) return "Pen must be <red, blue, green, black>";

                return "";
            }
            catch (Exception e)
            {
                return "Invalid arguments, pen <color>";
            }
        }
    }
}
