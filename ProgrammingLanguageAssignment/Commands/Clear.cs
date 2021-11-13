using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    class Clear : DrawCommand
    {
        public override bool Execute(Canvas canvas)
        {
            canvas.Clear();

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
