using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UE02
{
    abstract class GeometricObject : Control
    {
        private bool autofill = false;
        private Color shapeColor = Color.FromArgb(0, 0, 0);
        private int thickness = 1;

        public GeometricObject()
        {
            MouseClick += myMouseEventHandler;
        }

        private void myMouseEventHandler(object sender, MouseEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Pen p = new Pen(Color.Red, 1);
            //int min = Math.Min(this.Width, this.Height);
            //e.Graphics.DrawRectangle(p, 0, 0, min - 1, min - 1);

            //int offset = (int)(min * getSize() / 2);

            this.specialPaint(e, thickness/2, this.Width - Math.Max(thickness, 1), this.Height - Math.Max(thickness, 1));
        }

        protected abstract void specialPaint(PaintEventArgs e, int start, int width, int height);  //virtual??

        // returns geometric objects' color
        public Color getColor()
        {
            return this.shapeColor;
        }

        // set geometric objects' color
        public void setColor(Color shapeColor)
        {
            this.shapeColor = shapeColor;
        }

        public void setAutofill(bool autofill)
        {
            this.autofill = autofill;
        }

        public bool getAutofill()
        {
            return this.autofill;
        }

        public void setThickness(int thickness)
        {
            this.thickness = thickness;
        }

        public int getThickness()
        {
            return this.thickness;
        }


    }
}
