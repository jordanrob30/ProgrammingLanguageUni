using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Class resposible for managing the "pen -colour" command
    /// </summary>
    public class PenColour : DrawCommand
    {
        /// <summary>
        /// The colour will be set to the value set here
        /// </summary>
        public string canvasColour;

        /// <summary>
        /// Allowed Colour list as these will be translated to Color models
        /// </summary>
        List<string> allowedColours = new List<string> { "red", "blue", "green", "black" };

        /// <summary>
        /// Updates the colour set on the provided canvas instance
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Parse the data provided to ensure no invalid colours are passed
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(string[] args, IDictionary<string, string> varDict)
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

        /// <summary>
        /// Validate the arguments provided to ensure the colours given are a valid option
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override string validateArguments(string[] args, IDictionary<string, string> varDict)
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
