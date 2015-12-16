using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dominion
{
    class Woodcutter : PlayCard
    {
        public Woodcutter(Player Player)
        {
            player = Player;
            Click += new EventHandler(MoveField);
            Click += new EventHandler(DoAction);
            Type["action"] = true;
            cost = 3;
            buy = -1;
            money = -2;
            action = 1;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetAction() != 0 && player.GetTurn())
            {
                player.UseAction(action);
                player.UseBuy(buy);
                player.UseMoney(money);
                player.LabeUpdate();
            }
        }
    }
}