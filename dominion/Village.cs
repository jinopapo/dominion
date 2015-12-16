using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dominion
{
    class Village : PlayCard
    {
        public Village(Player Player)
        {
            player = Player;
            Click += new EventHandler(MoveField);
            Click += new EventHandler(DoAction);
            Type["action"] = true;
            cost = 3;
            action = -1;
            clicked = false;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetAction() != 0 && player.GetTurn() && !clicked)
            {
                clicked = true;
                player.DrawCard(1);
                player.UseAction(action);
                player.LabeUpdate();
            }
        }
    }
}