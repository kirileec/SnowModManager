namespace SnowModManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "通用", "恩雅", "里芙", "芬妮", "琴诺", "爱思特", "卡罗琳", "凯茜娅", "薇蒂雅", "茉莉安", "辰星", "瑟瑞斯", "安卡希雅", "芙提雅", "晴", "肴", "猫汐尔", "伊切尔", "妮塔" });
            comboBox1.Location = new Point(33, 62);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(520, 44);
            comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(33, 221);
            button1.Name = "button1";
            button1.Size = new Size(212, 46);
            button1.TabIndex = 1;
            button1.Text = "确认";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(341, 221);
            button2.Name = "button2";
            button2.Size = new Size(212, 46);
            button2.TabIndex = 2;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(23, 327);
            label1.Name = "label1";
            label1.Size = new Size(546, 36);
            label1.TabIndex = 3;
            label1.Text = "分类即子目录, 留空则直接放置在~mods下";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 154);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "mod备注";
            textBox1.Size = new Size(521, 43);
            textBox1.TabIndex = 4;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(17F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 386);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "选择或输入分类";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
    }
}