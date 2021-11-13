using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    interface Command
    {
        bool Execute(Canvas canvas);

        void ParseArguments(String[] args);

        string validateArguments(String[] args);
    }
}
