using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominion
{
    class Smithy : PlayCard
    {
        public Smithy(Player Player)
        {
            player = Player;
            Click += new EventHandler(MoveField);
            Click += new EventHandler(DoAction);
            Type["action"] = true;
            cost = 4;
            action = 1;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetAction() != 0 && player.GetTurn())
            {
                player.DrawCard(3);
                player.UseAction(action);
                player.LabeUpdate();
            }
        }
    }
}