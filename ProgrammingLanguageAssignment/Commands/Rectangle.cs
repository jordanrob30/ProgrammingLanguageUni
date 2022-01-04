using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Class responsible for the rectangle -w -h command
    /// </summary>
    public class Rectangle : DrawCommand
    {
        /// <summary>
        /// Stored width and height values of the rectangle
        /// </summary>
        public int width, height = 0;

        /// <summary>
        /// Draws the rectangle on a provided canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public override bool Execute(Canvas canvas)
        {
            canvas.DrawRectangle(this.width, this.height);

            return true;
        }

        /// <summary>
        /// Parses provided arguments into int values and assigns to local width and height values
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(string[] args, IDictionary<string, string> varDict)
        {
            this.width = Int32.Parse(args[0]);
            this.height = Int32.Parse(args[1]);
        }

        /// <summary>
        /// Ensures provided arguments are valid and returns an error message if not.
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
                return "Invalid arguments, expecting rectangle <width>,<height>";
            }
        }
    }
}
