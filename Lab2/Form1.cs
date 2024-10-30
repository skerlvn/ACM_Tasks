using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using NCalc; // Для парсинга функции
using ZedGraph; // Для построения графиков

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Метод для вычисления значения функции, заданной пользователем
        private double EvaluateFunction(double x)
        {
            string functionText = txtFunction.Text;
            var expression = new Expression(functionText);
            expression.Parameters["x"] = x;
            return Convert.ToDouble(expression.Evaluate());
        }

        // Событие при нажатии кнопки "Построить"
        private void btnPlot_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(txtN.Text);
                if (n < 2)
                {
                    MessageBox.Show("Число точек n должно быть больше 1.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PlotGraph(n);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // Метод для построения графиков функции и сплайна
        private void PlotGraph(int n)
        {
            var pane = zedGraphControl.GraphPane;
            pane.CurveList.Clear();
            pane.Title.Text = "График функции и кубического сплайна";
            pane.XAxis.Title.Text = "x";
            pane.YAxis.Title.Text = "f(x)";

            // Массивы для значений функции и сплайна
            List<PointPair> functionPoints = new List<PointPair>();
            List<PointPair> splinePoints = new List<PointPair>();

            // Вычисляем значения функции на интервале [-1, 1] с шагом 0.01
            for (double x = -1; x <= 1; x += 0.01)
            {
                functionPoints.Add(new PointPair(x, EvaluateFunction(x)));
            }

            // Определение узлов для построения кубического сплайна
            double[] xNodes = new double[n];
            double[] yNodes = new double[n];
            for (int i = 0; i < n; i++)
            {
                xNodes[i] = -1 + i * (2.0 / (n - 1));  // Равномерное разбиение отрезка
                yNodes[i] = EvaluateFunction(xNodes[i]);
            }

            // Построение и вычисление значений кубического сплайна
            var spline = new CubicSpline(xNodes, yNodes);
            for (double x = -1; x <= 1; x += 0.01)
            {
                splinePoints.Add(new PointPair(x, spline.Evaluate(x)));
            }

            // Добавление графиков функции и сплайна на графическую панель
            LineItem functionCurve = pane.AddCurve("Функция f(x)", 
                functionPoints.Select(x=>x.X).ToArray(), 
                functionPoints.Select(x => x.Y).ToArray(), 
                Color.Blue, 
                SymbolType.None);

            LineItem splineCurve = pane.AddCurve("Кубический сплайн",
                splinePoints.Select(x => x.X).ToArray(),
                splinePoints.Select(x => x.Y).ToArray(),
                Color.Red, SymbolType.None);
            splineCurve.Line.Style = DashStyle.Dash;

            // Обновление графика
            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }
    }

    // Класс для создания и оценки кубического сплайна
    public class CubicSpline
    {
        private readonly double[] x;
        private readonly double[] a;
        private readonly double[] b;
        private readonly double[] c;
        private readonly double[] d;

        public CubicSpline(double[] x, double[] y)
        {
            int n = x.Length;
            this.x = x;
            this.a = y;
            b = new double[n];
            c = new double[n];
            d = new double[n];
            //
            // Прогоночный метод для коэффициентов c, b, и d
            double[] h = new double[n - 1];
            for (int i = 0; i < n - 1; i++)
                h[i] = x[i + 1] - x[i];

            double[] alpha = new double[n];
            for (int i = 1; i < n - 1; i++)
                alpha[i] = (3 / h[i]) * (a[i + 1] - a[i]) - (3 / h[i - 1]) * (a[i] - a[i - 1]);

            double[] l = new double[n];
            double[] mu = new double[n];
            double[] z = new double[n];
            l[0] = 1;
            mu[0] = 0;
            z[0] = 0;

            for (int i = 1; i < n - 1; i++)
            {
                l[i] = 2 * (x[i + 1] - x[i - 1]) - h[i - 1] * mu[i - 1];
                mu[i] = h[i] / l[i];
                z[i] = (alpha[i] - h[i - 1] * z[i - 1]) / l[i];
            }

            l[n - 1] = 1;
            z[n - 1] = 0;
            c[n - 1] = 0;

            for (int j = n - 2; j >= 0; j--)
            {
                c[j] = z[j] - mu[j] * c[j + 1];
                b[j] = (a[j + 1] - a[j]) / h[j] - h[j] * (c[j + 1] + 2 * c[j]) / 3;
                d[j] = (c[j + 1] - c[j]) / (3 * h[j]);
            }
        }

        // Метод для оценки значения сплайна в точке
        public double Evaluate(double xi)
        {
            int i = FindSegment(xi);
            double dx = xi - x[i];
            return a[i] + b[i] * dx + c[i] * dx * dx + d[i] * dx * dx * dx;
        }

        // Нахождение подходящего сегмента для xi
        private int FindSegment(double xi)
        {
            int i = 0, j = x.Length - 1;
            while (i + 1 < j)
            {
                int k = (i + j) / 2;
                if (xi < x[k])
                    j = k;
                else
                    i = k;
            }
            return i;
        }
    }
}
