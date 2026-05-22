using System;
using System.Collections.Generic;
using System.Text;
using static LogEdit.Player;

namespace LogEdit
{
    internal class Round//наверное правильней это назвать round и сделать чтоб Round содержал [] round
    {
        public DateTime? Begintime;
        public DateTime? Endtime;
        public Player[]? Players1;
        public Player[]? Players2;
        public string? Outcome;// winner team 1, winner team 2, winner team 0 (draw)

        public Round(DateTime begintime, DateTime endtime, Player[] players1, Player[] players2, string outcome)
        {
            Begintime = begintime;
            Endtime = endtime;
            Players1 = players1;
            Players2 = players2; Outcome = outcome;
        }
        public Round() { }
    }
}
