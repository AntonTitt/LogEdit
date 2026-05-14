using System;
using System.Collections.Generic;
using System.Text;
using static LogEdit.BattleDef;
using static LogEdit.Player;

namespace LogEdit
{
    internal class Battle
    {
        public DateTime Begintime;
        public DateTime Endtime;
        public Player[] Players1;
        public Player[] Players2;
        public string Map;
        public string Mode;
        public string Outcome;// winner team 1, winner team 2, winner team 0 (draw)
        
        public Battle(DateTime begintime, DateTime endtime, Player[] players1, Player[] players2, string map, string mode, string outcome)
        {
            Begintime = begintime;
            Endtime = endtime;
            Players1 = players1;
            Players2 = players2;
            Map= map; Mode = mode; Outcome = outcome;
        }
    }
}
