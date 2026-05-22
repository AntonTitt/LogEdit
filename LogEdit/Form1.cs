using System.Globalization;
using System.Text.RegularExpressions;
using static LogEdit.Player;
using static LogEdit.Battle;
namespace LogEdit
{
    public partial class Form1 : Form
    {
        //int tabindx = 3;
        List<int> counters = new();
        List<Battle> battles = new();
        List<List<string>> battlesData = [];//todo сделать заполнялку этого листа баттлами
        int battlindx = 0;
        List<int> duration = [];
        int maxplayers = 0;
        public Form1()
        {
            InitializeComponent();


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

        void ShowDial(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "openFileDialog1") return;
            battles.Clear();
            dataGridView1.Rows.Clear();

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
                    string relevantPart = line[15..];

                    if (relevantPart.StartsWith("====== starting level ======"))
                    {
                        if (relevantPart.Contains("hangar")) // если бой завершился некорректно
                        {
                            players1.Clear();
                            players2.Clear();
                            battle = new();
                            current_round = 1;
                        }
                    }
                    else if (relevantPart.StartsWith("===== Gameplay '"))
                    {
                        battle.Rounds.Add(new Round());
                        battle.Mode = relevantPart.Split(' ')[2];
                        battle.Map = relevantPart.Split(' ')[5];
                    }
                    else if (relevantPart.StartsWith("===== Gameplay finish"))
                    {
                        battle.Rounds[current_round - 1].Players1 = [.. players1];
                        battle.Rounds[current_round - 1].Players2 = [.. players2];
                        battle.Rounds[current_round - 1].Outcome = relevantPart.Split(',')[2];
                        players1.Clear();
                        players2.Clear();
                        battles.Add(battle);
                        battle = new();
                        current_round = 1;
                    }
                    else if (relevantPart.StartsWith("===== Best Of N "))
                    {
                        battle.Rounds.Add(new Round());
                        battle.Rounds[current_round - 1].Players1 = [.. players1];
                        battle.Rounds[current_round - 1].Players2 = [.. players2];
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
                        battle.Rounds[current_round - 1].Outcome = team switch
                        {
                            1 => "winner team 1",
                            2 => "winner team 2",
                            0 => "winner team 0",
                            _ => "winner team -1",
                        };
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
                    else if (relevantPart.StartsWith("Player "))//мне както раз попалось "02:12:05.812 | Player Mary activated console!" интересно как так вышло
                    {
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
                for (int i = 0; i < battles.Count; i++)
                {
                    for (int j = 0; j < battles[i].Rounds.Count; j++)
                    {
                        if (battles[i].Rounds[j].Players1.Count() == battles[i].Rounds[j].Players2.Count())
                        {
                            for (int k = 0; k < battles[i].Rounds[j].Players1.Count(); k++)
                            {
                                dataGridView1.Rows.Add(battles[i].Rounds[j].Players1[k].Nikname, battles[i].Rounds[j].Players1[k].Weapons[battles[i].Rounds[j].Players1[k].Weapons.Count - 1],
                                    battles[i].Rounds[j].Players1[k].Damage, j + 1, battles[i].Rounds[j].Players2[k].Damage, battles[i].Rounds[j].Players2[k].Weapons[battles[i].Rounds[j].Players2[k].Weapons.Count - 1],
                                    battles[i].Rounds[j].Players2[k].Nikname);
                            }
                        }
                        if (battles[i].Rounds[j].Players1.Count() < battles[i].Rounds[j].Players2.Count())
                        {
                            //todo сделать отображение при неровных командах
                        }
                        if (battles[i].Rounds[j].Players1.Count() > battles[i].Rounds[j].Players2.Count())
                        {

                        }

                        maxplayers += Math.Max(battles[i].Rounds[j].Players1.Count(), battles[i].Rounds[j].Players2.Count());
                    }
                    duration.Add(maxplayers++);
                    var row = new DataGridViewRow();
                    row.DefaultCellStyle.BackColor = Color.Coral;
                    dataGridView1.Rows.Add(row);
                }

            }


        }

        void ShowForm2(object sender, EventArgs e)
        {
            var mForm = new Form2();
            mForm.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[7].Value is true)
                {
                    if (duration.Contains(i))
                    {

                    }
                }
            }
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
