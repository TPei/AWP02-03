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
        Bitmap temp;

        // default values if user hasn't picked a color yet
        Color activeColor = Color.Black;
        Color backColor = Color.White;

        static int saveLength = 10; // how many steps will be saved
        Bitmap[] steps = new Bitmap[saveLength];
        int stepCounter = -1;
        int[] xPos = new int[saveLength];
        int[] yPos = new int[saveLength];

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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color; // set button background to selected color
                activeColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.BackColor = colorDialog2.Color;
                backColor = colorDialog2.Color;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            previousX = e.X;
            previousY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics gr = CreateGraphics();
                gr.Clear(backColor);
                //Invalidate(new Rectangle(previousX, previousY, tempX, tempY));

                tempX = e.X;
                tempY = e.Y;
                // get checkbox as string, where last char is 0/1
                String fillValue = autofill.ToString();
                // get last char and save to char
                char last = fillValue[fillValue.Length - 1];
                // 'convert' to bool
                bool fill = (last == '1');

                int startX = Math.Min(tempX, previousX);
                int startY = Math.Min(tempY, previousY);
                int endX = Math.Max(tempX, previousX);
                int endY = Math.Max(tempY, previousY);

                temp = new Bitmap(Math.Max(1, endX - startX), Math.Max(1, endY - startY));
                Graphics g = Graphics.FromImage(temp);
                Brush b = new SolidBrush(activeColor);
                int thickness = trackBar1.Value;
                Pen p = new Pen(activeColor, thickness);

                int width = endX - startX - Math.Max(thickness, 1);
                int height = endY - startY - Math.Max(thickness, 1);
                int start = thickness / 2;

                String selectedItem = comboBox1.Text;
                switch (selectedItem)
                {
                    case "Stift":
                        g.DrawLine(p, new Point(start, start), new Point(width, height));
                        previousX = tempX;
                        previousY = tempY;
                        break;
                    case "Radierer":
                        g.DrawLine(new Pen(backColor, thickness), new Point(start, start), new Point(width, height));
                        previousX = tempX;
                        previousY = tempY;
                        break;
                    case "Linie":
                        g.DrawLine(p, new Point(start, start), new Point(width, height));
                        break;
                    case "Ellipse":
                        if (fill)
                            g.FillEllipse(b, start, start, width, height);
                        else
                            g.DrawEllipse(p, start, start, width, height);
                        break;
                    case "Rechteck":
                        if (fill)
                            g.FillRectangle(b, start, start, width, height);
                        else
                            g.DrawRectangle(p, start, start, width, height);
                        break;
                    case "Dreieck":
                        Point point1 = new Point(start, height); // lower left
                        Point point2 = new Point(width, height); // lower right
                        Point point3 = new Point(width / 2, start); // top, middle
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

                gr.DrawImage(temp, startX, startY);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics gr = CreateGraphics();
            gr.Clear(backColor);
            //Invalidate(new Rectangle(previousX, previousY, tempX, tempY));

            tempX = e.X;
            tempY = e.Y;
            // get checkbox as string, where last char is 0/1
            String fillValue = autofill.ToString();
            // get last char and save to char
            char last = fillValue[fillValue.Length - 1];
            // 'convert' to bool
            bool fill = (last == '1');

            int startX = Math.Min(tempX, previousX);
            int startY = Math.Min(tempY, previousY);
            int endX = Math.Max(tempX, previousX);
            int endY = Math.Max(tempY, previousY);

            temp = new Bitmap(Math.Max(1, endX - startX), Math.Max(1, endY - startY));
            Graphics g = Graphics.FromImage(temp);
            Brush b = new SolidBrush(activeColor);
            int thickness = trackBar1.Value;
            Pen p = new Pen(activeColor, thickness);

            int width = endX - startX - Math.Max(thickness, 1);
            int height = endY - startY - Math.Max(thickness, 1);
            int start = thickness / 2;

            String selectedItem = comboBox1.Text;
            switch (selectedItem)
            {
                case "Stift":
                    g.DrawLine(p, new Point(start, start), new Point(width, height));
                    previousX = tempX;
                    previousY = tempY;
                    break;
                case "Radierer":
                    g.DrawLine(new Pen(backColor, thickness), new Point(start, start), new Point(width, height));
                    previousX = tempX;
                    previousY = tempY;
                    break;
                case "Linie":
                    g.DrawLine(p, new Point(start, start), new Point(width, height));
                    break;
                case "Ellipse":
                    if (fill)
                        g.FillEllipse(b, start, start, width, height);
                    else
                        g.DrawEllipse(p, start, start, width, height);
                    break;
                case "Rechteck":
                    if (fill)
                        g.FillRectangle(b, start, start, width, height);
                    else
                        g.DrawRectangle(p, start, start, width, height);
                    break;
                case "Dreieck":
                    Point point1 = new Point(start, height); // lower left
                    Point point2 = new Point(width, height); // lower right
                    Point point3 = new Point(width / 2, start); // top, middle
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

            gr.DrawImage(temp, startX, startY);

            // save form etc

            if (stepCounter == saveLength-1)
            {
                for (int i = 0; i < saveLength-1; i++)
                {
                    steps[i] = steps[i + 1];
                    xPos[i] = xPos[i + 1];
                    yPos[i] = yPos[i + 1];
                }
                stepCounter--;
            }

            stepCounter++;
            steps[stepCounter] = temp;
            xPos[stepCounter] = startX;
            yPos[stepCounter] = startY;
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics gr = CreateGraphics();
            gr.Clear(backColor);
            stepCounter = Math.Max(0, stepCounter - 1);
            gr.DrawImage(steps[stepCounter], xPos[stepCounter], yPos[stepCounter]);
        }
    }
}