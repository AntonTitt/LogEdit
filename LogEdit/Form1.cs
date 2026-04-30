using System.Text.RegularExpressions;
using static LogEdit.BattleDef;
namespace LogEdit
{
    public partial class Form1 : Form
    {
        int tabindx = 0;
        List<int> counters = new();
        List<Battle> battles = new(15);
        int battlindx = 0;
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

            Battle battle = new();
            using (StreamReader sr = new(openFileDialog1.FileName))
            {
                List<Player> players1 = [];
                List<Player> players2 = [];
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string relevantPart = line.Substring(15);

                    if (relevantPart.StartsWith("====== starting level ======"))
                    {
                    }
                    if (relevantPart.StartsWith("===== Gameplay '"))
                    {
                        battle.Mode = relevantPart.Split(' ')[2];
                        battle.Map = relevantPart.Split(' ')[5];
                    }
                    if (relevantPart.StartsWith("===== Gameplay finish"))
                    {
                        battle.Players1 = players1.ToArray();
                        battle.Players2 = players2.ToArray();
                        battles.Add(battle);
                        for (int i = 0; i < battles.Count; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                dataGridView1.Rows.Add(battle.Players1[j].Nikname, "CarPart_Gun_CannonLong_Relic", "10719", 1, "10719", "CarPart_Gun_CannonLong_Relic", battle.Players2[j].Nikname);
                            }
                        }
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
                    if (relevantPart.StartsWith("\tplayer "))
                    {

                        Match match = Regex.Match(relevantPart, @"team:\s*(\d+)", RegexOptions.IgnoreCase);
                        int teamnum = 0;

                        if (match.Success && match.Groups[1].Success)
                        {
                            string numberStr = match.Groups[1].Value;

                            // Пытаемся преобразовать в int
                            if (int.TryParse(numberStr, out int number))
                                teamnum = number;
                        }
                        if (teamnum == 1)
                        {
                            players1.Add(new Player(relevantPart[(relevantPart.IndexOf("nickname:") + 10)..(relevantPart.IndexOf(' ', (relevantPart.IndexOf("nickname:") + 10)))], "", 0, 0));
                        }
                        else
                        {
                            players2.Add(new Player(relevantPart[(relevantPart.IndexOf("nickname:") + 10)..(relevantPart.IndexOf(' ', (relevantPart.IndexOf("nickname:") + 10)))], "", 0, 0));
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
