using System;

namespace ProgrammingLanguageAssignment
{
    public class Variable : Command
    {
        public string Name;

        /// <summary>
        /// Method can just return true, this class is here for validation in future and may not be required
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public bool Execute(Canvas canvas)
        {
            return true;
        }

        /// <summary>
        /// No parsing currently required as all variables are seen as strings
        /// </summary>
        /// <param name="args"></param>
        public void ParseArguments(string[] args, System.Collections.Generic.IDictionary<string, string> varDict)
        {
            
        }

        /// <summary>
        /// No validation at the moment as all variables are seen as strings
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string validateArguments(string[] args, System.Collections.Generic.IDictionary<string, string> varDict)
        {
            return "";
        }
    }
}