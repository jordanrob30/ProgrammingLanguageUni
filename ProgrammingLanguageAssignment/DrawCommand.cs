using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Abstract class responsible for defining the outline of a command that requires the canvas
    /// </summary>
    public abstract class DrawCommand : Command
    {     
        public DrawCommand()
        {

        }

        /// <summary>
        /// Execute is called on the provided canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public abstract bool Execute(Canvas canvas);

        /// <summary>
        ///  Arguments are passed to this after validateArguments, this can be used to provided the string of arguments to the required data types
        /// </summary>
        /// <param name="args"></param>
        public abstract void ParseArguments(string[] args, IDictionary<string, string> varDict);

        /// <summary>
        /// validate the data provided to ensure it can later be parsed otherwise return a string with an error
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract string validateArguments(string[] args, IDictionary<string, string> varDict);
    }
}
