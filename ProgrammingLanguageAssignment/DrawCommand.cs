using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    abstract class DrawCommand : Command
    {     
        public DrawCommand()
        {

        }

        public abstract bool Execute(Canvas canvas);
        public abstract void ParseArguments(string[] args);
        public abstract string validateArguments(string[] args);
    }
}
