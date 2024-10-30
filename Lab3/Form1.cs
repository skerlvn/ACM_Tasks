using NCalc;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Lab3
{

    public partial class Form1 : Form
    {
        private const double DefaultTolerance = 1e-6; // Значение точности по умолчанию

        public Form1()
        {
            InitializeComponent();
        }

        // Метод для вычисления значения функции в точке x
        private double EvaluateFunction(double x)
        {
            var expression = new Expression(txtFunction.Text);
            expression.Parameters["x"] = x;
            return Convert.ToDouble(expression.Evaluate());
        }

        // Метод для интегрирования по формуле Симпсона 3/8
        private double SimpsonMethod(double a, double b, double tolerance)
        {
            int n = 3; // Начальное количество разбиений (кратное 3 для Симпсона 3/8)
            double h, integralPrev, integralCurr;

            // Первоначальное вычисление интеграла
            integralPrev = Simpson38(a, b, n);
            do
            {
                n *= 3; // Увеличиваем количество разбиений
                integralCurr = Simpson38(a, b, n);

                // Проверка условия точности с использованием правила Рунге
                if (Math.Abs(integralCurr - integralPrev) < tolerance)
                    break;

                integralPrev = integralCurr;
            } while (true);

            lblStep.Text = $"Шаг: {(b - a) / n}";
            lblPartitions.Text = $"Количество разбиений: {n}";

            return integralCurr;
        }

        // Метод Симпсона 3/8 для вычисления интеграла с n разбиениями
        private double Simpson38(double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = EvaluateFunction(a) + EvaluateFunction(b);

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += (i % 3 == 0 ? 2 : 3) * EvaluateFunction(x);
            }

            return (3 * h / 8) * sum;
        }

        // Метод для интегрирования по формуле Гаусса 3-го порядка
        private double GaussMethod(double a, double b, double tolerance)
        {
            int n = 1; // Начальное количество интервалов
            double integralPrev, integralCurr;

            // Первоначальное вычисление интеграла
            integralPrev = Gauss3(a, b, n);
            do
            {
                n *= 2; // Увеличиваем количество разбиений
                integralCurr = Gauss3(a, b, n);

                // Проверка условия точности с использованием правила Рунге
                if (Math.Abs(integralCurr - integralPrev) < tolerance)
                    break;

                integralPrev = integralCurr;
            } while (true);

            lblStep.Text = $"Шаг: {(b - a) / n}";
            lblPartitions.Text = $"Количество разбиений: {n}";

            return integralCurr;
        }

        // Метод Гаусса 3-го порядка для вычисления интеграла с n разбиениями
        private double Gauss3(double a, double b, int n)
        {
            // Узлы и веса для формулы Гаусса 3-го порядка
            double[] nodes = { -Math.Sqrt(3.0 / 5.0), 0, Math.Sqrt(3.0 / 5.0) };
            double[] weights = { 5.0 / 9.0, 8.0 / 9.0, 5.0 / 9.0 };
            double h = (b - a) / n;
            double sum = 0.0;

            for (int i = 0; i < n; i++)
            {
                double x0 = a + i * h;
                double x1 = x0 + h;

                for (int j = 0; j < 3; j++)
                {
                    double x = ((x1 - x0) / 2) * nodes[j] + (x1 + x0) / 2;
                    sum += weights[j] * EvaluateFunction(x);
                }
            }

            return sum * (b - a) / (2 * n);
        }

        // Обработчик для кнопки Симпсона
        private void btnSimpson_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                double tolerance = Convert.ToDouble(txtTolerance.Text, NumberFormatInfo.InvariantInfo);

                double result = SimpsonMethod(a, b, tolerance);
                lblResult.Text = $"Результат: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // Обработчик для кнопки Гаусса
        private void btnGauss_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                double tolerance = Convert.ToDouble(txtTolerance.Text, NumberFormatInfo.InvariantInfo);

                double result = GaussMethod(a, b, tolerance);
                lblResult.Text = $"Результат: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message + " " + ex.Source);
            }
        }

    }
}
