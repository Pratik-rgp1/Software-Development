using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace ase_component1.Commands
{
    /// <summary>
    /// Parses and executes drawing commands to create shapes on a panel.
    /// </summary>
    public class CommandParser
    {
        private Color color = Color.Black;
        private int x = 100, y = 100;
        private bool fill = false;
        private Graphics graphics;
        private List<Shape> shapes;
        private Bitmap drawingBitmap;
        private Panel panel1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParser"/> class.
        /// </summary>
        /// <param name="graphics">The graphics context used for drawing shapes.</param>
        /// <param name="panel1">The panel on which shapes are drawn.</param>
        public CommandParser(Graphics graphics, Panel panel1)
        {
            this.panel1 = panel1;
            this.shapes = new List<Shape>();
            this.drawingBitmap = new Bitmap(panel1.Width, panel1.Height);
            this.graphics = Graphics.FromImage(drawingBitmap);
        }

        /// <summary>
        /// Executes the specified run and command based on the provided input.
        /// </summary>
        /// <param name="run">The run command.</param>
        /// <param name="command">The drawing command.</param>
        public void runExecute(string run, string command)
        {
            try
            {
                if (run.ToLower() == "run")
                {
                    ExecuteCommands(command);
                }
                else
                {
                    throw new Exception("There is no run command in the command box");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Validation Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Executes a series of drawing commands to create shapes.
        /// </summary>
        /// <param name="commands">The drawing commands.</param>
        public void ExecuteCommands(string commands)
        {
            try
            {
                string[] commandList = commands.Split('\n');
                bool clearCommandEncountered = false;

                foreach (string command in commandList)
                {
                    string[] commandString = command.Split(' ');

                    if (!clearCommandEncountered)
                    {
                        switch (commandString[0].ToLower())
                        {
                            case "circle":
                                {
                                    Console.WriteLine("Circle");
                                    Circle c = new Circle(int.Parse(commandString[1]), color, x, y, fill);
                                    shapes.Add(c);
                                    break;
                                }
                            case "rectangle":
                                {
                                    Console.WriteLine("Rectangle");
                                    Rectangle r = new Rectangle(int.Parse(commandString[1]), int.Parse(commandString[2]), color, x, y, fill);
                                    shapes.Add(r);
                                    break;
                                }
                            case "triangle":
                                {
                                    Console.WriteLine("Triangle");
                                    Triangle t = new Triangle(int.Parse(commandString[1]), color, x, y, fill);
                                    shapes.Add(t);
                                    break;
                                }

                            case "moveto":
                                {
                                    Console.WriteLine("moveto command is working");
                                    x = int.Parse(commandString[1]);
                                    y = int.Parse(commandString[2]);
                                    break;
                                }
                            case "drawto":
                                {
                                    Console.WriteLine("drawto command is working");
                                    Point linepoint = new Point(int.Parse(commandString[1]), int.Parse(commandString[2]));
                                    Line l = new Line(linepoint, x, y, color);
                                    shapes.Add(l);
                                    break;
                                }
                            case "clear":
                                {
                                    Console.WriteLine("Clear working");
                                    clearCommandEncountered = true;
                                    ClearShapes();
                                    break;
                                }
                            case "reset":
                                {
                                    Console.WriteLine("Resetting pen position");
                                    x = 100;
                                    y = 100;
                                    break;
                                }
                            case "pen":
                                {
                                    if (commandString.Length != 2)
                                    {
                                        throw new ArgumentException("Invalid number of arguments for pen: " + command);
                                    }

                                    string colorString = commandString[1].Trim().ToLower();

                                    switch (colorString)
                                    {
                                        case "red":
                                            color = Color.Red;
                                            break;
                                        case "green":
                                            color = Color.Green;
                                            break;
                                        case "yellow":
                                            color = Color.Yellow;
                                            break;
                                        default:
                                            throw new ArgumentException("Invalid color for pen: " + commandString[1]);
                                    }
                                    break;
                                }
                            case "fill":
                                {
                                    if (commandString.Length != 2)
                                    {
                                        throw new ArgumentException("Invalid number of arguments for fill: " + command);
                                    }

                                    string fillValue = commandString[1].Trim().ToLower();

                                    if (fillValue == "on")
                                    {
                                        Console.WriteLine("Fill is on");
                                        fill = true;
                                    }
                                    else if (fillValue == "off")
                                    {
                                        Console.WriteLine("Fill is off");
                                        fill = false;
                                    }
                                    else
                                    {
                                        throw new ArgumentException("Invalid argument for fill: " + commandString[1]);
                                    }
                                    break;
                                }

                            default:
                                {
                                    MessageBox.Show("Unknown shape: " + commandString[0]);
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Draws the shapes on the panel based on the provided commands.
        /// </summary>
        public void DrawShapes()
        {
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("DrawShapesWorking");
                shape.Draw(graphics, fill);
            }
        }

        /// <summary>
        /// Gets the bitmap representation of the current drawing.
        /// </summary>
        /// <returns>The bitmap containing the drawn shapes.</returns>
        public Bitmap GetDrawingBitmap()
        {
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                g.Clear(panel1.BackColor);

                foreach (Shape shape in shapes)
                {
                    shape.Draw(g, fill);
                }
            }
            return drawingBitmap;
        }

        /// <summary>
        /// Clears the list of shapes.
        /// </summary>
        public void ClearShapes()
        {
            shapes.Clear();
            UpdateDrawing();
        }

        private void UpdateDrawing()
        {
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                g.Clear(panel1.BackColor);

                foreach (Shape shape in shapes)
                {
                    shape.Draw(g, fill);
                }
            }
        }

        /// <summary>
        /// Saves the program to a text file.
        /// </summary>
        /// <param name="filename">The name of the file to save.</param>
        /// <param name="program">The list of commands to save.</param>
        public static void SaveProgramToFile(string filename, List<string> program)
        {
            File.WriteAllLines(filename, program);
        }

        /// <summary>
        /// Loads a program from a text file.
        /// </summary>
        /// <param name="filename">The name of the file to load.</param>
        /// <returns>The list of commands loaded from the file.</returns>
        public static List<string> LoadProgramFromFile(string filename)
        {
            try
            {
                return File.ReadAllLines(filename).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"loading program from file failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }

        /// <summary>
        /// Validates the format of the program based on valid shape keywords.
        /// </summary>
        /// <param name="lines">The array of lines in the program.</param>
        /// <returns>True if the program format is valid; otherwise, false.</returns>
        public static bool ValidateProgramFormat(string[] lines)
        {
            string[] validShapeKeywords = { "circle", "rectangle", "triangle", "pen", "fill" };

            foreach (var line in lines)
            {
                string trimmedLine = line.Trim();

                if (!string.IsNullOrWhiteSpace(trimmedLine))
                {
                    string[] words = trimmedLine.Split(' ');

                    if (words.Length > 0 && validShapeKeywords.Contains(words[0].ToLower()))
                    {
                        // Valid shape keyword
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
