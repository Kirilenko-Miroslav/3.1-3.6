using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private bool _Rc; // Признак того, что нажати «ОК» или «Отмена»
        public bool Rc { get { return _Rc; } }

        public int X
        {
            get
            {
                try
                {
                    return Convert.ToInt32(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("Ошибка при вводе Х-координаты");
                    return 10; // Значение по умолчанию, т.к. надо что-то возвращать
                } // try
            } // get
            set
            {
                if (value >= 0)
                { // value - значение, записываемое в поле х
                    textBox1.Text = Convert.ToString(value);
                }
                else
                {
                    MessageBox.Show("Значение не может быть отрицательным");
                    textBox1.Text = "10";
                } // else
                } // set
            } // public int X
        
            public int Y
            {
                get
                {
                    try
                {
                    return Convert.ToInt32(textBox2.Text);
                }
                catch
                {
                    MessageBox.Show("Ошибка при вводе Y-координаты");
                    return 10; // Значение по умолчанию, т.к. надо что-то возвращать
                } // try
            } // get
            set
            {
            if (value >= 0)
            { // value - значение, записываемое в поле х
                textBox2.Text = Convert.ToString(value);
            }
            else
            {
                MessageBox.Show("Значение не может быть отрицательным");
                textBox2.Text = "10";
            } // else
                } // set
            } // public int X
        
             public int R
        {
            get
            {
                try
                {
                    return Convert.ToInt32(textBox3.Text);
                }
                catch
                {
                    MessageBox.Show("Ошибка при вводе R");
                    return 10; // Значение по умолчанию, т.к. надо что-то возвращать
                } // try
            } // get
            set
            {
        if (value >= 0)
        { // value - значение, записываемое в поле х
            textBox3.Text = Convert.ToString(value);
        }
        else
        {
            MessageBox.Show("Значение не может быть отрицательным");
            textBox3.Text = "10";
        } // else
                } // set
            } // public int X
        

        public Form2()
        {
            InitializeComponent();
            _Rc = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Rc = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Rc = false;
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
