using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_component1.Commands
{
    /// <summary>
    /// Represents a line shape.
    /// </summary>
    internal class Line : Shape
    {
        private Point inipoint;
        private Point despoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        /// <param name="despoint">The destination point of the line.</param>
        /// <param name="x">The x-coordinate of the line.</param>
        /// <param name="y">The y-coordinate of the line.</param>
        /// <param name="color">The color of the line.</param>
        public Line(Point despoint, int x, int y, Color color) : base(color, x, y, false)
        {
            // Initialize the initial point to (0, 0) and set the destination point.
            inipoint = new Point(0, 0);
            this.despoint = despoint;
        }

        /// <summary>
        /// Draws the line on the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context.</param>
        /// <param name="fill">A flag indicating whether the line should be filled (ignored in the case of a line).</param>
        public override void Draw(Graphics g, bool fill)
        {
            // Draw the line with the specified color and pen width.
            Pen p = new Pen(color, 2);
            g.DrawLine(p, inipoint, despoint);
        }
    }
}
