using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    abstract class DrawCommand : Command
    {
        public String name = "";
        public String[] args;

        public DrawCommand()
        {

        }

        public abstract bool Execute(Canvas canvas);
        public abstract void ParseArguments(string[] args);
    }
}
