﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    class Circle : DrawCommand
    {
        public int radius;

        public override bool Execute(Canvas canvas)
        {
            canvas.DrawCircle(this.radius);

            return true;
        }

        public override void ParseArguments(string[] args)
        {
            this.radius = Int32.Parse(args[0]);
        }

        public override string validateArguments(string[] args)
        {
            try
            {
                Int32.Parse(args[0]);

                return "";
            }
            catch (Exception e)
            {
                return "Invalid arguments, expecting circle <radius>";
            }
        }
    }
}
