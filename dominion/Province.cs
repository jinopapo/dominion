using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dominion
{
    class Province : PlayCard
    {

        public Province(List<PlayCard> ShowField, List<PlayCard> ShowHand, Player player)
        {
            // TODO: Complete member initialization
            this.Field = ShowField;
            this.Hand = ShowHand;
            this.player = player;
            Type["victory"] = true;
            victory = 6;
            cost = 8;
        }
    }
}
