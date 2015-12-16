using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion
{
    class Enemy : Player
    {
        int num;
        PlayCard ShowDeck;
        List<BuyCard> BuyList = new List<BuyCard>();
        List<DeckCard> DeckList = new List<DeckCard>();
        BuyCard card;
        string buysupply;
        delegate void buySupplyDelegate(string s, Player p);
        delegate void TrashDelegate(int x, int y);
        delegate void TrashVisbleDelegate();
        delegate void ShowHandDelegate(string s, int x, int y);
        delegate void SetCountDelegate(int p);

        struct BuyCard
        {
            internal int cost;
            internal string name;

            public BuyCard(int p, string s)
            {
                cost = p;
                name = s;
            }
        }

        struct DeckCard
        {
            internal int money;
            internal int drawcard;
            internal int action;
            internal string name;

            public DeckCard(int o, int p,int q, string s)
            {
                money = o;
                drawcard = p;
                action = q;
                name = s;
            }
        }
        public Enemy(Form1 form1, int i,Disposal Dis)
        {
            fieldLeft = 900;
            num = i;
            fieldTop = 10 + 120 * num;
            trashTop = 740;
            trashLeft = 10 + 120 * num;
            name = "CPU"+i;
            this.Dis = Dis;
            ShowDeck = new PlayCard();
            ShowDeck.Name = "deck";
            ShowDeck.Size = new System.Drawing.Size(70, 110);
            ShowDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ShowDeck.Image = global::dominion.Properties.Resources.back;
            ShowDeck.Location = new System.Drawing.Point(820, 10 + 120 * num);
            ShowTrash.Location = new System.Drawing.Point(740, 10 + 120 * num);
            ShowTrash.Name = "trash";
            ShowTrash.Image = global::dominion.Properties.Resources.back;
            ShowTrash.Size = new System.Drawing.Size(70, 110);
            ShowTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ShowTrash.TabIndex = 8;
            ShowTrash.TabStop = false;
            ShowTrash.Visible = false;
            p.Visible = false;
            p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            p.Size = new System.Drawing.Size(70, 110);
            this.form1 = form1;
            this.form1.Controls.Add(ShowDeck);
            this.form1.Controls.Add(ShowTrash);
            this.form1.Controls.Add(p);
        }

        override internal void DrawCard(int n)
        {
            Random seed = new Random(DateTime.Now.Second);
            Random r = new Random(seed.Next(10000));
            int k;
            for (int j = 0; j < n; j++)
            {
                if (Deck.Count <= 0)
                {
                   Deck.AddRange(Trash);
                   Trash.Clear();
                   GetForm().Invoke(new AddDeckDelegate(ShowTrash.AddDeck), 820, 10 + 120 * num);
                }
                k = r.Next(Deck.Count);
                Hand.Add(Deck[k]);
                GetForm().Invoke(new ShowHandDelegate(ShowCard), Deck[k], 820, 10 + 120 * num);
                Deck.Remove(Deck[k]);
            }
        }

        override internal void ShowCard(string s,int x,int y)
        {
            PlayCard a = new PlayCard();
            switch (s)
            {
                case "銅貨":
                    a = new Cooper(ShowField, ShowHand, this);
                    break;
                case "銀貨":
                    a = new Silver(ShowField, ShowHand, this);
                    break;
                case "金貨":
                    a = new Gold(ShowField, ShowHand, this);
                    break;
                case "屋敷":
                    a = new Mansion(ShowField, ShowHand, this);
                    break;
                case "公領":
                    a = new Landtag(ShowField, ShowHand, this);
                    break;
                case "属州":
                    a = new Province(ShowField, ShowHand, this);
                    break;
                case "地下貯蔵庫":
                    a = new UndergroundRepository(ShowField, ShowHand, this);
                    break;
                case "市場":
                    a = new Market(this);
                    break;
                case "民兵":
                    a = new Militia(ShowField, ShowHand, this);
                    break;
                case "鉱山":
                    a = new Mine(ShowField, ShowHand, this);
                    break;
                case "堀":
                    a = new Moat(this);
                    break;
                case "鍛冶屋":
                    a = new Smithy(this);
                    break;
                case "村":
                    a = new Village(this);
                    break;
                case "木こり":
                    a = new Woodcutter(this);
                    break;
                case "改築":
                    a = new Remodel(this);
                    break;
                case "工房":
                    a = new Workshop(this);
                    break;
            }   
            a.Location = new System.Drawing.Point(x,y);
            a.Size = new System.Drawing.Size(70, 110);
            a.Name = s;
            a.SizeMode = PictureBoxSizeMode.StretchImage;
            a.Image = global::dominion.Properties.Resources.back;
            form1.Controls.Add(a);
            a.BringToFront();
            ShowHand.Add(a);
            a.ChangePointPara(880 + 20 * ShowHand.Count, 10 + 120 * num);
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].Refresh();
            }
            ShowDeck.Refresh();
        }

        override internal PlayCard GetShowDeck()
        {
            return ShowDeck;
        }

        internal override void TrashCard()
        {
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].Trash(740, 10 + 120 * num);
                AddTrash(Hand[i]);
                Hand.Remove(Hand[i]);
                TrashVisible();
            }
        }

        internal override void TrashCard(int p)
        {
            if (!Hand.Contains("堀"))
            {
                for (int i = 0; i < p; i++)
                {
                    //
                    //
                    //
                    //
                    //カードを捨てるAI作る
                    //
                    //
                    //
                    //
                    ShowHand[0].Trash(740, 10 + 120 * num);
                    AddTrash(ShowHand[0].Name);
                    Hand.Remove(ShowHand[0].Name);
                    ShowHand.Remove(ShowHand[0]);
                    TrashVisible();
                }
                ShowHand[0].Sort();
                ShowTrash.BringToFront();
            }
            else
            {
                for (int i = 0; i < ShowHand.Count; i++)
                {
                    if (ShowHand[i].Name == "堀")
                    {
                        ShowHand[i].Image = global::dominion.Properties.Resources.堀;
                         ShowHand[i].Reaction();
                        break;
                    }
                }
            }
        }

        internal override void EndTurn()
        {
            buy = 1;
            action = 1;
            Money = 0;
            DoTurn();
            CardTrash();
            GetForm().Invoke(new TrashVisbleDelegate(TrashVisible));
            for (int i = 0; i < ShowHand.Count; i++)
            {
                GetForm().Invoke(new TrashDelegate(ShowHand[i].Trash), 740, 10 + 120 * num);
            }
            for (int i = 0; i < ShowField.Count; i++)
            {
                GetForm().Invoke(new TrashDelegate(ShowField[i].Trash), 740, 10 + 120 * num);
            }
            BuyList.Clear();
            ShowField.Clear();
            ShowHand.Clear();
            DrawCard(5);
            GetForm().Invoke(new SetCountDelegate(SetCount), Deck.Count);
            //
            //
            //
            //
            //  AI作れ
            //
            //
            //
            //
            //
        }

        internal void SetCount(int p)
        {
            if (p == 0)
            {
                /*ShowDeck.Image.Dispose();
                ShowDeck.Image = null;*/
                ShowDeck.Visible = false;
            }
            else
            {
                ShowDeck.Visible = true;
                //ShowDeck.Image = global::dominion.Properties.Resources.back;
            }
            ShowDeck.Refresh();
        }

        private void DoTurn()
        {
            buysupply = "";
            SetBuyList();
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].AddMoney();
            }
            PlayAction();
            BuySupply();
        }

        private void SetBuyList()
        {
            card.name = "属州";
            card.cost = 8;
            BuyList.Add(card);
            card.name = "金貨";
            card.cost = 6;
            BuyList.Add(card);
            card.name = "公領";
            card.cost = 5;
            BuyList.Add(card);
            card.name = "銀貨";
            card.cost = 3;
            BuyList.Add(card);
            card.name = "屋敷";
            card.cost = 2;
            BuyList.Add(card);
            card.name = "銅貨";
            card.cost = 0;
            BuyList.Add(card);
        }

        private void PlayAction()
        {
            int actioncount = 0;
            int moneycount = 0;
            int maxmoney = 0;
            string actionname = "";
            /*for (int i = 0; i < ShowHand.Count; i++)
            {
                if (ShowHand[i].ShowType("money"))
                {
                    ShowHand[i].ImageLocation = "C:/Users/ji-no/Documents/Visual Studio 2013/Projects/dominion/dominion/Resources/" + ShowHand[i].Name + ".jpg";
                    ShowHand[i].Update();
                    ShowHand[i].MoveField();
                    ShowHand.Remove(ShowHand[i]);
                }
            }*/
            //form1.BuySuplly(buysupply,this);
        }

        private void BuySupply()
        {
            if (Money >= BuyList[0].cost)
            {
                buysupply = BuyList[0].name;
            }
            if (buysupply == "")
            {
                for (int i = 0; i < BuyList.Count; i++)
                {
                    if (Money >= BuyList[i].cost && form1.GetSupplyCount(BuyList[i].name) != 0)
                    {
                        buysupply = BuyList[i].name;
                        break;
                    }
                }
            }
            GetForm().Invoke(new buySupplyDelegate(form1.BuySuplly), buysupply, this);
            Trash.Add(buysupply);
        }

        void DeckCount(){
            DeckCard a = new DeckCard(0,0,0,"");
            for (int i = 0; i < Deck.Count; i++)
            {
                switch (Deck[i])
                {
                    case "銅貨":
                        a = new DeckCard(1, 0, 0, Deck[i]);
                        break;
                    case "銀貨":
                        a = new DeckCard(2, 0, 0, Deck[i]);
                        break;
                    case "金貨":
                        a = new DeckCard(3, 0, 0, Deck[i]);
                        break;
                    case "屋敷":
                        a = new DeckCard(0, 0, 0, Deck[i]);
                        break;
                    case "公領":
                        a = new DeckCard(0, 0, 0, Deck[i]);
                        break;
                    case "属州":
                        a = new DeckCard(0, 0, 0, Deck[i]);
                        break;
                    case "地下貯蔵庫":
                        a = new DeckCard(0, 0, 0, Deck[i]);
                        break;
                    case "市場":
                        a = new DeckCard(1, 1, 0, Deck[i]);
                        break;
                    case "民兵":
                        a = new DeckCard(2, 0, -1, Deck[i]);
                        break;
                    case "鉱山":
                        a = new DeckCard(0, 0, -1, Deck[i]);
                        break;
                    case "堀":
                        a = new DeckCard(0, 2, -1, Deck[i]);
                        break;
                    case "鍛冶屋":
                        a = new DeckCard(0, 3, -1, Deck[i]);
                        break;
                    case "村":
                        a = new DeckCard(0, 1, 1, Deck[i]);
                        break;
                    case "木こり":
                        a = new DeckCard(2, 0, -1, Deck[i]);
                        break;
                    case "改築":
                        a = new DeckCard(0, 0, -1, Deck[i]);
                        break;
                    case "工房":
                        a = new DeckCard(0, 0, -1, Deck[i]);
                        break;
                }
                DeckList.Add(a);
            }
        }
        private int DeckMoneyCount()
        {
            int draw = 0;
            int mmoney = 0;
            for (int i = 0; i < DeckList.Count; i++)
            {
                mmoney += DeckList[i].money;
                draw += DeckList[i].drawcard;
            }
            return mmoney / draw;
        }

        private int HandsAction()
        {
            int n=0;
            for (int i = 0; i < ShowHand.Count; i++)
            {
                if (ShowHand[i].ShowType("action"))
                {
                    n++;
                }
            }
            return n;
        }

        internal override void Dispose()
        {
            base.Dispose();
            ShowDeck.Image = null;
            ShowDeck.Dispose();
            ShowTrash.Image = null;
            ShowTrash.Dispose();
        }
    }
}
