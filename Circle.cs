using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE02
{
    class Circle : GeometricObject
    {
        public Circle()
        {
        }

        protected override void specialPaint(PaintEventArgs e, int start, int width, int height)
        {
            bool fill = this.getAutofill();

            if (fill)
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
