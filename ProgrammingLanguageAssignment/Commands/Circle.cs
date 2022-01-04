using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Circle Class responsible for validating arguments and triggering DrawCircle method
    /// </summary>
    public class Circle : DrawCommand
    {
        /// <summary>
        /// Radius of the created circle
        /// </summary>
        public int radius;

        /// <summary>
        /// Triggers DrawCircle command on a provided canvas
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public override bool Execute(Canvas canvas)
        {
            canvas.DrawCircle(this.radius);

            return true;
        }

        /// <summary>
        /// Parses the provided arguments
        /// </summary>
        /// <param name="args"></param>
        public override void ParseArguments(string[] args, IDictionary<string, string> varDict)
        {
            try
            {
                this.radius = Int32.Parse(args[0]);
            } catch(Exception ex)
            {
                this.radius = Int32.Parse(varDict[args[0]]);
            }
        }
        
        /// <summary>
        /// Validates the provided arguments to ensure they are Int32 parsable
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override string validateArguments(string[] args, IDictionary<string, string> varDict)
        {
            try
            {
                Int32.Parse(args[0]);
            }
            catch (Exception e)
            {
                try
                {
                    this.radius = Int32.Parse(varDict[args[0]]);
                    return "";
                }
                catch (Exception ex)
                {
                    return "Invalid arguments, expecting circle <radius>";
                }              
                
                return "Invalid arguments, expecting circle <radius>";
            }

            return "";
        }
    }
}
