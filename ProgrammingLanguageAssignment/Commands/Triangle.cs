using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    class Triangle : DrawCommand
    {
        public int width, height = 0;

        public override bool Execute(Canvas canvas)
        {
            canvas.DrawTriangle(this.width, this.height);
            return true;
        }

        public override void ParseArguments(string[] args)
        {
            this.width = Int32.Parse(args[0]);
            this.height = Int32.Parse(args[1]);
        }

        public override string validateArguments(string[] args)
        {
            try
            {
                Int32.Parse(args[0]);
                Int32.Parse(args[1]);

                return "";
            } catch (Exception e)
            {
                return "Invalid arguments, expecting triangle <width>,<height>";
            }
        }
    }
}
