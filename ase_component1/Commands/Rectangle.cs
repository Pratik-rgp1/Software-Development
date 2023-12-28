using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_component1.Commands
{
    /// <summary>
    /// Represents a rectangle shape.
    /// </summary>
    internal class Rectangle : Shape
    {
        private int width;
        private int height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="x">The x-coordinate of the rectangle.</param>
        /// <param name="y">The y-coordinate of the rectangle.</param>
        /// <param name="fill">A flag indicating whether the rectangle should be filled.</param>
        public Rectangle(int width, int height, Color color, int x, int y, bool fill) : base(color, x, y, fill)
        {
            // Validate the width and height parameters.
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Width and height must be greater than 0.");
            }

            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Draws the rectangle on the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context.</param>
        /// <param name="fill">A flag indicating whether the rectangle should be filled.</param>
        public override void Draw(Graphics g, bool fill)
        {
            if (fill)
            {
                // Fill the rectangle with the specified color.
                Console.WriteLine("Rectangle fill is on");
                SolidBrush b = new SolidBrush(color);
                g.FillRectangle(b, x, y, width, height);
            }
            else
            {
                // Draw the rectangle border with the specified color and pen width.
                Pen p = new Pen(color, 2);
                g.DrawRectangle(p, x, y, width, height);
            }
        }
    }
}
