using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Not finishe, to be introduced in Component 2
    /// </summary>
    public abstract class ConditionalCommand
    {

        public String name = "";
        public String[] args;

        public ConditionalCommand()
        {

        }

        public abstract bool Execute();
    }
}
