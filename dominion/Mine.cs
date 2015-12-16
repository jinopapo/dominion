using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominion
{
    class Mine : PlayCard
    {
        /*
         * ない硬貨が獲得できる
         * お金がないとき使うと何もできない
         */

        public Mine(List<PlayCard> Field, List<PlayCard> ShowHand, Player Player, Deck deck)
        {
            this.Field = Field;
            this.Hand = ShowHand;
            player = Player;
            Click += new EventHandler(MoveField);
            Click += new EventHandler(DoAction);
            Type["action"] = true;
            action = 1;
            cost = 5;
            Deck = deck;
        }

        public Mine(List<PlayCard> Field, List<PlayCard> ShowHand, Player Player)
        {
            this.Field = Field;
            this.Hand = ShowHand;
            player = Player;
            Type["action"] = true;
            action = 1;
            cost = 5;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetTurn() && player.GetAction() != 0)
            {
                for (int i = 0; i < Hand.Count; i++)
                {
                    if (Hand[i].ShowType("money"))
                    {
                        Hand[i].MineModeOn();
                    }
                    Hand[i].ClickOff();
                }
                player.UseAction(action);
                player.LabeUpdate();
                player.SupplyOff();
                Deck.CardClickOff();
            }
        }
    }
}
