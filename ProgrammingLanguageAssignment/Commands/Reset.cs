using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    class Reset : DrawCommand
    {
        public override bool Execute(Canvas canvas)
        {
            canvas.xPos = 0;
            canvas.yPos = 0;

            return true;
        }

        public override void ParseArguments(string[] args)
        {
            
        }

        public override string validateArguments(string[] args)
        {
            return "";
        }
    }
}
