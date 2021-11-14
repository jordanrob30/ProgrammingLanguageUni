using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Class responsible for drawing a triangle to the screen
    /// </summary>
    public class Triangle : DrawCommand
    {
        public int width, height = 0;

        /// <summary>
        /// Triggers the DrawTriangle method on a provided canvas instance
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public override bool Execute(Canvas canvas)
        {
            canvas.DrawTriangle(this.width, this.height);
            return true;
        }

        /// <summary>
        /// Parses the provided arguments into int values
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(string[] args)
        {
            this.width = Int32.Parse(args[0]);
            this.height = Int32.Parse(args[1]);
        }

        /// <summary>
        /// Validates the parameters to ensure they can be parsed to ints
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override string validateArguments(string[] args)
        {
            try
            {
                Int32.Parse(args[0]);
                Int32.Parse(args[1]);

                return "";
            } catch (Exception e)
            {
                return "Invalid arguments, expecting triangle <width>,<height>";
            }
        }
    }
}
