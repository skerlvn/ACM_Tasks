using NCalc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Метод для построения графиков
        private void btnPlot_Click(object sender, EventArgs e)
        {
            try
            {
                string functionInput = txtFunction.Text; // Получаем функцию от пользователя
                int n = (int)numericUpDownN.Value; // Получаем значение n

                // Создаем график
                GraphPane graph = zedGraphControl.GraphPane;
                graph.CurveList.Clear();
                graph.Title.Text = $"График функции и полинома Лагранжа для n = {n}";
                graph.XAxis.Title.Text = "x";
                graph.YAxis.Title.Text = "f(x)";
                graph.XAxis.Scale.Min = -1;
                graph.XAxis.Scale.Max = 1;
                graph.YAxis.Scale.Min = -1;
                graph.YAxis.Scale.Max = 1;

                // Получаем точки для графика функции
                double[] xValues = GetXValues(-1, 1, 100); // 100 точек для функции
                double[] yValues = EvaluateFunction(functionInput, xValues);

                // Добавляем график функции
                LineItem functionCurve = graph.AddCurve("f(x)", xValues, yValues, System.Drawing.Color.Blue, SymbolType.None);

                // Получаем узлы для интерполяции
                double[] equallySpacedX = GetEquallySpacedNodes(-1, 1, n);
                double[] chebyshevX = GetChebyshevNodes(-1, 1, n);

                // Интерполяция с равноотстоящими узлами
                double[] equallySpacedY = EvaluateFunction(functionInput, equallySpacedX);
                double[] lagrangeEquallySpacedY = LagrangeInterpolation(equallySpacedX, equallySpacedY, xValues);
                LineItem lagrangeEquallySpacedCurve = graph.AddCurve("Лагранж (равноотстоящие)", xValues, lagrangeEquallySpacedY, System.Drawing.Color.Red, SymbolType.None);

                // Интерполяция с Чебышевскими узлами
                double[] chebyshevY = EvaluateFunction(functionInput, chebyshevX);
                double[] lagrangeChebyshevY = LagrangeInterpolation(chebyshevX, chebyshevY, xValues);
                LineItem lagrangeChebyshevCurve = graph.AddCurve("Лагранж (Чебышев)", xValues, lagrangeChebyshevY, System.Drawing.Color.Green, SymbolType.None);

                // Обновляем график
                zedGraphControl.AxisChange();
                zedGraphControl.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        // Получение значений x для графика
        private double[] GetXValues(double start, double end, int points)
        {
            double[] xValues = new double[points];
            double step = (end - start) / (points - 1);
            for (int i = 0; i < points; i++)
            {
                xValues[i] = start + i * step;
            }
            return xValues;
        }

        // Метод для вычисления значения функции, заданной пользователем
        private double EvaluateFunction(double x)
        {
            string functionText = txtFunction.Text;
            var expression = new Expression(functionText);
            expression.Parameters["x"] = x;
            return Convert.ToDouble(expression.Evaluate());
        }

        // Оценка функции для массива x
        private double[] EvaluateFunction(string functionInput, double[] xValues)
        {
            double[] yValues = new double[xValues.Length];
            for (int i = 0; i < xValues.Length; i++)
            {
                yValues[i] = EvaluateFunction(xValues[i]);
            }
            return yValues;
        }

        // Получение равноотстоящих узлов
        private double[] GetEquallySpacedNodes(double start, double end, int n)
        {
            double[] nodes = new double[n];
            double step = (end - start) / (n - 1);
            for (int i = 0; i < n; i++)
            {
                nodes[i] = start + i * step;
            }
            return nodes;
        }

        // Получение Чебышевских узлов
        private double[] GetChebyshevNodes(double start, double end, int n)
        {
            double[] nodes = new double[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = 0.5 * (start + end) + 0.5 * (end - start) * Math.Cos((2 * i + 1) / (2.0 * n) * Math.PI);
            }
            return nodes;
        }

        // Метод Лагранжа для интерполяции
        private double[] LagrangeInterpolation(double[] xNodes, double[] yNodes, double[] xValues)
        {
            double[] result = new double[xValues.Length];

            for (int j = 0; j < xValues.Length; j++)
            {
                double interpolatedValue = 0;
                for (int i = 0; i < xNodes.Length; i++)
                {
                    double term = yNodes[i];
                    for (int k = 0; k < xNodes.Length; k++)
                    {
                        if (k != i)
                        {
                            term *= (xValues[j] - xNodes[k]) / (xNodes[i] - xNodes[k]);
                        }
                    }
                    interpolatedValue += term;
                }
                result[j] = interpolatedValue;
            }

            return result;
        }

        private void btnCalculateErrors_Click(object sender, EventArgs e)
        {
            string functionInput = txtFunction.Text; // Получаем функцию от пользователя
            int n = (int)numericUpDownN.Value; // Получаем значение n

            // Получаем точки для графика
            double[] xValues = GetXValues(-1, 1, 100); // 100 точек для более точного графика
            double[] yValues = EvaluateFunction(functionInput, xValues); // Значения исходной функции

            // Получаем равноотстоящие узлы и значения
            double[] equallySpacedX = GetEquallySpacedNodes(-1, 1, n);
            double[] equallySpacedY = EvaluateFunction(functionInput, equallySpacedX);
            double[] lagrangeEquallySpacedY = LagrangeInterpolation(equallySpacedX, equallySpacedY, xValues);

            // Получаем Чебышевские узлы и значения
            double[] chebyshevX = GetChebyshevNodes(-1, 1, n);
            double[] chebyshevY = EvaluateFunction(functionInput, chebyshevX);
            double[] lagrangeChebyshevY = LagrangeInterpolation(chebyshevX, chebyshevY, xValues);

            // Вычисление ошибок
            double[] errorsEquallySpaced = new double[xValues.Length];
            double[] errorsChebyshev = new double[xValues.Length];

            for (int i = 0; i < xValues.Length; i++)
            {
                errorsEquallySpaced[i] = Math.Abs(yValues[i] - lagrangeEquallySpacedY[i]);
                errorsChebyshev[i] = Math.Abs(yValues[i] - lagrangeChebyshevY[i]);
            }

            // Вывод ошибок
            double maxErrorEquallySpaced = errorsEquallySpaced.Max();
            double minErrorEquallySpaced = errorsEquallySpaced.Min();
            double avgErrorEquallySpaced = errorsEquallySpaced.Average();

            double maxErrorChebyshev = errorsChebyshev.Max();
            double minErrorChebyshev = errorsChebyshev.Min();
            double avgErrorChebyshev = errorsChebyshev.Average();

            MessageBox.Show($"Равноотстоящие узлы:\n" +
                            $"Максимальная ошибка: {maxErrorEquallySpaced}\n" +
                            $"Минимальная ошибка: {minErrorEquallySpaced}\n" +
                            $"Средняя ошибка: {avgErrorEquallySpaced}\n\n" +
                            $"Чебышевские узлы:\n" +
                            $"Максимальная ошибка: {maxErrorChebyshev}\n" +
                            $"Минимальная ошибка: {minErrorChebyshev}\n" +
                            $"Средняя ошибка: {avgErrorChebyshev}",
                            "Ошибка интерполяции");

            // (Дополнительно) Можно добавить график ошибки
            PlotErrorGraph(xValues, errorsEquallySpaced, errorsChebyshev);
        }

        private void PlotErrorGraph(double[] xValues, double[] errorsEquallySpaced, double[] errorsChebyshev)
        {
            GraphPane errorGraph = zedGraphControl.GraphPane;
            errorGraph.CurveList.Clear();
            errorGraph.Title.Text = "График ошибок интерполяции";
            errorGraph.XAxis.Title.Text = "x";
            errorGraph.YAxis.Title.Text = "Ошибка";

            // График для равноотстоящих узлов
            LineItem errorCurveEquallySpaced = errorGraph.AddCurve("Ошибки (равноотстоящие узлы)", xValues, errorsEquallySpaced, System.Drawing.Color.Red, SymbolType.None);

            // График для Чебышевских узлов
            LineItem errorCurveChebyshev = errorGraph.AddCurve("Ошибки (Чебышевские узлы)", xValues, errorsChebyshev, System.Drawing.Color.Blue, SymbolType.None);

            zedGraphControl.AxisChange();
            zedGraphControl.Invalidate();
        }
    }
}
