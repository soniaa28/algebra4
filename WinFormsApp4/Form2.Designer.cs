namespace WinFormsApp4
{
    partial class Form2
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
            button1 = new Button();
            resultText = new TextBox();
            txtMatrix = new TextBox();
            openFileDialog = new OpenFileDialog();
            button2 = new Button();
            start = new TextBox();
            end = new TextBox();
            button3 = new Button();
            resultText2 = new TextBox();
            button4 = new Button();
            result3 = new TextBox();
            button5 = new Button();
            result4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(299, 53);
            button1.Name = "button1";
            button1.Size = new Size(113, 23);
            button1.TabIndex = 0;
            button1.Text = "Знайти шлях";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // resultText
            // 
            resultText.Location = new Point(448, 12);
            resultText.Multiline = true;
            resultText.Name = "resultText";
            resultText.Size = new Size(383, 208);
            resultText.TabIndex = 1;
            // 
            // txtMatrix
            // 
            txtMatrix.Location = new Point(24, 64);
            txtMatrix.Multiline = true;
            txtMatrix.Name = "txtMatrix";
            txtMatrix.Size = new Size(249, 197);
            txtMatrix.TabIndex = 2;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(41, 267);
            button2.Name = "button2";
            button2.Size = new Size(200, 23);
            button2.TabIndex = 3;
            button2.Text = "Завантажити матрицю";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnLoadData1_Click;
            // 
            // start
            // 
            start.Location = new Point(24, 35);
            start.Name = "start";
            start.Size = new Size(100, 23);
            start.TabIndex = 4;
            // 
            // end
            // 
            end.Location = new Point(173, 35);
            end.Name = "end";
            end.Size = new Size(100, 23);
            end.TabIndex = 5;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(299, 238);
            button3.Name = "button3";
            button3.Size = new Size(113, 23);
            button3.TabIndex = 6;
            button3.Text = "Знайти діаметр";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnCalcDiameter_Click;
            // 
            // resultText2
            // 
            resultText2.Location = new Point(448, 238);
            resultText2.Name = "resultText2";
            resultText2.Size = new Size(383, 23);
            resultText2.TabIndex = 7;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(299, 267);
            button4.Name = "button4";
            button4.Size = new Size(113, 23);
            button4.TabIndex = 8;
            button4.Text = "Метод Гібса";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnGibbs_Click;
            // 
            // result3
            // 
            result3.Location = new Point(448, 267);
            result3.Name = "result3";
            result3.Size = new Size(383, 23);
            result3.TabIndex = 9;
            // 
            // button5
            // 
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(288, 304);
            button5.Name = "button5";
            button5.Size = new Size(154, 23);
            button5.TabIndex = 10;
            button5.Text = "Метод КатХілл-Маккі";
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnCutHillMcKee_Click;
            // 
            // result4
            // 
            result4.Location = new Point(448, 304);
            result4.Multiline = true;
            result4.Name = "result4";
            result4.Size = new Size(426, 212);
            result4.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(143, 17);
            label1.TabIndex = 12;
            label1.Text = "Початкова вершина :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(166, 9);
            label2.Name = "label2";
            label2.Size = new Size(107, 17);
            label2.TabIndex = 13;
            label2.Text = "Друга вершина:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(931, 581);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(result4);
            Controls.Add(button5);
            Controls.Add(result3);
            Controls.Add(button4);
            Controls.Add(resultText2);
            Controls.Add(button3);
            Controls.Add(end);
            Controls.Add(start);
            Controls.Add(button2);
            Controls.Add(txtMatrix);
            Controls.Add(resultText);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox resultText;
        private TextBox txtMatrix;
        private OpenFileDialog openFileDialog;
        private Button button2;
        private TextBox start;
        private TextBox end;
        private Button button3;
        private TextBox resultText2;
        private Button button4;
        private TextBox result3;
        private Button button5;
        private TextBox result4;
        private Label label1;
        private Label label2;
    }
}