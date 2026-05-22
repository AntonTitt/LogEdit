namespace LogEdit
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
            openFileDialog1 = new OpenFileDialog();
            dataGridView1 = new DataGridView();
            nick1 = new DataGridViewTextBoxColumn();
            weapon1 = new DataGridViewTextBoxColumn();
            damage1 = new DataGridViewTextBoxColumn();
            round = new DataGridViewTextBoxColumn();
            damage2 = new DataGridViewTextBoxColumn();
            weapon2 = new DataGridViewTextBoxColumn();
            nick2 = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewCheckBoxColumn();
            buttonShowDial = new Button();
            buttonForm2 = new Button();
            buttonDelete = new Button();
            textBox_Path = new TextBox();
            button_selectPath = new Button();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nick1, weapon1, damage1, round, damage2, weapon2, nick2, Delete });
            dataGridView1.Location = new Point(12, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1501, 876);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            // 
            // nick1
            // 
            nick1.HeaderText = "nick1";
            nick1.Name = "nick1";
            // 
            // weapon1
            // 
            weapon1.HeaderText = "weapon1";
            weapon1.Name = "weapon1";
            // 
            // damage1
            // 
            damage1.HeaderText = "damage1";
            damage1.Name = "damage1";
            // 
            // round
            // 
            round.HeaderText = "round";
            round.Name = "round";
            // 
            // damage2
            // 
            damage2.HeaderText = "damage2";
            damage2.Name = "damage2";
            // 
            // weapon2
            // 
            weapon2.HeaderText = "weapon2";
            weapon2.Name = "weapon2";
            // 
            // nick2
            // 
            nick2.HeaderText = "nick2";
            nick2.Name = "nick2";
            // 
            // Delete
            // 
            Delete.HeaderText = "удалить";
            Delete.Name = "Delete";
            Delete.Resizable = DataGridViewTriState.True;
            // 
            // buttonShowDial
            // 
            buttonShowDial.Location = new Point(5, 5);
            buttonShowDial.Name = "buttonShowDial";
            buttonShowDial.Size = new Size(150, 30);
            buttonShowDial.TabIndex = 1;
            buttonShowDial.Text = "Выбери файл";
            buttonShowDial.UseVisualStyleBackColor = true;
            buttonShowDial.Click += ShowDial;
            // 
            // buttonForm2
            // 
            buttonForm2.Location = new Point(160, 5);
            buttonForm2.Name = "buttonForm2";
            buttonForm2.Size = new Size(150, 30);
            buttonForm2.TabIndex = 2;
            buttonForm2.Text = "Склеить логи";
            buttonForm2.UseVisualStyleBackColor = true;
            buttonForm2.Click += ShowForm2;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(315, 5);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(150, 30);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBox_Path
            // 
            textBox_Path.Location = new Point(471, 10);
            textBox_Path.Name = "textBox_Path";
            textBox_Path.Size = new Size(535, 23);
            textBox_Path.TabIndex = 4;
            textBox_Path.Text = "C:\\Users\\vipta\\Documents\\sw.log";
            // 
            // button_selectPath
            // 
            button_selectPath.Location = new Point(1015, 5);
            button_selectPath.Name = "button_selectPath";
            button_selectPath.Size = new Size(186, 30);
            button_selectPath.TabIndex = 5;
            button_selectPath.Text = "Выбрать путь сохранения";
            button_selectPath.UseVisualStyleBackColor = true;
            button_selectPath.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1525, 930);
            Controls.Add(button_selectPath);
            Controls.Add(textBox_Path);
            Controls.Add(buttonDelete);
            Controls.Add(buttonForm2);
            Controls.Add(buttonShowDial);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private Button buttonShowDial;
        private Button buttonForm2;
        private DataGridViewTextBoxColumn nick1;
        private DataGridViewTextBoxColumn weapon1;
        private DataGridViewTextBoxColumn damage1;
        private DataGridViewTextBoxColumn round;
        private DataGridViewTextBoxColumn damage2;
        private DataGridViewTextBoxColumn weapon2;
        private DataGridViewTextBoxColumn nick2;
        private DataGridViewCheckBoxColumn Delete;
        private Button buttonDelete;
        private TextBox textBox_Path;
        private Button button_selectPath;
        private SaveFileDialog saveFileDialog1;
    }
}
