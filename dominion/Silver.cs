using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dominion
{
    class Silver : PlayCard
    {

        public Silver(List<PlayCard> ShowField, List<PlayCard> ShowHand, Player player)
        {
            this.Field = ShowField;
            this.Hand = ShowHand;
            this.player = player;
            money = 2;
            Type["money"] = true;
            Click += new EventHandler(AddMoney); 
            Click += new EventHandler(MoveField);
            cost = 3;
        }

    }
}
