using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Interface the defines the outline of a "Command"
    /// </summary>
    public interface Command
    {
        /// <summary>
        /// Execute is called on the provided canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        bool Execute(Canvas canvas);

        /// <summary>
        /// Arguments are passed to this after validateArguments, this can be used to provided the string of arguments to the required data types
        /// </summary>
        /// <param name="args"></param>
        void ParseArguments(String[] args);

        /// <summary>
        /// validate the data provided to ensure it can later be parsed otherwise return a string with an error
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string validateArguments(String[] args);
    }
}
