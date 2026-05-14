using System;
using System.Collections.Generic;
using System.Text;

namespace LogEdit
{
    internal class BattleDef
    {
        public struct Battle(DateTime begintime, DateTime endtime, Player[] players1, Player[] players2, string map, string mode, string outcome)
        {
            public DateTime Begintime { get; set; } = begintime;
            public DateTime Endtime { get; set; } = endtime;
            public Player[] Players1 { get; set; } = players1;
            public Player[] Players2 { get; set; } = players2;
            public string Map { get; set; } = map;
            public string Mode { get; set; } = mode;
            public string Outcome { get; set; } = outcome;// winner team 1, winner team 2, winner team 0 (draw)
        }
        public struct Player(string nikname, string[] weapons, int damage, int damagetaken)
        {
            public string Nikname { get; set; } = nikname;
            public string[] Weapons { get; set; } = weapons;
            public int Damage { get; set; } = damage;
            public int Damagetaken { get; set; } = damagetaken;
        }
    }
}
