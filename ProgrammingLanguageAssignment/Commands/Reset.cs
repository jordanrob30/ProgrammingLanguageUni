using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Class resonsible for reseting the X and Y values
    /// </summary>
    public class Reset : DrawCommand
    {
        /// <summary>
        /// When ran updates the X and Y values to 0,0 on a provided canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public override bool Execute(Canvas canvas)
        {
            canvas.xPos = 0;
            canvas.yPos = 0;

            return true;
        }

        /// <summary>
        /// Blank method as no arguments provided
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(string[] args, IDictionary<string, string> varDict)
        {
            
        }

        /// <summary>
        /// Blank method as no arguments provided
        /// </summary>
        /// <param name="args"></param>
        public override string validateArguments(string[] args, IDictionary<string, string> varDict)
        {
            return "";
        }
    }
}
