namespace SnowModManager
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            textBox1 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pathDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enabledDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            editTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modBindingSource = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label1 = new Label();
            button2 = new Button();
            menuStrip1 = new MenuStrip();
            功能ToolStripMenuItem = new ToolStripMenuItem();
            关于ToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)modBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(79, 49);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1044, 48);
            textBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(1158, 49);
            button1.Name = "button1";
            button1.Size = new Size(267, 52);
            button1.TabIndex = 1;
            button1.Text = "选择游戏目录";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { categoryDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, pathDataGridViewTextBoxColumn, descDataGridViewTextBoxColumn, enabledDataGridViewCheckBoxColumn, editTimeDataGridViewTextBoxColumn });
            dataGridView1.DataSource = modBindingSource;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(0, 123);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(2254, 930);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragEnter += dataGridView1_DragEnter;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            dataGridViewCellStyle1.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            categoryDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            categoryDataGridViewTextBoxColumn.HeaderText = "分类";
            categoryDataGridViewTextBoxColumn.MinimumWidth = 10;
            categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            categoryDataGridViewTextBoxColumn.Width = 200;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            nameDataGridViewTextBoxColumn.HeaderText = "名称";
            nameDataGridViewTextBoxColumn.MinimumWidth = 10;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 400;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            pathDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            pathDataGridViewTextBoxColumn.HeaderText = "路径";
            pathDataGridViewTextBoxColumn.MinimumWidth = 10;
            pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            pathDataGridViewTextBoxColumn.Width = 450;
            // 
            // descDataGridViewTextBoxColumn
            // 
            descDataGridViewTextBoxColumn.DataPropertyName = "Desc";
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            descDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            descDataGridViewTextBoxColumn.HeaderText = "描述";
            descDataGridViewTextBoxColumn.MinimumWidth = 10;
            descDataGridViewTextBoxColumn.Name = "descDataGridViewTextBoxColumn";
            descDataGridViewTextBoxColumn.Width = 600;
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            enabledDataGridViewCheckBoxColumn.HeaderText = "启用";
            enabledDataGridViewCheckBoxColumn.MinimumWidth = 10;
            enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            enabledDataGridViewCheckBoxColumn.Width = 200;
            // 
            // editTimeDataGridViewTextBoxColumn
            // 
            editTimeDataGridViewTextBoxColumn.DataPropertyName = "EditTime";
            editTimeDataGridViewTextBoxColumn.HeaderText = "修改时间";
            editTimeDataGridViewTextBoxColumn.MinimumWidth = 10;
            editTimeDataGridViewTextBoxColumn.Name = "editTimeDataGridViewTextBoxColumn";
            editTimeDataGridViewTextBoxColumn.Width = 300;
            // 
            // modBindingSource
            // 
            modBindingSource.DataSource = typeof(Mod);
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 1093);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(2266, 41);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "mod目录: ";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(257, 31);
            toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(114, 31);
            toolStripStatusLabel1.Text = "mod目录";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(1748, 49);
            label1.Name = "label1";
            label1.Size = new Size(506, 41);
            label1.TabIndex = 4;
            label1.Text = "拖拽pak文件到下方, 可以直接安装";
            // 
            // button2
            // 
            button2.Location = new Point(1443, 52);
            button2.Name = "button2";
            button2.Size = new Size(263, 46);
            button2.TabIndex = 5;
            button2.Text = "打开mod目录";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 功能ToolStripMenuItem, 关于ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(2266, 42);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            功能ToolStripMenuItem.Size = new Size(82, 38);
            功能ToolStripMenuItem.Text = "功能";
            功能ToolStripMenuItem.Click += 功能ToolStripMenuItem_Click;
            // 
            // 关于ToolStripMenuItem
            // 
            关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            关于ToolStripMenuItem.Size = new Size(82, 38);
            关于ToolStripMenuItem.Text = "关于";
            关于ToolStripMenuItem.Click += 关于ToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(19F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2266, 1134);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "尘白禁区mod管理工具 v0.1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)modBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private BindingSource modBindingSource;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn editTimeDataGridViewTextBoxColumn;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Label label1;
        private Button button2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 功能ToolStripMenuItem;
        private ToolStripMenuItem 关于ToolStripMenuItem;
    }
}
