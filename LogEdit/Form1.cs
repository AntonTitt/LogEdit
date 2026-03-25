using System.Text.RegularExpressions;
using static LogEdit.BattleDef;
namespace LogEdit
{
    public partial class Form1 : Form
    {
        int tabindx = 0;
        List<int> counters = new();
        public Form1()
        {
            InitializeComponent();
            InitializeButtons();


        }
        // ["====== starting level ======"]
        // ["===== Gameplay "]
        // ["Spawn player "]
        // ["Active battle started."] //юзлес
        // ["Damage."]
        // ["Spawn mob. "] //рейды получаеца
        // ["Score:"]
        // ["Kill."]
        // ["\t assist"]
        // ["Stripe "] //нашивка
        // ["\tplayer "]
        // ["====== TestDrive started ======"]
        // ["====== TestDrive finish ======"]
        void InitializeButtons()
        {

            Button ShowDialButton = new()
            {
                Location = new Point(5, 5),
                Name = "ShowDialButton",
                Size = new Size(150, 30),
                TabIndex = tabindx++,
                Text = "Выбери файл",
                UseVisualStyleBackColor = true
            };
            Button Form2Button = new()
            {
                Location = new Point(160, 5),
                Name = "Form2Button",
                Size = new Size(150, 30),
                TabIndex = tabindx++,
                Text = "Склеить логи",
                UseVisualStyleBackColor = true
            };
            ShowDialButton.Click += ShowDial;
            Form2Button.Click += ShowForm2;


            Controls.Add(ShowDialButton);
            Controls.Add(Form2Button);
        }
        void ShowDial(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "openFileDialog1") return;

            using (StreamReader sr = new(openFileDialog1.FileName))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string relevantPart = line.Substring(15);

                    if (relevantPart.StartsWith("====== starting level ======"))
                    {
                    }
                    if (relevantPart.StartsWith("===== Gameplay "))
                    {
                    }
                    if (relevantPart.StartsWith("Spawn player "))
                    {
                    }
                    if (relevantPart.StartsWith("Active battle started."))
                    {
                    }
                    if (relevantPart.StartsWith("Damage."))
                    {
                    }
                    if (relevantPart.StartsWith("Spawn mob. "))
                    {
                    }
                    if (relevantPart.StartsWith("Score:"))
                    {
                    }
                    if (relevantPart.StartsWith("Kill."))
                    {
                    }
                    if (relevantPart.StartsWith("  assist"))
                    {
                    }
                    if (relevantPart.StartsWith("Stripe "))
                    {
                    }
                    if (relevantPart.StartsWith(" player "))
                    {
                        Match match = Regex.Match(relevantPart, @"player\s*(\d+)", RegexOptions.IgnoreCase);
                        int p = 0;

                        if (match.Success && match.Groups[1].Success)
                        {
                            string numberStr = match.Groups[1].Value;

                            // Пытаемся преобразовать в int
                            if (int.TryParse(numberStr, out int number))
                                p = number;
                        }
                    }
                    if (relevantPart.StartsWith("====== TestDrive started ======"))
                    {
                    }
                    if (relevantPart.StartsWith("====== TestDrive finish ======"))
                    {
                    }
                }
            }

        }

        void ShowForm2(object sender, EventArgs e)
        {
            var mForm = new Form2();
            mForm.Show();
        }
    }
}
