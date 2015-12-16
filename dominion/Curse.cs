using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominion
{
    class Curse : PlayCard
    {

        public Curse(Player p)
        {
            player = p;
            Image = global::dominion.Properties.Resources.呪い;
            cost = 0;
        }
    }
}
