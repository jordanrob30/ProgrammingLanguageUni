using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProgrammingLanguageAssignment
{
    class MoveTo : DrawCommand
    {
        public int x, y = 0;

        public override bool Execute(Canvas canvas)
        {
            canvas.xPos = this.x;
            canvas.yPos = this.x;

            canvas.drawPositionIndicator();

            return true;
        }

        public override void ParseArguments(String[] args)
        {
            this.x = Int32.Parse(args[0]);
            this.y = Int32.Parse(args[1]);
        }
    }
}
