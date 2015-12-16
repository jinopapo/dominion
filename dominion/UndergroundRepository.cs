using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dominion
{
    class UndergroundRepository : PlayCard
    {
        int count=0;
        Form1 form1;
        Button button = new Button();

        public UndergroundRepository(List<PlayCard> Field, List<PlayCard> ShowHand,Player Player,Form1 form1,Deck deck)
        {
            this.Field = Field;
            this.Hand = ShowHand;
            player = Player;
            Click += new EventHandler(MoveField); 
            Click += new EventHandler(DoAction); 
            this.form1 = form1;
            button.Location = new System.Drawing.Point(820, 540);
            button.Text = "決定";
            button.Visible = false;
            form1.Controls.Add(button);
            Deck = deck;
            button.Click += new EventHandler(DrawCard);
            Type["action"] = true;
            cost = 2;
        }

        public UndergroundRepository(List<PlayCard> Field, List<PlayCard> ShowHand, Player Player)
        {
            this.Field = Field;
            this.Hand = ShowHand;
            player = Player;
            Type["action"] = true;
            cost = 2;
        }

        private void DrawCard(object sender, EventArgs e)
        {
            for (int i = 0; i < Hand.Count; i++)
            {
                Hand[i].TrashModeOff();
            }
            player.SupplyOn();
            player.DrawCard(count - Hand.Count);
            button.Visible = false;
            Sort();
            Deck.CardClickOn();
            clicked = false;
        }

        internal override void DoAction(object sender, EventArgs e)
        {
            if (player.GetAction() != 0 && player.GetTurn() && !clicked)
            {
                count = Hand.Count();
                for (int i = 0; i < Hand.Count; i++)
                {
                    Hand[i].TrashModeOn();
                }
                Deck.CardClickOff();
                button.Visible = true;
                player.UseAction(action);
                player.SupplyOff();
                clicked = true;
            }
        }
    }
}
