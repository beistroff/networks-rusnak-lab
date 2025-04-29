namespace GraphWay
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            textBox3 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            InfoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(216, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1676, 1028);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(6, 9);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(204, 573);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(6, 609);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(204, 33);
            textBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(6, 648);
            button1.Name = "button1";
            button1.Size = new Size(204, 91);
            button1.TabIndex = 3;
            button1.Text = "Знайти найкоротший шлях";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox3.Location = new Point(6, 838);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(204, 113);
            textBox3.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(6, 585);
            label1.Name = "label1";
            label1.Size = new Size(207, 21);
            label1.TabIndex = 5;
            label1.Text = "Шукати шлях до вершини";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(6, 745);
            button2.Name = "button2";
            button2.Size = new Size(204, 87);
            button2.TabIndex = 6;
            button2.Text = "Завантажити з файлу";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // InfoButton
            // 
            InfoButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            InfoButton.Image = Properties.Resources.information_icon1;
            InfoButton.Location = new Point(6, 957);
            InfoButton.Name = "InfoButton";
            InfoButton.Size = new Size(204, 80);
            InfoButton.TabIndex = 7;
            InfoButton.Text = "Інформація";
            InfoButton.TextAlign = ContentAlignment.BottomCenter;
            InfoButton.UseVisualStyleBackColor = true;
            InfoButton.Click += InfoButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(InfoButton);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "GraphWay";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private TextBox textBox3;
        private Label label1;
        private Button button2;
        private Button InfoButton;
    }
}
