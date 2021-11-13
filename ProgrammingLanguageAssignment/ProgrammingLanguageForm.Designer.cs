
namespace ProgrammingLanguageAssignment
{
    partial class ProgammingLanguageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.scriptCommands = new System.Windows.Forms.RichTextBox();
            this.CommandLine = new System.Windows.Forms.TextBox();
            this.runSingle = new System.Windows.Forms.Button();
            this.runScript = new System.Windows.Forms.Button();
            this.errorField = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.Color.Gray;
            this.canvas.Location = new System.Drawing.Point(656, 30);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(513, 392);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // scriptCommands
            // 
            this.scriptCommands.Location = new System.Drawing.Point(12, 30);
            this.scriptCommands.Name = "scriptCommands";
            this.scriptCommands.Size = new System.Drawing.Size(621, 392);
            this.scriptCommands.TabIndex = 1;
            this.scriptCommands.Text = "";
            // 
            // CommandLine
            // 
            this.CommandLine.Location = new System.Drawing.Point(12, 429);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(484, 20);
            this.CommandLine.TabIndex = 2;
            this.CommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            // 
            // runSingle
            // 
            this.runSingle.Location = new System.Drawing.Point(502, 428);
            this.runSingle.Name = "runSingle";
            this.runSingle.Size = new System.Drawing.Size(38, 23);
            this.runSingle.TabIndex = 3;
            this.runSingle.Text = "Run";
            this.runSingle.UseVisualStyleBackColor = true;
            this.runSingle.Click += new System.EventHandler(this.runSingle_Click);
            // 
            // runScript
            // 
            this.runScript.Location = new System.Drawing.Point(546, 428);
            this.runScript.Name = "runScript";
            this.runScript.Size = new System.Drawing.Size(75, 23);
            this.runScript.TabIndex = 4;
            this.runScript.Text = "Run All";
            this.runScript.UseVisualStyleBackColor = true;
            this.runScript.Click += new System.EventHandler(this.runScript_Click);
            // 
            // errorField
            // 
            this.errorField.Location = new System.Drawing.Point(656, 431);
            this.errorField.Name = "errorField";
            this.errorField.ReadOnly = true;
            this.errorField.Size = new System.Drawing.Size(513, 20);
            this.errorField.TabIndex = 5;
            // 
            // ProgammingLanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 641);
            this.Controls.Add(this.errorField);
            this.Controls.Add(this.runScript);
            this.Controls.Add(this.runSingle);
            this.Controls.Add(this.CommandLine);
            this.Controls.Add(this.scriptCommands);
            this.Controls.Add(this.canvas);
            this.Name = "ProgammingLanguageForm";
            this.Text = "Programming Language Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.RichTextBox scriptCommands;
        private System.Windows.Forms.TextBox CommandLine;
        private System.Windows.Forms.Button runSingle;
        private System.Windows.Forms.Button runScript;
        private System.Windows.Forms.TextBox errorField;
    }
}

