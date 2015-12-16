using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominion
{
    class Workshop : PlayCard
    {
        public Workshop(Player Player)
        {
            player = Player;
            Click += new EventHandler(MoveField);
            Click += new EventHandler(DoAction);
            Type["action"] = true;
            Hand = player.GetShowHand();
            cost = 3;
            action = 1;
            clicked = false;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (!clicked && player.GetAction() != 0 && player.GetTurn())
            {
                for (int i = 0; i < Hand.Count; i++)
                {
                    Hand[i].ClickOff();                
                }
                player.AddSupplyToTrashOn(4);
                player.UseAction(action);
                player.LabeUpdate();
                player.SupplyOff();
                player.DeckClickOff();
                clicked = true;
            }
        }
    }
}
