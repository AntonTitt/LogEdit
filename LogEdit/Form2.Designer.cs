namespace LogEdit
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
            choose = new Button();
            openFileDialog1 = new OpenFileDialog();
            add = new Button();
            textBox1 = new TextBox();
            checkBox_counterfx = new CheckBox();
            DoThgeThingTM = new Button();
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // choose
            // 
            choose.Location = new Point(10, 9);
            choose.Margin = new Padding(3, 2, 3, 2);
            choose.Name = "choose";
            choose.Size = new Size(138, 22);
            choose.TabIndex = 0;
            choose.Text = "Выбрать файл";
            choose.UseVisualStyleBackColor = true;
            choose.Click += buttonchoose_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // add
            // 
            add.Location = new Point(10, 35);
            add.Margin = new Padding(3, 2, 3, 2);
            add.Name = "add";
            add.Size = new Size(138, 22);
            add.TabIndex = 1;
            add.Text = "Добавить файл";
            add.UseVisualStyleBackColor = true;
            add.Click += buttonAdd_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(154, 9);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(536, 23);
            textBox1.TabIndex = 2;
            // 
            // checkBox_counterfx
            // 
            checkBox_counterfx.AutoSize = true;
            checkBox_counterfx.Checked = true;
            checkBox_counterfx.CheckState = CheckState.Checked;
            checkBox_counterfx.Location = new Point(10, 62);
            checkBox_counterfx.Margin = new Padding(3, 2, 3, 2);
            checkBox_counterfx.Name = "checkBox_counterfx";
            checkBox_counterfx.Size = new Size(76, 19);
            checkBox_counterfx.TabIndex = 3;
            checkBox_counterfx.Text = "counterfx";
            checkBox_counterfx.UseVisualStyleBackColor = true;
            // 
            // DoThgeThingTM
            // 
            DoThgeThingTM.Location = new Point(10, 84);
            DoThgeThingTM.Margin = new Padding(3, 2, 3, 2);
            DoThgeThingTM.Name = "DoThgeThingTM";
            DoThgeThingTM.Size = new Size(138, 23);
            DoThgeThingTM.TabIndex = 5;
            DoThgeThingTM.Text = "делать";
            DoThgeThingTM.UseVisualStyleBackColor = true;
            DoThgeThingTM.Click += buttonDoTheThingTM_Click;
            // 
            // listBox1
            // 
            listBox1.AllowDrop = true;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(154, 35);
            listBox1.Margin = new Padding(3, 2, 3, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(536, 289);
            listBox1.TabIndex = 6;
            listBox1.DragDrop += listBox1_DragDrop;
            listBox1.DragOver += listBox1_DragOver;
            listBox1.MouseDown += listBox1_MouseDown;
            // 
            // button1
            // 
            button1.Location = new Point(44, 165);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(DoThgeThingTM);
            Controls.Add(checkBox_counterfx);
            Controls.Add(textBox1);
            Controls.Add(add);
            Controls.Add(choose);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button choose;
        private OpenFileDialog openFileDialog1;
        private Button add;
        private TextBox textBox1;
        private CheckBox checkBox_counterfx;
        private Button DoThgeThingTM;
        private ListBox listBox1;
        private Button button1;
    }
}