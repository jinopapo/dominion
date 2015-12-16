using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dominion
{
    class Mansion : PlayCard
    {

        public Mansion(List<PlayCard> ShowField, List<PlayCard> ShowHand, Player player)
        {
            // TODO: Complete member initialization
            this.Field = ShowField;
            this.Hand = ShowHand;
            this.player = player;
            Type["victory"] = true;
            victory = 1;
            cost = 2;
        }
    }
}
