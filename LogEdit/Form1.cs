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

            using (StreamReader sr = new(openFileDialog1.FileName))
            {
                List<Player> players1 = [];
                List<Player> players2 = [];
                List<string> weapons = [];
                Battle battle = new();
                int current_round = 1;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string relevantPart = line.Substring(15);

                    if (relevantPart.StartsWith("====== starting level ======"))
                    {
                    }
                    else if (relevantPart.StartsWith("===== Gameplay '"))
                    {
                        battle.Rounds.Add(new Round());
                        battle.Mode = relevantPart.Split(' ')[2];
                        battle.Map = relevantPart.Split(' ')[5];
                    }
                    else if (relevantPart.StartsWith("===== Gameplay finish"))
                    {
                        battle.Rounds[current_round - 1].Players1 = players1.ToArray();
                        battle.Rounds[current_round - 1].Players2 = players2.ToArray();
                        battle.Rounds[current_round - 1].Outcome = relevantPart.Split(',')[2];
                        players1.Clear();
                        players2.Clear();
                        battles.Add(battle);
                        for (int i = 0; i < battles.Count; i++)
                        {
                            //for (int j = 0; j < 8; j++){dataGridView1.Rows.Add(battle.Rounds[current_round].Players1[j].Nikname, battle.Rounds[current_round].Players1[j].Weapons[battle.Rounds[current_round].Players1[j].Weapons.Count - 1], battle.Rounds[current_round].Players1[j].Damage, 1, battle.Rounds[current_round].Players2[j].Damage, battle.Rounds[current_round].Players2[j].Weapons[battle.Rounds[current_round].Players2[j].Weapons.Count - 1], battle.Rounds[current_round].Players2[j].Nikname); }
                            for (int j = 0; j < battles[i].Rounds.Count; j++)
                            {
                                if (battles[i].Rounds[j].Players1.Count() == battles[i].Rounds[j].Players2.Count())
                                {
                                    for (int k = 0; k < battles[i].Rounds[j].Players1.Count(); k++)
                                    {
                                        dataGridView1.Rows.Add(battles[i].Rounds[j].Players1[k].Nikname, battles[i].Rounds[j].Players1[k].Weapons[battles[i].Rounds[j].Players1[k].Weapons.Count - 1], battles[i].Rounds[j].Players1[k].Damage, j + 1, battles[i].Rounds[j].Players2[k].Damage, battles[i].Rounds[j].Players2[k].Weapons[battles[i].Rounds[j].Players2[k].Weapons.Count - 1], battles[i].Rounds[j].Players2[k].Nikname);
                                    }
                                }
                                if (battles[i].Rounds[j].Players1.Count() < battles[i].Rounds[j].Players2.Count())
                                {
                                    //сделать отображение при неровных командах
                                }
                                if (battles[i].Rounds[j].Players1.Count() > battles[i].Rounds[j].Players2.Count())
                                {

                                }

                            }
                        }
                    }
                    else if (relevantPart.StartsWith("===== Best Of N "))
                    {
                        battle.Rounds.Add(new Round());
                        battle.Rounds[current_round - 1].Players1 = players1.ToArray();
                        battle.Rounds[current_round - 1].Players2 = players2.ToArray();
                        battle.Rounds[current_round - 1].Outcome = relevantPart.Split(',')[2];
                        players1.Clear();
                        players2.Clear();
                        Match match = Regex.Match(relevantPart, @"round\s*(\d+)", RegexOptions.IgnoreCase);
                        int round = 0;

                        if (match.Success && match.Groups[1].Success)
                        {
                            string numberStr = match.Groups[1].Value;

                            // Пытаемся преобразовать в int
                            if (int.TryParse(numberStr, out int number))
                                round = number;
                        }

                        current_round = round + 1;

                        match = Regex.Match(relevantPart, @"winner team\s*(\d+)", RegexOptions.IgnoreCase);
                        int team = 0;

                        if (match.Success && match.Groups[1].Success)
                        {
                            string numberStr = match.Groups[1].Value;

                            // Пытаемся преобразовать в int
                            if (int.TryParse(numberStr, out int number))
                                team = number;
                        }
                        switch (team)
                        {
                            case 1:
                                battle.Rounds[current_round - 1].Outcome = "winner team 1";
                                break;
                            case 2:
                                battle.Rounds[current_round - 1].Outcome = "winner team 2";
                                break;
                            case 0:
                                battle.Rounds[current_round - 1].Outcome = "winner team 0";
                                break;
                            default:
                                battle.Rounds[current_round - 1].Outcome = "winner team -1";
                                break;
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
                        bool flag = true;
                        bool flag2 = true;
                        for (int i = 0; i < players1.Count; i++)
                        {
                            if (players1[i].Nikname == attaker)
                            {
                                foreach (string s in relevantPart.Split(',')[3].Split('|'))
                                {
                                    if (s == "SUICIDE" || s == "CONTACT")
                                    {
                                        flag = false;
                                        flag2 = false;
                                    }
                                }
                                foreach (string w in players1[i].Weapons)
                                {
                                    if (weapon == w)
                                    {
                                        flag2 = false;
                                    }
                                }
                                if (flag2)
                                    players1[i].Weapons.Add(weapon[9..^1]);

                                if (flag)
                                    players1[i].Damage += damage;
                            }
                        }
                        flag2 = true;
                        flag = true;
                        for (int i = 0; i < players2.Count; i++)
                        {
                            if (players2[i].Nikname == attaker)
                            {
                                foreach (string s in relevantPart.Split(',')[3].Split('|'))
                                {
                                    if (s == "SUICIDE" || s == "CONTACT")
                                    {
                                        flag = false;
                                        flag2 = false;
                                    }
                                }
                                foreach (string w in players2[i].Weapons)
                                {
                                    if (weapon == w)
                                    {
                                        flag2 = false;
                                    }
                                }
                                if (flag2)
                                    players2[i].Weapons.Add(weapon[9..^1]);

                                if (flag)
                                    players2[i].Damage += damage;
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
                            players1.Add(new Player(relevantPart.Split(',')[3][11..].Trim(' '), [""], 0, 0));
                            //players1.Add(new Player(relevantPart[(relevantPart.IndexOf("nickname:") + 10)..(relevantPart.IndexOf(' ', (relevantPart.IndexOf("nickname:") + 10)))], [""], 0, 0));
                        }
                        else
                        {
                            players2.Add(new Player(relevantPart.Split(',')[3][11..].Trim(' '), [""], 0, 0));
                            //players2.Add(new Player(relevantPart[(relevantPart.IndexOf("nickname:") + 10)..(relevantPart.IndexOf(' ', (relevantPart.IndexOf("nickname:") + 10)))], [""], 0, 0));
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
