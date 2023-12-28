using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ase_component1.Commands
{
    internal class Circle : Shape
    {
        private int radius;
        private Color penColor;

        public Circle(int radius, Color color, int x, int y, bool fill) : base(color, x, y, fill)
        {
           
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be greater than 0.");
            }
            this.radius = radius;
        }
        public override void Draw(Graphics g, bool fill)
        {
            using (Pen pen = new Pen(color))
            {
                if (fill)
                {
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
                    }
                }
                else
                {
                    g.DrawEllipse(pen, x - radius, y - radius, 2 * radius, 2 * radius);
                }
            }
        }
    }
}
