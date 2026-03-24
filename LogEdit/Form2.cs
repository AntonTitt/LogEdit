using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LogEdit
{
    public partial class Form2 : Form
    {
        List<string> logNames = [];
        int counter = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonchoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
            if (openFileDialog1.FileName == "openFileDialog1") { return; }

            textBox1.Text = openFileDialog1.FileName;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "openFileDialog1") { return; }
            foreach (string logName in logNames) { if (logName == openFileDialog1.FileName) { return; } }

            logNames.Add(openFileDialog1.FileName);
            listBox1.Items.Add(openFileDialog1.FileName + Environment.NewLine);
        }

        private void buttonDoTheThingTM_Click(object sender, EventArgs e)
        {
            if (logNames.Count < 2) { return; }

            List<StreamReader> readers = [];
            foreach (string logName in logNames) { readers.Add(new StreamReader(logName)); }

            using (StreamWriter sw = new("../../../../combat.log"))
            {
                foreach (StreamReader reader in readers)
                {
                    sw.Write(reader.ReadToEnd());
                }
            }



            logNames.Clear(); listBox1.Items.Clear();
            counter = 0;
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Move);
        }
        private void listBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                var item = (string)e.Data.GetData(typeof(string));

                // Получаем индекс позиции для вставки
                Point point = listBox1.PointToClient(new Point(e.X, e.Y));
                int index = listBox1.IndexFromPoint(point);

                // Удаляем старый элемент и вставляем на новую позицию
                int oldIndex = listBox1.Items.IndexOf(item);

                if (oldIndex != -1 && index != -1)
                {
                    if (oldIndex < index)
                    {
                        index--;
                    }

                    listBox1.Items.Remove(item);
                    listBox1.Items.Insert(index, item);
                    listBox1.SelectedItem = item;
                }
            }
        }

    }
}
