using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Enables or disables the fill boolean on a provided canvas and validates the provided arguments
    /// </summary>
    class Fill : DrawCommand
    {
        /// <summary>
        /// Whether or not fill is enabled
        /// </summary>
        public bool fill;

        /// <summary>
        /// Enables or disables the fill boolean on a provided canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public override bool Execute(Canvas canvas)
        {
            canvas.fill = this.fill;

            return true;
        }

        /// <summary>
        /// Sets the local scope fill value depending on passed arguments
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(string[] args, IDictionary<string, string> varDict)
        {
            if(args[0] == "on")
            {
                this.fill = true;
            } else
            {
                this.fill = false;
            }
        }

        /// <summary>
        /// Ensures user has provided on/off as a parameter otherwise error is returned
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override string validateArguments(string[] args, IDictionary<string, string> varDict)
        {
            try
            {
                if(args[0] != "on" && args[0] != "off")
                {
                    return "Invalid arguments, expecting fill on/off";
                }

                return "";
            }
            catch (Exception e)
            {
                return "Invalid arguments, expecting fill on/off";
            }
        }
    }
}
