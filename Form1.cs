using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UE02
{
    public partial class Form1 : Form
    {
        private int previousX, previousY, tempX, tempY;
        private Point previous, temporary;
        Bitmap temporaryBitmap, savedBitmap;

        // default values if user hasn't picked a color yet
        Color activeColor = Color.Black;
        Color backColor = Color.White;

        static int saveLength = 1000; // how many steps will be saved

        List<Drawing> savedDrawings = new List<Drawing>();

        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.Black;
            this.BackColor = Color.White;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void changeElementColorButton(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color; // set button background to selected color
                activeColor = colorDialog1.Color;
            }
        }

        private void backColorChanger(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                panel1.BackColor = colorDialog2.Color;
                backColor = colorDialog2.Color;
                Graphics gr = panel1.CreateGraphics();
                drawForms();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           previous = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics gr = panel1.CreateGraphics();
                gr.Clear(backColor);
                //for (int i = 0; i <= stepCounter; i++)
                //  if (savedDrawings[i] != null)
                //gr.DrawImage(savedDrawings[i], xPos[i], yPos[i]);

                drawForms();

                //Invalidate(new Rectangle(previousX, previousY, tempX, tempY));

                temporary = e.Location;
                // get checkbox as string, where last char is 0/1
                String fillValue = autofill.ToString();
                // get last char and save to char
                char fillInt = fillValue[fillValue.Length - 1];
                // 'convert' to bool
                bool fill = (fillInt == '1');

                int startX = Math.Min(temporary.X, previous.X);
                int startY = Math.Min(temporary.Y, previous.Y);
                int endX = Math.Max(temporary.X, previous.X);
                int endY = Math.Max(temporary.Y, previous.Y);

                int thickness = trackBar1.Value;
                int bitmapWidth = Math.Max(1, endX - startX);
                int bitmapHeight = Math.Max(1, endY - startY); 

                //temp = new Bitmap(Math.Max(1, endX - startX), Math.Max(1, endY - startY));
                temporaryBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics g = Graphics.FromImage(temporaryBitmap);
                Brush b = new SolidBrush(activeColor);
                
                Pen p = new Pen(activeColor, thickness);

                int formWidth = bitmapWidth - Math.Max(1, thickness);
                int formHeight = bitmapHeight - Math.Max(1, thickness);

                int offset = thickness / 2;

                String selectedItem = comboBox1.Text;
                switch (selectedItem)
                {
                    case "Stift":
                        g.DrawLine(p, new Point((previous.X - startX), (previous.Y - startY)), new Point(temporary.X - startX, temporary.Y - startY));
                        previous.X = temporary.X;
                        previous.Y = temporary.Y;
                        break;
                    case "Radierer":
                        g.DrawLine(new Pen(backColor, thickness), new Point((previous.X - startX), (previous.Y - startY)), new Point(temporary.X - startX, temporary.Y - startY));
                        previous.X = temporary.X;
                        previous.Y = temporary.Y;
                        break;
                    case "Linie":
                        g.DrawLine(p, new Point((previous.X - startX), (previous.Y - startY)), new Point(temporary.X - startX, temporary.Y - startY));
                        break;
                    case "Ellipse":
                        if (fill)
                            g.FillEllipse(b, offset, offset, formWidth, formHeight);
                        else
                            g.DrawEllipse(p, offset, offset, formWidth, formHeight);
                        break;
                    case "Rechteck":
                        if (fill)
                            g.FillRectangle(b, offset, offset, formWidth, formHeight);
                        else
                            g.DrawRectangle(p, offset, offset, formWidth, formHeight);
                        break;
                    case "Dreieck":
                        Point point1 = new Point(offset, formHeight); // lower left
                        Point point2 = new Point(formWidth, formHeight); // lower right
                        Point point3 = new Point(formWidth / 2, offset); // top, middle
                        Point[] trianglePoints = { point1, point2, point3 };
                        if (fill)
                            g.FillPolygon(b, trianglePoints);
                        else
                            g.DrawPolygon(p, trianglePoints);
                        break;
                    default:
                        //g.FillRectangle(b, start, start, width, height);
                        break;
                }

                gr.DrawImage(temporaryBitmap, startX, startY);
                
                if (selectedItem == "Stift" || selectedItem == "Radierer")
                {
                    savedDrawings.Add(new Drawing(temporaryBitmap, startX, startY, true));
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics gr = panel1.CreateGraphics();
            gr.Clear(backColor);
            //for (int i = 0; i <= stepCounter; i++)
              //  if (savedDrawings[i] != null)
                    //gr.DrawImage(savedDrawings[i], xPos[i], yPos[i]);

            drawForms();

            //Invalidate(new Rectangle(previousX, previousY, tempX, tempY));

            temporary = e.Location;
            // get checkbox as string, where last char is 0/1
            String fillValue = autofill.ToString();
            // get last char and save to char
            char fillInt = fillValue[fillValue.Length - 1];
            // 'convert' to bool
            bool fill = (fillInt == '1');

            int startX = Math.Min(temporary.X, previous.X);
            int startY = Math.Min(temporary.Y, previous.Y);
            int endX = Math.Max(temporary.X, previous.X);
            int endY = Math.Max(temporary.Y, previous.Y);

            int thickness = trackBar1.Value;
            int bitmapWidth = Math.Max(1, endX - startX);
            int bitmapHeight = Math.Max(1, endY - startY);

            //temp = new Bitmap(Math.Max(1, endX - startX), Math.Max(1, endY - startY));
            temporaryBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            Graphics g = Graphics.FromImage(temporaryBitmap);
            Brush b = new SolidBrush(activeColor);

            Pen p = new Pen(activeColor, thickness);

            int formWidth = bitmapWidth - Math.Max(1, thickness);
            int formHeight = bitmapHeight - Math.Max(1, thickness);

            int offset = thickness / 2;
            bool line = false;
            String selectedItem = comboBox1.Text;
            switch (selectedItem)
            {
                case "Stift":
                    g.DrawLine(p, new Point((previous.X - startX), (previous.Y - startY)), new Point(temporary.X - startX, temporary.Y - startY));
                    previous.X = temporary.X;
                    previous.Y = temporary.Y;
                    line = false;
                    break;
                case "Radierer":
                    g.DrawLine(new Pen(backColor, thickness), new Point((previous.X - startX), (previous.Y - startY)), new Point(temporary.X - startX, temporary.Y - startY));
                    previous.X = temporary.X;
                    previous.Y = temporary.Y;
                    line = false;
                    break;
                case "Linie":
                    g.DrawLine(p, new Point((previous.X - startX), (previous.Y - startY)), new Point(temporary.X - startX, temporary.Y - startY));
                    break;
                case "Ellipse":
                    if (fill)
                        g.FillEllipse(b, offset, offset, formWidth, formHeight);
                    else
                        g.DrawEllipse(p, offset, offset, formWidth, formHeight);
                    break;
                case "Rechteck":
                    if (fill)
                        g.FillRectangle(b, offset, offset, formWidth, formHeight);
                    else
                        g.DrawRectangle(p, offset, offset, formWidth, formHeight);
                    break;
                case "Dreieck":
                    Point point1 = new Point(offset, formHeight); // lower left
                    Point point2 = new Point(formWidth, formHeight); // lower right
                    Point point3 = new Point(formWidth / 2, offset); // top, middle
                    Point[] trianglePoints = { point1, point2, point3 };
                    if (fill)
                        g.FillPolygon(b, trianglePoints);
                    else
                        g.DrawPolygon(p, trianglePoints);
                    break;
                default:
                    //g.FillRectangle(b, start, start, width, height);
                    break;
            }


            gr.DrawImage(temporaryBitmap, startX, startY);

            savedDrawings.Add(new Drawing(temporaryBitmap, startX, startY, line));
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // back button
        private void backButton(object sender, EventArgs e)
        {
            if (savedDrawings.Count >= 1)
            {
                savedDrawings.Remove(savedDrawings.Last());
                if (savedDrawings.Count >= 1 && savedDrawings.ElementAt(savedDrawings.Count - 1).line)
                    backButton(sender, e);
                drawForms();
            }
        }

        private void drawForms()
        {
            if (savedDrawings.Count >= 0)
            {
                Graphics gr = panel1.CreateGraphics();
                gr.Clear(backColor);

                for (int i = 0; i < savedDrawings.Count; i++)
                {
                    //gr.DrawImage(saveDrawings.ElementAt(i), xPos[i], yPos[i]);
                    Drawing temp = savedDrawings.ElementAt(i);
                    gr.DrawImage(temp.form, temp.xPos, temp.yPos);
                }
            }
        }

        // clear button
        private void clearButton(object sender, EventArgs e)
        {
            Graphics gr = panel1.CreateGraphics();
            gr.Clear(backColor);
            savedDrawings.Clear();
        }

        protected override void OnResize(EventArgs e)
        {
            drawForms();
        }

    }
}