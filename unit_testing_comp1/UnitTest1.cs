using ase_component1.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace ase_component1Test
{
    /// <summary>
    /// Contains unit tests for the drawing commands in the <see cref="CommandParser"/> class.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Graphics object for testing drawing commands.
        /// </summary>
        System.Drawing.Graphics graphics = new Panel().CreateGraphics();

        /// <summary>
        /// Tests the drawing of a circle using the "circle" command.
        /// </summary>
        [TestMethod]
        public void CircleTest()
        {
            string run = "run";
            string command = "circle 40";
            CommandParser parser = new CommandParser(graphics, new Panel());
            try
            {
                parser.runExecute(run, command);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Tests the drawing of a rectangle using the "rectangle" command.
        /// </summary>
        [TestMethod]
        public void RectangleTest()
        {
            string run = "run";
            string command = "rectangle 40 60";
            CommandParser parser = new CommandParser(graphics, new Panel());
            try
            {
                parser.runExecute(run, command);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            parser.ExecuteCommands(command);
        }

        /// <summary>
        /// Tests the drawing of a triangle using the "triangle" command.
        /// </summary>
        [TestMethod]
        public void TriangleTest()
        {
            string run = "run";
            string command = "triangle 30";
            CommandParser parser = new CommandParser(graphics, new Panel());
            try
            {
                parser.runExecute(run, command);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            parser.ExecuteCommands(command);
        }
    }
}
