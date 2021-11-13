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

        public ProgammingLanguageForm()
        {
            InitializeComponent();
            this.FormCanvas = new Canvas(Graphics.FromImage(OutputBm));

            Refresh();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //graphics instance of the form
            g.DrawImageUnscaled(this.OutputBm, 0, 0);
        }

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

        public bool RunCommand(CommandParser commandParser)
        {
            Command command;

            switch (commandParser.command)
            {
                case "moveTo":
                    command = new MoveTo();
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
                default:
                    errorField.Text = commandParser.command + " is not a valid command";
                    return false;
            }

            //Validate the arguments passed
            String validationMessage = command.validateArguments(commandParser.args);
            if (validationMessage != "")
            {
                errorField.Text = validationMessage;
                return false;
            } else
            {
                errorField.Text = "";
            }

            command.ParseArguments(commandParser.args);
            command.Execute(this.FormCanvas);
            Refresh();

            return true;
        }

        private void runSingle_Click(object sender, EventArgs e)
        {
            //Command Parser
            CommandParser commandParser = new CommandParser(CommandLine.Text);
            this.RunCommand(commandParser);
            CommandLine.Text = "";
        }

        private void runScript_Click(object sender, EventArgs e)
        {
            foreach(string line  in scriptCommands.Lines)
            {
                CommandParser commandParser = new CommandParser(line);
                bool result = this.RunCommand(commandParser);
                if (!result) break;
            }
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(fileName.Text, scriptCommands.Lines);
        }

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
    }
}
