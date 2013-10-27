using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE02
{
    class Dot : GeometricObject
    {
        protected override void specialPaint(PaintEventArgs e, int start, int width, int height)
        {
            Brush b = new SolidBrush(getColor());
            e.Graphics.FillRectangle(b, 0, 0, getThickness(), getThickness());
        }
    }
}
