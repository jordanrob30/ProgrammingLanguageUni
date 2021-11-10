using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    class Rectangle : DrawCommand
    {
        public int width, height = 0;
        public override bool Execute(Canvas canvas)
        {
            canvas.DrawRectangle(this.width, this.height);

            return true;
        }

        public override void ParseArguments(string[] args)
        {
            this.width = Int32.Parse(args[0]);
            this.height = Int32.Parse(args[1]);
        }
    }
}
