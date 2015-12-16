using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dominion
{
    class Landtag : PlayCard
    {

        public Landtag(List<PlayCard> ShowField, List<PlayCard> ShowHand, Player player)
        {
            this.Field = ShowField;
            this.Hand = ShowHand;
            this.player = player;
            Type["victory"] = true;
            victory = 3;
            cost = 5;
        }
    }
}
