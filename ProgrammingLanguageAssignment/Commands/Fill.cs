using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    class Fill : DrawCommand
    {
        public bool fill;

        public override bool Execute(Canvas canvas)
        {
            canvas.fill = this.fill;

            return true;
        }

        public override void ParseArguments(string[] args)
        {
            if(args[0] == "on")
            {
                this.fill = true;
            } else
            {
                this.fill = false;
            }
        }

        public override string validateArguments(string[] args)
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
