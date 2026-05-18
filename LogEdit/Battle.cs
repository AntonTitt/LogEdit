using System;
using System.Collections.Generic;
using System.Text;
using static LogEdit.Round;

namespace LogEdit
{
    internal class Battle
    {
        public List<Round>? Rounds = [];
        public string? Map;
        public string? Mode;

        public Battle(List<Round> rounds, string? map, string? mode)
        {
            Rounds = rounds;
            Map = map;
            Mode = mode;
        }
        public Battle(Round[] rounds, string? map, string? mode)
        {
            Rounds = rounds.ToList();
            Map = map;
            Mode = mode;
        }
        public Battle() { }
    }
}
