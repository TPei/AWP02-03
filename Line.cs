using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE02
{
    class Line : GeometricObject
    {
        public Line()
        {
        }

        protected override void specialPaint(PaintEventArgs e, int start, int width, int height)
        {
            Pen p = new Pen(getColor(), getThickness());
            Point p1 = new Point(0, 0);
            Point p2 = new Point(width, height);
            e.Graphics.DrawLine(p, p1, p2);
        }
    }
}
