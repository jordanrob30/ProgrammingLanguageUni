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
            }

            this.args = arguments.ToArray();

            //updating the outputted parameters when a variable is being set
            if(this.args.Length > 0)
            {
                if (this.args[0] == "=")
                {
                    this.command = "setVar";
                    arguments.Clear();
                    arguments.Add(commandParts[0]);

                    if(commandParts.Length > 3)
                    {
                        arguments.Add(commandParts[2] + " " + commandParts[3] + " " + commandParts[4]);
                    } else
                    {
                        arguments.Add(commandParts[2]);
                    }
                    
                }
                else if (this.command == "while" || this.command == "if")
                {
                    arguments.Clear();
                    arguments.Add(commandParts[1]); //variable
                    arguments.Add(commandParts[2]); //operand
                    arguments.Add(commandParts[3]); //value
                } else if(this.command == "method")
                {
                    arguments.Clear();
                    arguments.Add(commandParts[1]);
                }

                this.args = arguments.ToArray();
            }
        }
    }
}
