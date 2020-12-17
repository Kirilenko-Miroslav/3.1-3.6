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
        MyShape c;
        static ArrayList a;
        public static int Count
        {
            get
            {
                return a.Count;
            } // get
        } // public static int Count 
        static int _w, _h; // Переменные для хранения ширины и высоты формы
        public static int w // Свойство для получения ширины формы
        {
            get { return _w; }
        } // w
        public static int h // Свойство для получения высоты формы
        {
            get { return _h; }
        } // h
        static private int Inc(int a)
        {
            return a += 1;
        }
        static private int Inc2(ref int a)
        {
            return a += 1;
        }
        public Form1()
        {
            InitializeComponent();
            int x = 100;
            int y = Inc(x); 
            int z = Inc2(ref x); 

            a = new ArrayList();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < a.Count; i++) // Цикл по всем окружностям
            {
                if (i != MyShape.CurShape)
                { // Окружность не текущая
                    (a[i] as MyShape).Draw(g, false); // Рисуем старым методом
                }
                else
                {
                    (a[i] as MyShape).Draw(g, true); // Рисуем новым методом
                } // else
            } // for
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            Keys k = e.KeyCode; // Получение кода нажатой клавиши
            if (k == Keys.Left) (a[MyShape.CurShape] as MyShape).Left();
            // метода Left.
            if (k == Keys.Right) (a[MyShape.CurShape] as MyShape).Right();
            if (k == Keys.Up) (a[MyShape.CurShape] as MyShape).Up();
            if (k == Keys.Down) (a[MyShape.CurShape] as MyShape).Down();
            if (k == Keys.Tab)
            {
                if (MyShape.CurShape + 1 < Count)
                {
                    MyShape.CurShape++; //Увеличиваем номер текущей окружности
                }
                else
                { // Вышли за пределы
                    MyShape.CurShape = 0; // Обнулим номер
                } // if
            } // if 
            Invalidate();
        }



        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Count; i++)
            {
                MyShape c = a[i] as MyShape;
                if ((c.X - e.X) * (c.X - e.X) + (c.Y - e.Y) * (c.Y - e.Y) < c.R * c.R)
                {
                    MyShape.CurShape = i;
                    label2.Text = "Тип фигуры: " + c.Type.ShapeName; 
                    break;
                } // if
            } // for
            Invalidate();
        }

        private void окружностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(); // Создаем вторую форму
            f2.ShowDialog(); // Открываем вторую форму
            if (f2.Rc)
            { // Если нажали «ОК»
                c = new MyCircle(f2.X, f2.Y + 40, f2.R); // Создадим окружность
                a.Add(c); // Добавим окружность в массив
                Invalidate(); // Перерисуем окно
            } // if
        }

        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(); // Создаем вторую форму
            f2.ShowDialog(); // Открываем вторую форму
            if (f2.Rc)
            { // Если нажали «ОК»
                c = new MyRect(f2.X, f2.Y, f2.R); // Создадим квадрат
                a.Add(c); // Добавим окружность в массив
                Invalidate(); // Перерисуем окно
            } // if
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            _w = Width;
            _h = Height;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            _w = Width;
            _h = Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Output(textBox1, 3);
        }
        private void Output(TextBox tb, int s)
        {
            tb.Text = Convert.ToString(s);
        }
        private void Output(TextBox tb, double s)
        {
            tb.Text = Convert.ToString(s);
        }

        private void Output(TextBox tb, String s)
        {
            tb.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Output(textBox1, 3.5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Output(textBox1, "3a");
        }
        bool tc = false;
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tc = !tc;
            button1.Enabled = tc;
            button2.Enabled = tc;
            button3.Enabled = tc;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            C c = new C(); // Создаем объект класса С
            c.a = 10; // Задаем свойство a равным 10
            int n = c.ga();
            label4.Text = n.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            C2 c = new C2(); // Создаем объект класса С
            c.a.a = 10; // Задаем свойство a класса а равным 10
            int n = c.a.ga();
            label5.Text = n.ToString();
        }
        bool tc2 = false;
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tc2 = !tc2;
            button4.Enabled = tc2;
            button5.Enabled = tc2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void треугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(); // Создаем вторую форму
            f2.ShowDialog(); // Открываем вторую форму
            if (f2.Rc)
            { // Если нажали «ОК»
                c = new MyTriangle(f2.X, f2.Y, f2.R); // Создадим квадрат
                a.Add(c); // Добавим окружность в массив
                Invalidate(); // Перерисуем окно
            } // if
        }
    }


    abstract class MyShape
    {
        protected int x; // x-координата базовой точки
        protected int y; // y-координата базовой точки
        protected int r; // размер фигуры
        protected static int _CurShape = 0; // номер текущей фигуры
        protected TypeShape _Type; // тип фигуры: 1-окружность, 2-квадрат
        public int X // Свойство для работы с x-координатой
        {
            get // Метод для чтения из поля x
            {
                return x;
            } // get

            set // Метод для записи в поле x
            {
                if (value >= 0)
                { // value - значение, записываемое в поле х
                    x = value;
                }
                else
                {
                    MessageBox.Show("Значение должно быть > 0");
                } // else
            } // set
        } // public int X



        public int Y // Свойство для работы с x-координатой
        {
            get // Метод для чтения из поля x
            {
                return y;
            } // get

            set // Метод для записи в поле x
            {
                if (value >= 0)
                { // value - значение, записываемое в поле х
                    y = value;
                }
                else
                {
                    MessageBox.Show("Значение должно быть > 0");
                } // else
            } // set
        } // public int Y
        public int R // Свойство для работы с x-координатой
        {
            get // Метод для чтения из поля x
            {
                return r;
            } // get

            set // Метод для записи в поле x
            {
                if (value >= 0)
                { // value - значение, записываемое в поле х
                    r = value;
                }
                else
                {
                    MessageBox.Show("Значение должно быть > 0");
                } // else
            } // set
        } // public int R
        public static int CurShape
        { // Свойство для доступа к номеру тек. фиг.
            get
            {
                return _CurShape;
            } // get
            set
            {
                if (value >= 0 && value < Form1.Count)
                {
                    _CurShape = value;
                }
                else
                {
                    MessageBox.Show("Недопустимое значение");
                } // else
            } // set
        } // public static int CurShape



        public TypeShape Type
        { // Свойство для доступа к типу фигуры
            get
            {
                return _Type;
            } // get
        } // public int Type
        public MyShape(int _x, int _y, int _r) // Конструктор фигуры
        {
            x = _x;
            y = _y;
            r = _r;
        } // Конструктор
        public void Left() // Метод перемещения фигуры влево на 10 пикселей
        { //
            if (Valid(x - 10, y, r)) x -= 10; // Если x можно уменьшить на 10,
                                              // то уменьшаем
        } // Left
        public void Right() // ... вправо ...
        {
            if (Valid(x + 10, y, r)) x += 10; // Если x можно увеличить на 10,
                                              // то увеличим
        } // Right
        public void Up() // ... влево ...
        {
            if (Valid(x, y - 10, r)) y -= 10; //Если y можно уменьшить на 10, то
                                              // уменьшим
        } // Up
        public void Down() // ... вниз ...
        {
            if (Valid(x, y + 10, r)) y += 10; // Если y можно увеличить на 10,
                                              // то увеличим
        } // Down
        abstract public bool Valid(int _x, int _y, int _r);
        abstract public void Draw(Graphics g, bool IsCur);
    } // class MyShape
    class MyCircle : MyShape
    {
        public MyCircle(int _x, int _y, int _r) : base(_x, _y, _r) // Конструктор
        { // окружности
            _Type = new TypeShape("Circle", 1);
        } // Конструктор
        override public void Draw(Graphics g, bool IsCur) // Метод рисования окружн.
        {
            if (IsCur)
            { // Если фигура текущая
                Brush b = new SolidBrush(Color.Yellow); // Создаем кисть
                                                        // желтого цвета
                g.FillEllipse(b, x - r , y - r / 2, 2 * r, 2 * r); // Закрашиваем фон
            } // if
            Pen p1 = new Pen(Color.Red, 3); //Создаем перо красного цвета,
                                            // толщина 3
            g.DrawEllipse(p1, x - r , y - r / 2, 2 * r, 2 * r); // Рисуем окружность
        } // Draw
        public override bool Valid(int _x, int _y, int _r)
        {
            if (_x - _r < 0 || _y - _r < 25 || _x + _r > Form1.w - 10 || _y + _r > Form1.h - 40)
                return false;
            return true;
        } // Valid
    } // class MyCircle
    class MyRect : MyShape
    {
        public MyRect(int _x, int _y, int _r) : base(_x, _y, _r) // Конструктор
        { // квадрата
            _Type = new TypeShape("Rect", 2);
        } // Конструктор
        override public void Draw(Graphics g, bool IsCur) // Метод рисования квадрата
        {
            if (IsCur)
            { // Если фигура текущая
                Brush b = new SolidBrush(Color.Yellow); // Создаем кисть
                                                        // желтого цвета
                g.FillRectangle(b, x, y, r, r); // Закрашиваем фон
                
            } // if


        
Pen p2 = new Pen(Color.Blue, 3); //Создаем перо синего
                                 // цвета, толщина 3
            g.DrawRectangle(p2, x, y, r, r); // Рисуем квадрат
        } // Конструктор
        override public bool Valid(int _x, int _y, int _r)
        {
            if (_x < 0 || _y < 25 || _x + _r > Form1.w - 10 || _y + _r > Form1.h - 40)
                return false;
            return true;
        } // Valid
    } // class MyRect
    class MyTriangle : MyShape
    {
        public MyTriangle(int _x, int _y, int _r) : base(_x, _y, _r) // Конструктор
        { // Треугольника
            _Type = new TypeShape("Triangle", 3);
        } // Конструктор
        override public void Draw(Graphics g, bool IsCur) // Метод рисования квадрата
        {
            double x1, x2, x3, y1, y2, y3;
            x1 = x;
            y1 = y;
            x2 = x + r * Math.Cos(0);
            y2 = y + r * Math.Sin(0);
            x3 = x + r * Math.Cos(Math.PI / 3);
            y3 = y + r * Math.Sin(Math.PI / 3);
            Point[] points = { new Point((int)x1, (int)y1), new Point((int)x2, (int)y2), new Point((int)x3, (int)y3) };
            if (IsCur)
            { // Если фигура текущая
                Brush b = new SolidBrush(Color.Yellow); // Создаем кисть
                                                        // желтого цвета
                g.FillPolygon(b, points);

            } // if

            //Point[] points = { new Point(10, 10), new Point(100, 10), new Point(50, 100) };
            //g.DrawPolygon(new Pen(Color.Blue), points);
            //Point[] points2 = { new Point(100, 100), new Point(200, 100), new Point(150, 10) };
            //g.FillPolygon(new SolidBrush(Color.Red), points2);

            g.DrawPolygon(new Pen(Color.Red, 3), points);
        } // Конструктор
        override public bool Valid(int _x, int _y, int _r)
        {
            if (_x < 0 || _y < 25 || _x + _r > Form1.w - 10 || _y + _r > Form1.h - 40)
                return false;
            return true;
        } // Valid
    } // class MyRect
    sealed class TypeShape
    {
        private String _ShapeName; // Название фигуры
        private int _Number; // Кол-во углов
        public String ShapeName
        { get { return _ShapeName; } set { _ShapeName = value; } }
        public int Number
        { get { return _Number; } set { _Number = value; } }

        public TypeShape(String __ShapeName, int __Number)
        {
            _ShapeName = __ShapeName;
            _Number = __Number;
        }
    }

    interface IA
    {
        int a { get; set; } // Сигнатура свойства a
        int fa(); // Сигнатура метода fa
    }

    interface IB
    {
        int b { get; set; } // Сигнатура свойства b
        int fb(); // Сигнатура метода fb
    }
    static class InterfaceExtensions
    {
        public static int ga(this IA xa)
        {
            return xa.a + 2;
        }
        public static int gb(this IB xb)
        {
            return xb.b - 2;
        }
    }
    class C : IA, IB
    {
        public int a { get; set; } // Реализация свойства a
        public int b { get; set; } // Реализация свойства b
        public int fa() { return a + 1; } // Реализация метода fa
        public int fb() { return b - 1; } // Реализация метода fb
    }

    class A
    {
        public int a { get; set; }
        public int fa() { return a + 1; }
        public int ga() { return a + 2; }
    }


    class B
    {
        public int b { get; set; }
        public int fb() { return b - 1; }
        public int gb() { return b - 2; }
    }
    class C2
    {
        private A _a;
        private B _b;
        public C2() // Конструктор, в нем создаем объекты классов А и В
        {
            _a = new A();
            _b = new B();
        }
        public A a { get { return _a; } set { _a = value; } } // Свойства для доступа
        public B b { get { return _b; } set { _b = value; } } // к объектам классов А и В
        public int fa() { return _a.fa(); } // При необходимости можно
        public int ga() { return _a.ga(); } // переопределить эти методы
        public int fb() { return _b.fb(); }
        public int gb() { return _b.gb(); }
    }

}
