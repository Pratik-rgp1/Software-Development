using ase_component1.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ase_component1
{
    /// <summary>
    /// Main form of the application responsible for the user interface and interaction.
    /// </summary>
    public partial class Form1 : Form
    {
        private CommandParser commandParser;
        private Graphics graphics;
        private bool fill;

        /// <summary>
        /// Constructor for initializing the Form1 instance.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Initialize the CommandParser with the graphics object of the drawing panel.
            commandParser = new CommandParser(panel1.CreateGraphics(), panel1);
        }

        /// <summary>
        /// Event handler for the "Run" button click.
        /// Executes the entered drawing command and updates the drawing panel accordingly.
        /// </summary>
        private void run_Click(object sender, EventArgs e)
        {
            // Retrieve the individual drawing command from the text box.
            string individualCommand = textBox1.Text;

            // Execute the "clear" command to reset the drawing panel.
            string clearCommand = "clear";
            commandParser.ExecuteCommands(clearCommand);

            // Validate the presence of the "run" command.
            if (textBox2.Text.Trim().ToLower() != "run")
            {
                MessageBox.Show("Unknown Command: required command 'run'!");
                return;
            }

            // Execute the individual drawing command.
            commandParser.ExecuteCommands(individualCommand);

            // Handle special cases for the "clear" command.
            if (individualCommand.Trim().ToLower() == "clear")
            {
                commandParser.ClearShapes();
            }
            else
            {
                // Refresh and invalidate the drawing panel to update the displayed shapes.
                panel1.Refresh();
                panel1.Invalidate();
            }
        }

        /// <summary>
        /// Event handler for the drawing panel's Paint event.
        /// Draws the image representation of the current drawing on the panel.
        /// </summary>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(commandParser.GetDrawingBitmap(), 0, 0);
        }

        /// <summary>
        /// Event handler for the "Syntax Check" button click.
        /// Checks the syntax of the entered drawing commands and provides feedback.
        /// </summary>
        private void syntax_Click(object sender, EventArgs e)
        {
            // Split the entered program into lines.
            string[] programLines = textBox1.Text.Split('\n');

            // Validate the format of the drawing program.
            if (CommandParser.ValidateProgramFormat(programLines))
            {
                MessageBox.Show("Hit the run button to execute.");
            }
            else
            {
                MessageBox.Show("Invalid command! Please check your command.");
            }
        }

        // Other event handlers and methods...

        /// <summary>
        /// Event handler for the "Exit" button click.
        /// Closes the application after confirming with the user.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
