using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Clears a provided canvas when executed
    /// </summary>
    class Clear : DrawCommand
    {
        /// <summary>
        /// Clears the provided canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public override bool Execute(Canvas canvas)
        {
            canvas.Clear();

            return true;
        }

        /// <summary>
        /// Blank method as no arguments provided
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(string[] args)
        {
            
        }

        /// <summary>
        /// Blank method as no arguments provided
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override string validateArguments(string[] args)
        {
            return "";
        }
    }
}
