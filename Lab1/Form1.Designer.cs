using System.Windows.Forms;
using ZedGraph;

namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная для конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освобождает все ресурсы, используемые компонентом.
        /// </summary>
        /// <param name="disposing">Истина, если управляемые ресурсы должны быть освобождены; иначе ложь.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм

        /// <summary>
        /// Требуемый метод для поддержки конструктора - не изменяйте
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.btnPlot = new System.Windows.Forms.Button();
            this.labelFunction = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.btnCalculateErrors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(16, 36);
            this.txtFunction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(333, 22);
            this.txtFunction.TabIndex = 0;
            this.txtFunction.Text = "Sin(x*5)/5";
            // 
            // numericUpDownN
            // 
            this.numericUpDownN.Location = new System.Drawing.Point(16, 84);
            this.numericUpDownN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Size = new System.Drawing.Size(333, 22);
            this.numericUpDownN.TabIndex = 1;
            this.numericUpDownN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(16, 128);
            this.btnPlot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(333, 28);
            this.btnPlot.TabIndex = 2;
            this.btnPlot.Text = "Построить";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // labelFunction
            // 
            this.labelFunction.AutoSize = true;
            this.labelFunction.Location = new System.Drawing.Point(16, 11);
            this.labelFunction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFunction.Name = "labelFunction";
            this.labelFunction.Size = new System.Drawing.Size(149, 16);
            this.labelFunction.TabIndex = 3;
            this.labelFunction.Text = "Введите функцию f(x):";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Location = new System.Drawing.Point(16, 64);
            this.labelN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(143, 16);
            this.labelN.TabIndex = 4;
            this.labelN.Text = "Введите значение n:";
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(358, 11);
            this.zedGraphControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(695, 529);
            this.zedGraphControl.TabIndex = 5;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            // 
            // btnCalculateErrors
            // 
            this.btnCalculateErrors.Location = new System.Drawing.Point(16, 164);
            this.btnCalculateErrors.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalculateErrors.Name = "btnCalculateErrors";
            this.btnCalculateErrors.Size = new System.Drawing.Size(333, 28);
            this.btnCalculateErrors.TabIndex = 6;
            this.btnCalculateErrors.Text = "Рассчитать ошибки";
            this.btnCalculateErrors.UseVisualStyleBackColor = true;
            this.btnCalculateErrors.Click += new System.EventHandler(this.btnCalculateErrors_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnCalculateErrors);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.labelFunction);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.numericUpDownN);
            this.Controls.Add(this.txtFunction);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Интерполяция Лагранжа";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Label labelFunction;
        private System.Windows.Forms.Label labelN;
        private ZedGraph.ZedGraphControl zedGraphControl; // Элемент управления ZedGraph
        private Button btnCalculateErrors;
    }
}
