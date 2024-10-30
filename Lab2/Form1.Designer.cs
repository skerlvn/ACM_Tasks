namespace Lab2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnPlot;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.Label lblN;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.CalculateErrorsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(15, 34);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(228, 22);
            this.txtFunction.TabIndex = 0;
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(12, 86);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(231, 22);
            this.txtN.TabIndex = 1;
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(12, 121);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(231, 32);
            this.btnPlot.TabIndex = 2;
            this.btnPlot.Text = "Построить";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(15, 14);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(149, 16);
            this.lblFunction.TabIndex = 3;
            this.lblFunction.Text = "Введите функцию f(x):";
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(12, 67);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(231, 16);
            this.lblN.TabIndex = 4;
            this.lblN.Text = "Количество точек для сплайна (n):";
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(253, 5);
            this.zedGraphControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(584, 432);
            this.zedGraphControl.TabIndex = 5;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            // 
            // CalculateErrorsButton
            // 
            this.CalculateErrorsButton.Location = new System.Drawing.Point(12, 159);
            this.CalculateErrorsButton.Name = "CalculateErrorsButton";
            this.CalculateErrorsButton.Size = new System.Drawing.Size(231, 32);
            this.CalculateErrorsButton.TabIndex = 6;
            this.CalculateErrorsButton.Text = "Рассчитать ошибки";
            this.CalculateErrorsButton.UseVisualStyleBackColor = true;
            this.CalculateErrorsButton.Click += new System.EventHandler(this.CalculateErrorsButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.CalculateErrorsButton);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.txtFunction);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.btnPlot);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.lblN);
            this.Name = "Form1";
            this.Text = "График функции и кубического сплайна";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.Button CalculateErrorsButton;
    }
}
