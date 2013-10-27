using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE02
{
    class Triangle : GeometricObject
    {
        public Triangle()
        {
        }

        protected override void specialPaint(PaintEventArgs e, int start, int width, int height)
        {
            //e.Graphics.DrawRectangle(p, 0, 0, min - 2, min - 2);
            //e.Graphics.DrawPolygon(p, 
            int thickness = getThickness();
            Point point1 = new Point(start, height); // lower left
            Point point2 = new Point(width, height); // lower right
            Point point3 = new Point(width / 2, start); // top, middle
            Point[] trianglePoints = { point1, point2, point3 };

            bool fill = this.getAutofill();

            if (fill)
            {
                Brush b = new SolidBrush(getColor());
                e.Graphics.FillPolygon(b, trianglePoints);
            }
            else
            {
                Pen p = new Pen(getColor(), thickness);
                e.Graphics.DrawPolygon(p, trianglePoints);
            }
        }
    }
}
