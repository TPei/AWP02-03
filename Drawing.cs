using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE02
{
    class Drawing
    {
        public Bitmap form;
        public int xPos, yPos;

        public Drawing(Bitmap _form, int _xPos, int _yPos)
        {
            this.form = _form;
            this.xPos = _xPos;
            this.yPos = _yPos;
        }
    }
}
