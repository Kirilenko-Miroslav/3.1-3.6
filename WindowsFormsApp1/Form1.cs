using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MyCircle c;
        static ArrayList a;
        public static int Count
        {
            get
            {
                return a.Count;
            } // get
        } // public static int Count 
        
        public Form1()
        {
            InitializeComponent();
            c = new MyCircle(100, 100, 100);
            a = new ArrayList();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < a.Count; i++) // Цикл по всем окружностям
            {
                if (i != MyCircle.CurCircle)
                { // Окружность не текущая
                    (a[i] as MyCircle).Draw(g); // Рисуем старым методом
                }
                else
                {
                    (a[i] as MyCircle).Draw(g, true); // Рисуем новым методом
                } // else
            } // for
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyCode; // Получение кода нажатой клавиши
            if (k == Keys.Left) (a[MyCircle.CurCircle] as MyCircle).Left();  // Если клавиши «стрелка влево», то вызов
                                                                             // метода Left.
            if (k == Keys.Right) (a[MyCircle.CurCircle] as MyCircle).Right(); // … «стрелка влево» … Right
            if (k == Keys.Up) (a[MyCircle.CurCircle] as MyCircle).Up(); // … «стрелка вверх» … Up
            if (k == Keys.Down) (a[MyCircle.CurCircle] as MyCircle).Down(); // … «стрелка вниз» … Down
            if (k == Keys.F2) (a[MyCircle.CurCircle] as MyCircle).F2();
            if (k == Keys.F3) (a[MyCircle.CurCircle] as MyCircle).F3();
            if (k == Keys.Tab)
            {
                if (MyCircle.CurCircle + 1 < Count)
                {
                    MyCircle.CurCircle++; //Увеличиваем номер текущей окружности
                }
                else
                { // Вышли за пределы
                    MyCircle.CurCircle = 0; // Обнулим номер
                } // if
            } // if 
            Invalidate(); // Вызов события Paint для перерисовки окна.
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(); // Создаем вторую форму
            f2.ShowDialog(); // Открываем вторую форму
            if (f2.Rc)
            { // Если нажали «ОК»
                c = new MyCircle(f2.X, f2.Y, f2.R); // Создадим окружность
                a.Add(c); // Добавим окружность в массив
                Invalidate(); // Перерисуем окно
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Count; i++)
            {
                MyCircle c = a[i] as MyCircle;
                if ((c.x - e.X) * (c.x - e.X) + (c.y - e.Y) * (c.y - e.Y) < c.r * c.r)
                {
                    MyCircle.CurCircle = i;
                    break;
                } // if
            } // for
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    class MyCircle
    {
        public int x; // Координата x центра окружности
        public int y; // Координата y центра окружности
        public int r; // Радиус окружности
        private static int _CurCircle = 0;
        public static int CurCircle
        {
            get
            {
                return _CurCircle;
            } // get
            set
            {
                if (value >= 0 && value < Form1.Count)
                {
                    _CurCircle = value;
                }
                else
                {
                    MessageBox.Show("Недопустимое значение");
                } // else 

            } // set
        } // public static int CurCircle 
        public MyCircle(int _x, int _y, int _r) // Конструктор окружности
        { // заполняет координаты центра и радиус окружности
            x = _x;
            y = _y;
            r = _r;
        }
        public void Draw(Graphics g, bool IsCur) // Перегрузка метода рисования
                                                 // окружности
        {
            if (IsCur)
            { // Если окружность текущая
                Brush b = new SolidBrush(Color.Yellow);// Создаем кисть желтого цв.
                g.FillEllipse(b, x - r, y - r, 2 * r, 2 * r); // Закрашиваем фон
            } // if
            Pen p1 = new Pen(Color.Red, 3); //Создаем перо красного цвета,
                                            // толщина 3
            g.DrawEllipse(p1, x - r, y - r, 2 * r, 2 * r); // Рисуем окружность
        }
        public void Draw(Graphics g) // Метод рисования окружности
        {
            Pen p1 = new Pen(Color.Red, 3); //Создаем перо красного
                                            // цвета, толщина 3
            g.DrawEllipse(p1, x - r, y - r, 2 * r, 2 * r); // Рисуем окружность
        }
        public void F2()
        {
            if (Valid(x, y, r + 10)) r += 10;
        }
        public void F3()
        {
            if (Valid(x, y, r - 10)) r -= 10;
        }
        public void Left() // Метод перемещения окружности влево на 10
        { // пикселей
            if (Valid(x - 10, y, r)) x -= 10; // Если x можно уменьшить на 10,
                                              // то уменьшаем
        }
        public void Right() // ... вправо ...
        {
            if (Valid(x + 10, y, r)) x += 10; // Если x можно увеличить на 10,
                                              // то увеличим
        }


        public void Up() // ... влево ...
        {
            if (Valid(x, y - 10, r)) y -= 10; //Если y можно уменьшить на 10, то
                                              // уменьшим
        }
        public void Down() // ... вниз ...
        {
            if (Valid(x, y + 10, r)) y += 10; // Если y можно увеличить на 10,
                                              // то увеличим
        }
        public bool Valid(int _x, int _y, int _r) // Метод проверки размещения

        // окружности в окне

        {
            FormCollection fc = Application.OpenForms; // Массив всех форм
            Form f1 = fc[0]; // Первая форма
            int w = f1.Width - 15; // Ширина формы
            int h = f1.Height - 40; // Высота формы
            if (_x - _r < 0 || _y - _r < 0 || _x + _r > w || _y + _r > h) return false;
            // Окружность вышла за пределы, возвращаем ложь
            return true; // иначе возвращаем истина
        }
    }
}
