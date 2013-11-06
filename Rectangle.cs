using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE02
{
    class Rectangle : GeometricObject
    {
        public Rectangle(int startX, int startY, int endX, int endY, bool fill) : this(new Point(startX, startY), new Point(endX, endY), fill) {}

        public Rectangle(Point start, Point end, bool fill)
        {
            /*this.start = start;
            this.end = end;
            this.setAutofill(fill);*/
        }

        protected override void specialPaint(PaintEventArgs e, int start, int width, int height)
        {
            if (getAutofill())
            {
                Brush b = new SolidBrush(getColor());
                e.Graphics.FillEllipse(b, 0, 0, width, height);
            }
            else
            {
                int thickness = getThickness();
                Pen p = new Pen(getColor(), thickness);
                e.Graphics.DrawEllipse(p, start, start, width, height);
            }
        }
    }
}
