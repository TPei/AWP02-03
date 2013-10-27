using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE02
{
    class Radierer : GeometricObject
    {
        public Radierer()
        {
        }

        protected override void specialPaint(PaintEventArgs e, int start, int width, int height)
        {
            Pen p = new Pen(Color.White, 3);
            e.Graphics.DrawLine(p, 0, 0, width, height);
        }
    }
}
