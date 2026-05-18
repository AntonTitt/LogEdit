using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LogEdit
{
    internal class Player
    {
        public string Nikname;
        public List<string> Weapons;
        public float Damage;
        public float Damagetaken;

        public Player(string nikname, List<string> weapons, int damage, int damagetaken)
        {
            Nikname = nikname;
            Weapons = weapons;
            Damage = damage;
            Damagetaken = damagetaken;
        }
    }
}
