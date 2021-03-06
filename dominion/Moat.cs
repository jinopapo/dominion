﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominion
{
    class Moat : PlayCard
    {
        public Moat(Player Player)
        {
            player = Player;
            Click += new EventHandler(MoveField); 
            Click += new EventHandler(DoAction); 
            Type["action"] = true;
            cost = 2;
            action = 1;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetAction() != 0 && player.GetTurn())
            {
                player.DrawCard(2);
                player.UseAction(action);
                player.LabeUpdate();
            }
        }
    }
}
