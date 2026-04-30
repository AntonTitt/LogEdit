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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nick1, weapon1, damage1, round, damage2, weapon2, nick2 });
            dataGridView1.Location = new Point(12, 42);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1074, 519);
            dataGridView1.TabIndex = 0;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 573);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nick1;
        private DataGridViewTextBoxColumn weapon1;
        private DataGridViewTextBoxColumn damage1;
        private DataGridViewTextBoxColumn round;
        private DataGridViewTextBoxColumn damage2;
        private DataGridViewTextBoxColumn weapon2;
        private DataGridViewTextBoxColumn nick2;
    }
}
