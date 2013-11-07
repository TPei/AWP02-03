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
        /*{
            get
            {
                return form;
            }
            set
            {
                form = value;
            }
        }*/

        public int xPos;
        /*{
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
            }
        }*/

        public int yPos;
       /* {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
            }
        }*/

        public bool line;


        public Drawing(Bitmap _form, int _xPos, int _yPos, bool _line)
        {
            this.form = _form;
            this.xPos = _xPos;
            this.yPos = _yPos;
            this.line = _line;
        }
    }
}
