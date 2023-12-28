using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_component1.Commands
{
    /// <summary>
    /// Represents an abstract shape with properties such as color, position, and fill.
    /// </summary>
    abstract class Shape
    {
        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        protected Color color;

        /// <summary>
        /// Gets or sets the x-coordinate of the shape's position.
        /// </summary>
        protected int x;

        /// <summary>
        /// Gets or sets the y-coordinate of the shape's position.
        /// </summary>
        protected int y;

        /// <summary>
        /// Gets or sets a value indicating whether the shape should be filled.
        /// </summary>
        protected bool fill;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color">The color of the shape.</param>
        /// <param name="x">The x-coordinate of the shape's position.</param>
        /// <param name="y">The y-coordinate of the shape's position.</param>
        /// <param name="fill">A value indicating whether the shape should be filled.</param>
        public Shape(Color color, int x, int y, bool fill)
        {
            this.color = color;
            this.x = x;
            this.y = y;
            this.fill = fill;
        }

        /// <summary>
        /// Draws the shape on the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context on which to draw the shape.</param>
        /// <param name="fill">A value indicating whether the shape should be filled.</param>
        public abstract void Draw(Graphics g, bool fill);
    }
}
