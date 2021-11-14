using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    /// <summary>
    /// Class responsible for parsing a string into a command
    /// </summary>
    public class CommandParser
    {
        public String command;
        public String[] args;

        /// <summary>
        /// Parses a string into an argument and its parameters
        /// </summary>
        /// <param name="CommandText"></param>
        public CommandParser(String CommandText)
        {
            String[] commandParts = CommandText.Split(' ');
            List<string> arguments = new List<string>();
            this.command = commandParts[0];

            if (commandParts.Length > 1)
            {
                String[] argumentsSplit = commandParts[1].Split(',');

                for (int i = 0; i < argumentsSplit.Length; i++)
                {
                    arguments.Add(argumentsSplit[i]);
                }

                this.args = arguments.ToArray();
            }
        }
    }
}
