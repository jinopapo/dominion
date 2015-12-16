using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dominion
{
    class Market :PlayCard
    {

        public Market(Player player)
        {
            this.player = player;
            Click += new EventHandler(MoveField);
            Click += new EventHandler(DoAction);
            Type["action"] = true;
            cost = 5;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetTurn() && player.GetAction() != 0)
            {
                player.DrawCard(1);
                player.UseBuy(-1);
                player.UseMoney(-1);
                player.LabeUpdate();
                Sort();
            }
        }
    }
}
