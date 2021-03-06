using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProgrammingLanguageAssignment
{
    public class MoveTo : DrawCommand
    {
        /// <summary>
        /// X Y values to move to
        /// </summary>
        public int x, y = 0;

        /// <summary>
        /// Moves the X and Y positions of a provided Cavas instance
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public override bool Execute(Canvas canvas)
        {
            canvas.xPos = this.x;
            canvas.yPos = this.y;

            canvas.drawPositionIndicator();

            return true;
        }

        /// <summary>
        /// Parses the provided data to ensure X and Y are int values
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(String[] args, IDictionary<string, string> varDict)
        {
            try {
                this.x = Int32.Parse(args[0]);
                this.y = Int32.Parse(args[1]);
            } catch
            {
                //presume variable was passed in
                this.x = Int32.Parse(varDict[args[0]]);
                this.y = Int32.Parse(varDict[args[1]]);
            }
        }

        /// <summary>
        /// Validates the provided data and returns an error message if provided arguments are invalid
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override string validateArguments(string[] args, IDictionary<string, string> varDict)
        {
            try
            {
                Int32.Parse(args[0]);
                Int32.Parse(args[1]);

                return "";
            }
            catch (Exception e)
            {
                return "Invalid arguments, expecting moveTo <X>,<Y>";
            }
        }
    }
}
