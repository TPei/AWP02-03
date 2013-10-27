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
        private int previousX, previousY, currentX, currentY;
        GeometricObject temp;

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
                button1.BackColor = colorDialog1.Color; // set button background to selected color
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            previousX = e.X;
            previousY = e.Y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog2.ShowDialog();
            this.BackColor = colorDialog2.Color;
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentX = e.X;
                currentY = e.Y;

                String selectedItem = comboBox1.Text;
                if (selectedItem == "Stift")
                {
                    this.Text = "Stift";
                    temp = new Line();
                    temp.setColor(colorDialog1.Color);
                    temp.setThickness(trackBar1.Value);
                    int startX, endX, startY, endY;
                    startX = Math.Min(previousX, currentX);
                    startY = Math.Min(previousY, currentY);
                    endX = Math.Max(previousX, currentX);
                    endY = Math.Max(previousY, currentY);

                    temp.Location = new System.Drawing.Point(startX, startY);
                    temp.Size = new System.Drawing.Size(endX - startX, endY - startY);

                    this.Controls.Add(temp);
                }
                else if (selectedItem == "Radierer")
                {
                    this.Text = "Radierer";
                    temp = new Dot();
                    temp.setColor(Color.White);
                    temp.setThickness(trackBar1.Value);

                    temp.Location = new System.Drawing.Point(e.X, e.Y);
                    temp.Size = new System.Drawing.Size(temp.getThickness(), temp.getThickness());

                    this.Controls.Add(temp);
                }
            }
            

            /*
            //if (e.Button == MouseButtons.Left)
            //if(true)
            if (e.Button == MouseButtons.Left)
            {
                currentX = e.X;
                currentY = e.Y;

                this.Text = currentX + " " + currentY;
                String selectedItem = comboBox1.Text;
                this.Controls.Remove(temp);

                switch (selectedItem)
                {
                    case "Stift":
                        temp = new Dot();
                        temp.Location = new System.Drawing.Point(e.X, e.Y);
                        temp.Size = new System.Drawing.Size(1, 1);
                        break;
                    case "Radierer":
                        temp = new Radierer();
                        break;
                    case "Linie":
                        temp = new Line();
                        break;
                    case "Ellipse":
                        temp = new Circle();
                        break;
                    case "Rechteck":
                        temp = new Rectangle();
                        break;
                    case "Dreieck":
                        temp = new Triangle();
                        break;
                    default:
                        temp = new Dot();
                        GeometricObject myDot = new Dot();
                        myDot.Location = new System.Drawing.Point(currentX, currentY);
                        myDot.Size = new System.Drawing.Size(myDot.getThickness(), myDot.getThickness());
                        this.Controls.Add(myDot);
                        break;
                }
                // get checkbox as string, where last char is 0/1
                String fillValue = autofill.ToString();
                // get last char and save to char
                char last = fillValue[fillValue.Length - 1];
                // 'convert' to bool
                bool fill = (last == '1');

                temp.setAutofill(fill);
                temp.setThickness(trackBar1.Value);

                int startX, endX, startY, endY;
                startX = Math.Min(previousX, currentX);
                startY = Math.Min(previousY, currentY);
                endX = Math.Max(previousX, currentX);
                endY = Math.Max(previousY, currentY);

                temp.Location = new System.Drawing.Point(startX, startY);
                temp.Size = new System.Drawing.Size(endX - startX, endY - startY);
                this.Controls.Add(temp);
            }*/
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            currentX = e.X;
            currentY = e.Y;
            String selectedItem = comboBox1.Text;
            //this.Text = selectedItem;
            GeometricObject myObj;
            switch(selectedItem)
            {
                case "Stift":
                    myObj = new Dot();
                    break;
                case "Radierer":
                    myObj = new Dot();
                    break;
                case "Linie":
                    myObj = new Line();
                    break;
                case "Ellipse":
                    myObj = new Circle();
                    break;
                case "Rechteck":
                    myObj = new Rectangle();
                    break;         
                case "Dreieck":
                    myObj = new Triangle();
                    break;
                default:
                    myObj = new Dot();
                    break;
            }


            // get color and set it accordingly 
            if (selectedItem == "Radierer")
                myObj.setColor(Color.White);
            else
                myObj.setColor(colorDialog1.Color);

            // get checkbox as string, where last char is 0/1
            String fillValue = autofill.ToString();
            // get last char and save to char
            char last = fillValue[fillValue.Length - 1];
            // 'convert' to bool
            bool fill = (last == '1');

            myObj.setAutofill(fill);
            myObj.setThickness(trackBar1.Value);

            int startX, endX, startY, endY;
            startX = Math.Min(previousX, currentX);
            startY = Math.Min(previousY, currentY);
            endX = Math.Max(previousX, currentX);
            endY = Math.Max(previousY, currentY);

            myObj.Location = new System.Drawing.Point(startX, startY);
            myObj.Size = new System.Drawing.Size(endX - startX, endY - startY);
            //myObj.BackColor = Color.Transparent;
            this.Controls.Add(myObj);
            myObj.BringToFront();
        }
    }
}
