using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion
{
    class PlayCard : PictureBox
    {
        protected Dictionary<string,bool> Type = new Dictionary<string,bool>(); 
        protected int mx;
        protected int my;
        protected int sx;
        protected int sy;
        protected int time = 0;
        protected Timer anime = new Timer();
        protected Timer reactionAnime = new Timer();
        protected List<PlayCard> Field;
        protected List<PlayCard> Hand;
        protected int money;
        protected int action;
        protected int victory;
        protected int cost;
        protected Player player;
        protected bool deck;
        protected bool trash;
        protected int buy;
        protected Deck Deck;
        protected bool flag;
        protected int AddCost;
        public string text;
        protected Label pop = new Label();
        protected Form1 f;
        protected bool clicked;

        void init()
        {
            anime.Tick += new EventHandler(MoveCard);
            anime.Interval = 1;
            reactionAnime.Tick += new EventHandler(OpenReaction);
            Type.Add("money", false);
            Type.Add("action", false);
            Type.Add("victory", false);
            money = 0;
            action = 0;
            victory = 0;
            deck = false;
            trash = false;
            pop.Visible = false;
            clicked = false;
        }

        public PlayCard()
        {
            init();
        }

        public PlayCard(Player p)
        {
            init();
            player = p;
            Hand = p.GetShowHand();
        }

        public void MoveCard(Object myObject,EventArgs myEventArgs)
        {
            this.Location = new Point(this.Location.X + (int)mx, this.Location.Y + (int)my);
            time++;
            if (time == 10)
            {
                time = 0;
                anime.Stop();
                if (deck)
                {
                    this.Visible = false;
                    deck = false;
                    Location = new Point(Location.X-80,Location.Y);
                }
                if (trash)
                {
                    this.Image = null;
                    trash = false;
                }
            }
        }

        public void OpenReaction(Object myObject, EventArgs myEventArgs)
        {
            if (!flag)
            {
                Location = new Point(Location.X, Location.Y - (int)my);
            }
            else
            {
                Location = new Point(Location.X, Location.Y - (int)my);
            }
            if (Location.Y == sy - 30)
            {
                Image = global::dominion.Properties.Resources.ishidatami;
                flag = true;
                my = -5;
            }
            else if (Location.Y == sy && flag)
            {
                reactionAnime.Stop();
                flag = false; ;
            }
        }

        public void PopText(Object myObject, EventArgs myEventArgs)
        {
            f.label12.Location = new Point(Location.X, Location.Y+120);
            f.label12.Visible = true;
            f.label12.Text = text;
            f.label12.BringToFront();
        }

        public void CloseText(Object myObject, EventArgs myEventArgs)
        {
            f.label12.Visible = false;
        }


        internal void Reaction()
        {
            flag = false;
            my = 5;
            sy = Location.Y;
            reactionAnime.Start();
        }

        public void ChangePoint(int x,int y)
        {
            x -= this.Location.X;
            y -= this.Location.Y;
            mx = x / 10;
            my = y / 10;
            anime.Start();
        }

        public void ChangePointPara(int x, int y)
        {
            mx = (int)Math.Round((double)(x - this.Location.X) / 100);
            my = (int)Math.Round((double)(y - this.Location.Y) / 100);
            while (time != 100)
            {
                this.Location = new Point(this.Location.X + (int)mx, this.Location.Y + (int)my);
                time++;
                Refresh();
            }
            this.Location = new Point(x, y);
            Refresh();
            time = 0;
            if (trash)
            {
                this.Image = null;
                this.Dispose();
                trash = false;
            }
            if (deck)
            {
                this.Visible = false;
                deck = false;
                Location = new Point(Location.X - 80, Location.Y);
            }
        }

        public bool ShowType(string s)
        {
            return Type[s];
        }

        public void MoveField(object sender, EventArgs e)
        {
            if (!player.GetShowField().Contains(this) && player.GetTurn())
            {
                if (Type["action"])
                {
                    if (player.GetAction() != 0)
                    {
                        player.GetShowField().Add(this);
                        player.GetShowHand().Remove(this);
                        ChangePointPara(180 + 20 * (player.GetShowField().Count - 1), 370);
                        player.getHand().Remove(this.Name);
                        player.GetField().Add(this.Name);
                        Sort();
                        player.LabeUpdate();
                    }
                }
                else
                {
                    player.GetShowField().Add(this);
                    player.GetShowHand().Remove(this);
                    ChangePointPara(180 + 20 * (player.GetShowField().Count - 1), 370);
                    player.getHand().Remove(this.Name);
                    player.GetField().Add(this.Name);
                    Sort();
                    player.LabeUpdate();
                }
            }
            this.Enabled = false;
        }

        private void MineMode(object sender, EventArgs e)
        {
            DisCard();
            player.AddMineMoney(cost+3);
            for (int i = 0; i < Hand.Count; i++)
            {
                if (Hand[i].ShowType("money"))
                {
                    Hand[i].MineModeOff();
                }
            }
        }

        internal void AddDis(object sender, EventArgs e)
        {

        }

        public void TrashCard(object sender, EventArgs e){
            player.TrashCard(this);
        }

        private void DisMode(object sender, EventArgs e)
        {
            DisCard();
            player.DisModeOff();
            player.AddSupplyToTrashOn(cost + AddCost);
        }

        internal virtual void DoAction(object sender, EventArgs e) { }

        void DisCard()
        {
            player.AddDis(this.Name);
            player.RemoveHandCard(this);
            Trash(980, 540);
            Sort();
        }

        internal void ClickOff()
        {
            if (!Type["victory"] || Type["action"] || Type["money"])
            {
                Click -= new EventHandler(MoveField);
            }
            if (Type["action"])
            {
                Click -= new EventHandler(DoAction);
            }
            if (Type["money"])
            {
                Click -= new EventHandler(AddMoney);
            }
        }

        internal void ClickOn()
        {
            if (Type["money"])
            {
                Click += new EventHandler(AddMoney);
            }
            if (!(Type["victory"] && !Type["action"] && !Type["money"]))
            {
                Click += new EventHandler(MoveField);
            }
            if (Type["action"])
            {
                Click += new EventHandler(DoAction);
            }
        }

        internal void TrashModeOn()
        {
            if (!(Type["victory"] && !Type["action"] && !Type["money"]))
            {
                Click -= new EventHandler(MoveField);
            }
            if (Type["action"])
            {
                Click -= new EventHandler(DoAction);
            }
            if (Type["money"])
            {
                Click -= new EventHandler(AddMoney);
            }
            Click += new EventHandler(TrashCard);
        }

        internal void TrashModeOff()
        {
            if (!(Type["victory"] && !Type["action"] && !Type["money"]))
            {
                Click += new EventHandler(MoveField);
            }
            if (Type["action"])
            {
                Click += new EventHandler(DoAction);
            }
            if (Type["money"])
            {
                Click += new EventHandler(AddMoney);
            }
            Click -= new EventHandler(TrashCard);
        }

        internal void MineModeOn()
        {
            Click += new EventHandler(MineMode);
        }

        private void MineModeOff()
        {
            Click -= new EventHandler(MineMode);
        }

        public void Sort()
        {
            for (int i = 0; i < player.GetShowHand().Count; i++)
            {
                if (player.GetShowHand()[i].Left != player.GetFieldLeft() + 20 * i)
                {
                    player.GetShowHand()[i].ChangePoint(player.GetFieldLeft() + 20 * i, player.GetFieldTop());
                }
                player.GetShowHand()[i].BringToFront();
            }
        }

        public void AddMoney(object sender, EventArgs e)
        {
            if (player.GetTurn() && !clicked) 
            {
                player.UseMoney(-money);
                player.EndAction();
                clicked = true;
            }
        }

        internal void AddMoney()
        {
            player.UseMoney(-money);
            player.EndAction();
        }

        internal void Trash(int p1, int p2)
        {
            trash = true;
            ChangePointPara(p1, p2);
        }

        internal void AddDeck(int p1, int p2)
        {
            deck = true;
            ChangePointPara(p1,p2);
        }

        internal int GetCost()
        {
            return cost;
        }

        internal void DisModeOn(int n)
        {
            ClickOff();
            Click += new EventHandler(DisMode);
            AddCost = n;
        }

        internal void DisModeOff()
        {
            Click -= new EventHandler(DisMode);
        }
    }    
    

}
    