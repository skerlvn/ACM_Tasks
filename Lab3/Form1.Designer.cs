namespace Lab3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblTolerance = new System.Windows.Forms.Label();
            this.btnSimpson = new System.Windows.Forms.Button();
            this.btnGauss = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblPartitions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFunction
            // 
            this.txtFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFunction.Location = new System.Drawing.Point(210, 20);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(339, 30);
            this.txtFunction.TabIndex = 0;
            // 
            // txtA
            // 
            this.txtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtA.Location = new System.Drawing.Point(210, 60);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(111, 30);
            this.txtA.TabIndex = 1;
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtB.Location = new System.Drawing.Point(210, 100);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(111, 30);
            this.txtB.TabIndex = 2;
            // 
            // txtTolerance
            // 
            this.txtTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTolerance.Location = new System.Drawing.Point(210, 140);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.Size = new System.Drawing.Size(111, 30);
            this.txtTolerance.TabIndex = 3;
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFunction.Location = new System.Drawing.Point(20, 23);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(135, 25);
            this.lblFunction.TabIndex = 4;
            this.lblFunction.Text = "Функция f(x):";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblA.Location = new System.Drawing.Point(20, 63);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(168, 25);
            this.lblA.TabIndex = 5;
            this.lblA.Text = "Левый предел a:";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblB.Location = new System.Drawing.Point(20, 103);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(177, 25);
            this.lblB.TabIndex = 6;
            this.lblB.Text = "Правый предел b:";
            // 
            // lblTolerance
            // 
            this.lblTolerance.AutoSize = true;
            this.lblTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTolerance.Location = new System.Drawing.Point(20, 143);
            this.lblTolerance.Name = "lblTolerance";
            this.lblTolerance.Size = new System.Drawing.Size(106, 25);
            this.lblTolerance.TabIndex = 7;
            this.lblTolerance.Text = "Точность:";
            // 
            // btnSimpson
            // 
            this.btnSimpson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSimpson.Location = new System.Drawing.Point(20, 180);
            this.btnSimpson.Name = "btnSimpson";
            this.btnSimpson.Size = new System.Drawing.Size(262, 83);
            this.btnSimpson.TabIndex = 8;
            this.btnSimpson.Text = "Вычислить (Симпсон 3/8)";
            this.btnSimpson.UseVisualStyleBackColor = true;
            this.btnSimpson.Click += new System.EventHandler(this.btnSimpson_Click);
            // 
            // btnGauss
            // 
            this.btnGauss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGauss.Location = new System.Drawing.Point(288, 180);
            this.btnGauss.Name = "btnGauss";
            this.btnGauss.Size = new System.Drawing.Size(262, 83);
            this.btnGauss.TabIndex = 9;
            this.btnGauss.Text = "Вычислить (Гаусс 3-го порядка)";
            this.btnGauss.UseVisualStyleBackColor = true;
            this.btnGauss.Click += new System.EventHandler(this.btnGauss_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(15, 266);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(122, 25);
            this.lblResult.TabIndex = 10;
            this.lblResult.Text = "Результат: ";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStep.Location = new System.Drawing.Point(15, 291);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(57, 25);
            this.lblStep.TabIndex = 11;
            this.lblStep.Text = "Шаг: ";
            // 
            // lblPartitions
            // 
            this.lblPartitions.AutoSize = true;
            this.lblPartitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPartitions.Location = new System.Drawing.Point(15, 321);
            this.lblPartitions.Name = "lblPartitions";
            this.lblPartitions.Size = new System.Drawing.Size(237, 25);
            this.lblPartitions.TabIndex = 12;
            this.lblPartitions.Text = "Количество разбиений: ";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(561, 382);
            this.Controls.Add(this.txtFunction);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtTolerance);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblTolerance);
            this.Controls.Add(this.btnSimpson);
            this.Controls.Add(this.btnGauss);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.lblPartitions);
            this.Name = "Form1";
            this.Text = "Интегрирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblTolerance;
        private System.Windows.Forms.Button btnSimpson;
        private System.Windows.Forms.Button btnGauss;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblPartitions;
    }
}
