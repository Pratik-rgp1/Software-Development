using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_component1.Commands
{
    /// <summary>
    /// Represents a triangle shape.
    /// </summary>
    internal class Triangle : Shape
    {
        private int sideLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="sideLength">The length of each side of the triangle.</param>
        /// <param name="color">The color of the triangle.</param>
        /// <param name="x">The x-coordinate of the triangle.</param>
        /// <param name="y">The y-coordinate of the triangle.</param>
        /// <param name="fill">A flag indicating whether the triangle should be filled.</param>
        public Triangle(int sideLength, Color color, int x, int y, bool fill) : base(color, x, y, fill)
        {
            // Validate the side length parameter.
            if (sideLength <= 0)
            {
                throw new ArgumentException("Side length must be greater than 0.");
            }

            this.sideLength = sideLength;
        }

        /// <summary>
        /// Draws the triangle on the specified graphics context.
        /// </summary>
        /// <param name="g">The graphics context.</param>
        /// <param name="fill">A flag indicating whether the triangle should be filled.</param>
        public override void Draw(Graphics g, bool fill)
        {
            // Define the vertices of the triangle.
            Point[] points = new Point[3];
            points[0] = new Point(x, y);
            points[1] = new Point(x + sideLength, y);
            points[2] = new Point(x + sideLength / 2, y - CalculateHeight());

            if (fill)
            {
                // Fill the triangle with the specified color.
                Console.WriteLine("Triangle fill is on");
                SolidBrush b = new SolidBrush(color);
                g.FillPolygon(b, points);
            }
            else
            {
                // Draw the triangle border with the specified color and pen width.
                Pen p = new Pen(color, 2);
                g.DrawPolygon(p, points);
            }
        }

        /// <summary>
        /// Calculates the height of the triangle.
        /// </summary>
        /// <returns>The height of the triangle.</returns>
        private int CalculateHeight()
        {
            // Assuming an equilateral triangle
            return Convert.ToInt32(Math.Sqrt(3) * sideLength / 2);
        }
    }
}
