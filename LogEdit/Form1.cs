using System.Globalization;
using System.Text.RegularExpressions;
using static LogEdit.Player;
using static LogEdit.Battle;
namespace LogEdit
{
    public partial class Form1 : Form
    {
        int tabindx = 0;
        List<int> counters = new();
        List<Battle> battles = new();
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
                List<string> weapons = [];
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string relevantPart = line.Substring(15);

                    if (relevantPart.StartsWith("====== starting level ======"))
                    {
                    }
                    else if (relevantPart.StartsWith("===== Gameplay '"))
                    {
                        battle.Mode = relevantPart.Split(' ')[2];
                        battle.Map = relevantPart.Split(' ')[5];
                    }
                    else if (relevantPart.StartsWith("===== Gameplay finish"))
                    {
                        battle.Players1 = players1.ToArray();
                        battle.Players2 = players2.ToArray();
                        battle.Outcome = relevantPart.Split(',')[2];
                        battles.Add(battle);
                        for (int i = 0; i < battles.Count; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                dataGridView1.Rows.Add(battle.Players1[j].Nikname, "CarPart_Gun_CannonLong_Relic", "10719", 1, "10719", "CarPart_Gun_CannonLong_Relic", battle.Players2[j].Nikname);
                            }
                        }
                    }
                    else if (relevantPart.StartsWith("Spawn player "))
                    {
                    }
                    else if (relevantPart.StartsWith("Active battle started."))
                    {
                    }
                    else if (relevantPart.StartsWith("Damage."))
                    {
                        string attaker = relevantPart.Split(",")[1][11..].Trim(' ');
                        string weapon = relevantPart.Split(",")[2][8..];

                        Match match = Regex.Match(relevantPart, @"damage:\s*(\d+\.\d+)", RegexOptions.IgnoreCase);
                        float damage = 0;

                        if (match.Success && match.Groups[1].Success)
                        {
                            string numberStr = match.Groups[1].Value;

                            if (float.TryParse(numberStr, CultureInfo.InvariantCulture, out float number))
                                damage = number;
                        }
                        for (int i = 0; i < players1.Count; i++)
                        {
                            if (players1[i].Nikname == attaker)
                            {
                                players1[i].Weapons.Add(weapon);
                            }
                        }
                        for (int i = 0; i < players2.Count; i++)
                        {
                            if (players2[i].Nikname == attaker)
                            {
                                players2[i].Weapons.Add(weapon);
                            }
                        }


                    }
                    else if (relevantPart.StartsWith("Spawn mob. "))
                    {
                    }
                    else if (relevantPart.StartsWith("Score:"))
                    {
                    }
                    else if (relevantPart.StartsWith("Kill."))
                    {
                    }
                    else if (relevantPart.StartsWith("\t assist"))
                    {
                    }
                    else if (relevantPart.StartsWith("Stripe "))
                    {
                    }
                    else if (relevantPart.StartsWith("\tplayer "))
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
                            players1.Add(new Player(relevantPart[(relevantPart.IndexOf("nickname:") + 10)..(relevantPart.IndexOf(' ', (relevantPart.IndexOf("nickname:") + 10)))], [""], 0, 0));
                        }
                        else
                        {
                            players2.Add(new Player(relevantPart[(relevantPart.IndexOf("nickname:") + 10)..(relevantPart.IndexOf(' ', (relevantPart.IndexOf("nickname:") + 10)))], [""], 0, 0));
                        }
                    }
                    else if (relevantPart.StartsWith("====== TestDrive started ======"))
                    {
                    }
                    else if (relevantPart.StartsWith("====== TestDrive finish ======"))
                    {
                    }
                    else
                    {
                        MessageBox.Show(line);
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
