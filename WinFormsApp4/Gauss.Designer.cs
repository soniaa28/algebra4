namespace WinFormsApp4
{
    partial class Gauss
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMatrix = new TextBox();
            txtMatrixStrip = new TextBox();
            txtVector = new TextBox();
            txtVectorStrip = new TextBox();
            label1 = new Label();
            txtDecomMatrix = new TextBox();
            textBox6 = new TextBox();
            txtResultStrip = new TextBox();
            btnLoadData1 = new Button();
            button2 = new Button();
            button3 = new Button();
            btnSolve = new Button();
            btnLoadData2 = new Button();
            openFileDialog = new OpenFileDialog();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtMatrix
            // 
            txtMatrix.Location = new Point(25, 24);
            txtMatrix.Multiline = true;
            txtMatrix.Name = "txtMatrix";
            txtMatrix.Size = new Size(175, 121);
            txtMatrix.TabIndex = 0;
            // 
            // txtMatrixStrip
            // 
            txtMatrixStrip.Location = new Point(25, 200);
            txtMatrixStrip.Multiline = true;
            txtMatrixStrip.Name = "txtMatrixStrip";
            txtMatrixStrip.Size = new Size(175, 121);
            txtMatrixStrip.TabIndex = 1;
            // 
            // txtVector
            // 
            txtVector.Location = new Point(254, 24);
            txtVector.Multiline = true;
            txtVector.Name = "txtVector";
            txtVector.Size = new Size(51, 121);
            txtVector.TabIndex = 2;
            // 
            // txtVectorStrip
            // 
            txtVectorStrip.Location = new Point(254, 200);
            txtVectorStrip.Multiline = true;
            txtVectorStrip.Name = "txtVectorStrip";
            txtVectorStrip.Size = new Size(51, 121);
            txtVectorStrip.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(406, 240);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 4;
            // 
            // txtDecomMatrix
            // 
            txtDecomMatrix.Location = new Point(406, 12);
            txtDecomMatrix.Multiline = true;
            txtDecomMatrix.Name = "txtDecomMatrix";
            txtDecomMatrix.Size = new Size(146, 121);
            txtDecomMatrix.TabIndex = 5;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(600, 12);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(146, 121);
            textBox6.TabIndex = 6;
            // 
            // txtResultStrip
            // 
            txtResultStrip.Location = new Point(406, 200);
            txtResultStrip.Multiline = true;
            txtResultStrip.Name = "txtResultStrip";
            txtResultStrip.Size = new Size(146, 121);
            txtResultStrip.TabIndex = 7;
            // 
            // btnLoadData1
            // 
            btnLoadData1.Location = new Point(94, 151);
            btnLoadData1.Name = "btnLoadData1";
            btnLoadData1.Size = new Size(75, 23);
            btnLoadData1.TabIndex = 8;
            btnLoadData1.Text = "button1";
            btnLoadData1.UseVisualStyleBackColor = true;
            btnLoadData1.Click += btnLoadData1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(243, 345);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnLoadData2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(76, 336);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 10;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnLoadData1_Click;
            // 
            // btnSolve
            // 
            btnSolve.Location = new Point(444, 151);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(75, 23);
            btnSolve.TabIndex = 11;
            btnSolve.Text = "button4";
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += btnSolve_Click;
            // 
            // btnLoadData2
            // 
            btnLoadData2.Location = new Point(243, 151);
            btnLoadData2.Name = "btnLoadData2";
            btnLoadData2.Size = new Size(75, 23);
            btnLoadData2.TabIndex = 12;
            btnLoadData2.Text = "button5";
            btnLoadData2.UseVisualStyleBackColor = true;
            btnLoadData2.Click += btnLoadData2_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // button1
            // 
            button1.Location = new Point(426, 345);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 13;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSolveStrip_Click;
            // 
            // Gauss
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnLoadData2);
            Controls.Add(btnSolve);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnLoadData1);
            Controls.Add(txtResultStrip);
            Controls.Add(textBox6);
            Controls.Add(txtDecomMatrix);
            Controls.Add(label1);
            Controls.Add(txtVectorStrip);
            Controls.Add(txtVector);
            Controls.Add(txtMatrixStrip);
            Controls.Add(txtMatrix);
            Name = "Gauss";
            Text = "Gauss";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMatrix;
        private TextBox txtMatrixStrip;
        private TextBox txtVector;
        private TextBox txtVectorStrip;
        private Label label1;
        private TextBox txtDecomMatrix;
        private TextBox textBox6;
        private TextBox txtResultStrip;
        private Button btnLoadData1;
        private Button button2;
        private Button button3;
        private Button btnSolve;
        private Button btnLoadData2;
        private OpenFileDialog openFileDialog;
        private Button button1;
    }
}