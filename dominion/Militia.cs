using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominion
{
    class Militia : PlayCard
    {
        public Militia(List<PlayCard> ShowField, List<PlayCard> ShowHand, Player player)
        {
            this.Field = ShowField;
            this.Hand = ShowHand;
            this.player = player;
            Click += new EventHandler(MoveField);
            Click += new EventHandler(DoAction);
            Type["action"] = true;
            action = 1;
            cost = 4;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetTurn() && player.GetAction() != 0)
            {
                for (int i = 0; i < player.GetEnemy().Count; i++)
                {
                    player.GetEnemy()[i].TrashCard(player.GetEnemy()[i].getHand().Count - 3);
                }
                player.UseMoney(-2);
                player.UseAction(action);
                player.LabeUpdate();
            }
        }
    }
}
