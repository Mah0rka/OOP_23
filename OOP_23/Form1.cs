using System;
using System.Drawing.Text;

namespace OOP_23
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphic = pictureBox1.CreateGraphics();// ������������ ��'���� ����� Graphics
            Pen pen = new Pen(Color.Black, 2f);// ������������ ��'���� ����� Pen
            graphic.Clear(Color.White);

            // ��������� �� �
            Point firstX = new Point(0, pictureBox1.Height / 2);
            Point secondX = new Point(pictureBox1.Width, pictureBox1.Height / 2);
            graphic.DrawLine(pen, firstX, secondX);

            // ��������� �� �
            Point firstY = new Point(pictureBox1.Width / 2, 0);
            Point secondY = new Point(pictureBox1.Width / 2, pictureBox1.Height);
            graphic.DrawLine(pen, firstY, secondY);

            // ��������� ����� �� �
            Point nameOfAxisX = new Point((pictureBox1.Width / 2) + 10, 0);
            graphic.DrawString("Y", new Font("Times New Roman", 15 ,FontStyle.Bold), new SolidBrush(Color.Black), nameOfAxisX);

            //��������� ����� �� �
            Point nameOfAxisY = new Point(pictureBox1.Width - 20, pictureBox1.Height / 2);
            graphic.DrawString("X", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), nameOfAxisY);

            int xValues = -(pictureBox1.Width / 2) / 50;// ������� ��� ������� �� ��
            int yValues = (pictureBox1.Height / 2) / 50;// ������� ��� ������� �� ��

            //��������� ������� �� �� �
            for (int i = 0; i < pictureBox1.Height; i += 50)
            {
                graphic.DrawString(yValues.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(pictureBox1.Width/2, i));
                yValues--;
            }
            //��������� ������� �� �� � 
            for(int i = 0; i < pictureBox1.Width; i += 50)
            {
                if(xValues != 0)
                    graphic.DrawString(xValues.ToString(), new Font("Times New Roman", 10, FontStyle.Bold), new SolidBrush(Color.Black), new Point(i, pictureBox1.Height / 2));
                xValues++;
            }
            
            try
            {
                float a = float.Parse(textBox1.Text);//��������� ����� � textBox1

                // ��������� ������� �
                for (float x = -pictureBox1.Width / 2; x < pictureBox1.Width / 2; x++)
                {
                    float y = a * (float)(Math.Tan((double)x / 50) * 50);
                    graphic.FillRectangle(new SolidBrush(Color.Green), x + (pictureBox1.Width / 2), -y + (pictureBox1.Height / 2), 3f, 3f);
                }

                // ��������� ������� �
                for (float x = -pictureBox1.Width / 2; x < pictureBox1.Width / 2; x++)
                {
                    float y = a * (float)(Math.Pow(Math.Cos((double)x / 50),2) * 50);
                    graphic.FillRectangle(new SolidBrush(Color.Blue), x + (pictureBox1.Width / 2), -y + (pictureBox1.Height / 2), 3f, 3f);
                }
            }
            catch (FormatException)//����������
            {
                graphic.Clear(Color.White);
                MessageBox.Show("�� ����� ������ �������� �����!", "�����!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
