using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageAssignment
{
    public partial class ProgammingLanguageForm : Form
    {
        Bitmap OutputBm = new Bitmap(640, 480);
        Canvas FormCanvas;

        public IDictionary<string, string> VarDict = new Dictionary<string, string>();
        public IDictionary<string, string> MethodDict = new Dictionary<string, string>();

        public int linesToSkip = 0;

        public ProgammingLanguageForm()
        {
            InitializeComponent();
            this.FormCanvas = new Canvas(Graphics.FromImage(this.OutputBm));

            Refresh();
        }

        /// <summary>
        /// Ensure objects are actually drawn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //graphics instance of the form
            g.DrawImageUnscaled(this.OutputBm, 0, 0);
        }

        /// <summary>
        /// Allows commands to be ran on enter for single line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //Command Parser
                CommandParser commandParser = new CommandParser(CommandLine.Text);
                this.RunCommand(commandParser);
                CommandLine.Text = "";
            }
        }

        /// <summary>
        /// Runs the command determined by the commandParser
        /// </summary>
        /// <param name="commandParser"></param>
        /// <returns></returns>
        public bool RunCommand(CommandParser commandParser, int iteration = 0)
        {
            Command command;

            switch (commandParser.command.ToLower())
            {
                case "moveto":
                    command = new MoveTo();
                    break;
                case "drawto":
                    command = new DrawTo();
                    break;
                case "circle":
                    command = new Circle();
                    break;
                case "rectangle":
                    command = new Rectangle();
                    break;
                case "clear":
                    command = new Clear();
                    break;
                case "triangle":
                    command = new Triangle();
                    break;
                case "reset":
                    command = new Reset();
                    break;
                case "fill":
                    command = new Fill();
                    break;
                case "pen":
                    command = new PenColour();
                    break;
                case "setvar":
                    command = new Variable();

                    if(commandParser.args[1].Contains("-") || commandParser.args[1].Contains("+"))
                    {
                        //split by space to get the expression
                        String[] splitExpr = commandParser.args[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        int index = 0;
                        foreach(String s in splitExpr)
                        {
                            //assuming only integers
                            if(s.Contains("-"))
                            {
                                this.VarDict[commandParser.args[0]] = (Int32.Parse(this.VarDict[splitExpr[index - 1]]) - Int32.Parse(splitExpr[index + 1])).ToString();
                            } else if (s.Contains("+"))
                            {
                                this.VarDict[commandParser.args[0]] = (Int32.Parse(this.VarDict[splitExpr[index - 1]]) + Int32.Parse(splitExpr[index + 1])).ToString();
                            }

                            index++;
                        }
                    } else
                    {
                        this.VarDict[commandParser.args[0]] = commandParser.args[1];
                    }

                    break;
                case "while":

                    //used as this implements what is required for now
                    command = new Variable();

                    //find the endloop keyword and identify the lines
                    int originalCounter = iteration;
                    int counter = 0;
                    List<string> loopCommands = new List<string>();                   
                    foreach (string line in scriptCommands.Lines)
                    {
                        if (counter <= originalCounter)
                        {
                            counter++;
                            continue;
                        }

                        if (line == "Endloop") break;

                        //add commands to an array
                        loopCommands.Add(line);
                        counter++;
                    }

                    this.linesToSkip = loopCommands.Count;

                    //evaluate loop condition
                    String varName = commandParser.args[0];
                    String op = commandParser.args[1];
                    String value = commandParser.args[2];

                    try
                    {
                        while (true)
                        {
                            bool run = false;
                            if (op == "<")
                            {
                                if (Int32.Parse(this.VarDict[varName]) < Int32.Parse(value))
                                {
                                    run = true;
                                }
                            }

                            if(run)
                            {
                                foreach(String loopCommand in loopCommands)
                                {
                                    CommandParser commandParserLoop = new CommandParser(loopCommand);
                                    this.RunCommand(commandParserLoop);
                                }
                            } 
                            else
                            {
                                //exit if run no longer is set to true (conditon no longer met)
                                break;
                            }
                        }
                    } catch(Exception e)
                    {
                        errorField.Text = commandParser.command + " " + e.ToString();
                        return false;
                    }

                    break;
                case "endloop":
                case "endif":
                case "endmethod":
                    return true;
                case "if":

                    //used as this implements what is required for now
                    command = new Variable();

                    //find the endif keyword and identify the lines
                    int orgCounter = iteration;
                    int localCounter = 0;
                    List<string> ifCommands = new List<string>();                   
                    foreach (string line in scriptCommands.Lines)
                    {
                        if (localCounter <= orgCounter)
                        {
                            localCounter++;
                            continue;
                        }

                        if (line == "Endif") break;

                        //add commands to an array
                        if(!line.Contains("if")) {
                            ifCommands.Add(line);
                        }
                        
                        localCounter++;
                    }

                    //evaluate if condition
                    String variableName = commandParser.args[0];
                    String operand = commandParser.args[1];
                    String compValue = commandParser.args[2];

                    this.linesToSkip = ifCommands.Count;

                    try
                    {
                        bool run = false;
                        if (operand == "<")
                        {
                            if (Int32.Parse(this.VarDict[variableName]) < Int32.Parse(compValue))
                            {
                                run = true;
                            }
                        } else if (operand == ">")
                        {
                            if (Int32.Parse(this.VarDict[variableName]) > Int32.Parse(compValue))
                            {
                                run = true;
                            }
                        }
                        else if (operand == "==")
                        {
                            if (Int32.Parse(this.VarDict[variableName]) == Int32.Parse(compValue))
                            {
                                run = true;
                            }
                        }

                        if (run)
                        {
                            foreach(String ifCommand in ifCommands)
                            {
                                CommandParser commandParserIf = new CommandParser(ifCommand);
                                this.RunCommand(commandParserIf);
                            }
                        } 
                        else
                        {
                            //exit if run no longer is set to true (conditon no longer met)
                            break;
                        }
                       
                    } catch(Exception e)
                    {
                        errorField.Text = commandParser.command + " " + e.ToString();
                        return false;
                    }
                    break;
                case "method":
                    //used as this implements what is required for now
                    command = new Variable();

                    //find the endmethod keyword and identify the lines
                    int methodCounter = iteration;
                    int localMethodCounter = 0;
                    String commandList = "";                 
                    foreach (string line in scriptCommands.Lines)
                    {
                        if (localMethodCounter <= methodCounter)
                        {
                            localMethodCounter++;
                            continue;
                        }

                        if (line == "Endmethod") break;

                        //add commands to an array
                        commandList = commandList + line + ";";
                        localMethodCounter++;
                    }

                    this.MethodDict[commandParser.args[0]] = commandList;

                    this.linesToSkip = localMethodCounter;
                    break;
                default:

                    //check to see if method exists then run the commands
                    if(MethodDict.ContainsKey(commandParser.command))
                    {
                        String commands = MethodDict[commandParser.command];
                        String[] commandSplit = commands.Split(';');

                        foreach (String commandStr in commandSplit)
                        {
                            CommandParser commandParserMethod = new CommandParser(commandStr);
                            this.RunCommand(commandParserMethod);
                        }

                        return true;
                    } else if(commandParser.command != "")
                    {
                        errorField.Text = commandParser.command + " is not a valid command";
                        return false;
                    }

                    return true;
            }

         
            //Validate the arguments passed
            String validationMessage = command.validateArguments(commandParser.args, VarDict);
            if (validationMessage != "")
            {
                errorField.Text = validationMessage;
                return false;
            } else
            {
                errorField.Text = "";
            }

            command.ParseArguments(commandParser.args, VarDict);
            command.Execute(this.FormCanvas);
            Refresh();

            return true;
        }

        /// <summary>
        /// Runs the single line command but from the button "Run"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runSingle_Click(object sender, EventArgs e)
        {
            //Command Parser
            CommandParser commandParser = new CommandParser(CommandLine.Text);
            this.RunCommand(commandParser);
            CommandLine.Text = "";
        }

        /// <summary>
        /// Runs the multi line script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runScript_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach(string line in scriptCommands.Lines)
            {
                if (this.linesToSkip > 0)
                {
                    this.linesToSkip--;
                    continue;
                }

                CommandParser commandParser = new CommandParser(line);
                bool result = this.RunCommand(commandParser, counter);

                if (!result) break;
                counter++;
            }
        }

        /// <summary>
        /// Saves file to the name provided
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFile_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(fileName.Text, scriptCommands.Lines);
        }

        /// <summary>
        /// Opens a file and loads it into the multi line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                    string contents = File.ReadAllText(fileInfo.FullName);

                    scriptCommands.Text = contents;
                }
                catch
                {
                    MessageBox.Show("Something went wrong please try again");
                }
            }
        }

        private void ProgammingLanguageForm_Load(object sender, EventArgs e)
        {

        }

        private void scriptCommands_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
