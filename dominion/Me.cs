using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion
{
    class Me : Player
    {
        Deck ShowDeck;
        delegate void TrashDelegate(int x, int y);
        delegate void TrashVisbleDelegate();
        delegate void ShowHandDelegate(string s, int x, int y);
        delegate void SetCountDelegate(int p);
        delegate void SetTurnDelegate();
        delegate void DrawCardDelegate(int p);
        delegate void AllSupplyClickDelegate();

        public Me(Form1 f,Disposal Dis)
        {
            fieldLeft = 180;
            fieldTop = 540;
            name = "あなた";
            this.Dis = Dis;
            ShowDeck = new Deck(this, ShowField, ShowHand);
            ShowTrash.Image = global::dominion.Properties.Resources.back;
            ShowTrash.Location = new System.Drawing.Point(20, 540);
            ShowTrash.Name = "trash";
            ShowTrash.Size = new System.Drawing.Size(70, 110);
            ShowTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            ShowTrash.TabIndex = 8;
            ShowTrash.TabStop = false;
            ShowTrash.Visible = false;
            p.Visible = false;
            p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            p.Size = new System.Drawing.Size(70, 110);
            form1 = f;
            form1.Controls.Add(ShowDeck);
            form1.Controls.Add(ShowTrash);
            form1.Controls.Add(p);
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
                    if (Trash.Count != 0)
                    {
                        setDeck();
                    }
                    else
                    {
                        break;
                    }
                    
                }
                k = r.Next(Deck.Count);
                Hand.Add(Deck[k]);
                GetForm().Invoke(new ShowHandDelegate(ShowCard),Deck[k], 100, 540);
                Deck.Remove(Deck[k]);
                GetForm().Invoke(new SetCountDelegate(ShowDeck.SetCount), Deck.Count);
            }
        }

        override internal void ShowCard(string s,int x,int y)
        {
            PlayCard a = new PlayCard();
            switch (s)
            {
                case "銅貨":
                    a = new Cooper(ShowField, ShowHand, this);
                    a.Image = global::dominion.Properties.Resources.銅貨;
                    break;
                case "銀貨":
                    a = new Silver(ShowField, ShowHand, this);
                    a.Image = global::dominion.Properties.Resources.銀貨;
                    break;
                case "金貨":
                    a = new Gold(ShowField, ShowHand, this);
                    a.Image = global::dominion.Properties.Resources.金貨;
                    break;
                case "屋敷":
                    a = new Mansion(ShowField, ShowHand, this);
                    a.Image = global::dominion.Properties.Resources.屋敷;
                    break;
                case "公領":
                    a = new Landtag(ShowField, ShowHand, this);
                    a.Image = global::dominion.Properties.Resources.公領;
                    break;
                case "属州":
                    a = new Province(ShowField, ShowHand, this);
                    a.Image = global::dominion.Properties.Resources.属州;
                    break;
                case "地下貯蔵庫":
                    a = new UndergroundRepository(ShowField, ShowHand, this, form1, ShowDeck);
                    a.Image = global::dominion.Properties.Resources.地下貯蔵庫;
                    break;
                case "市場":
                    a = new Market(this);
                    a.Image = global::dominion.Properties.Resources.市場;
                    break;
                case "民兵":
                    a = new Militia(ShowField, ShowHand, this);
                    a.Image = global::dominion.Properties.Resources.民兵;
                    break;
                case "鉱山":
                    a = new Mine(ShowField, ShowHand, this,ShowDeck);
                    a.Image = global::dominion.Properties.Resources.鉱山;
                    break;
                case "堀":
                    a = new Moat(this);
                    a.Image = global::dominion.Properties.Resources.堀;
                    break;
                case "鍛冶屋":
                    a = new Smithy(this);
                    a.Image = global::dominion.Properties.Resources.鍛冶屋;
                    break;
                case "村":
                    a = new Village(this);
                    a.Image = global::dominion.Properties.Resources.村;
                    break;
                case "木こり":
                    a = new Woodcutter(this);
                    a.Image = global::dominion.Properties.Resources.木こり;
                    break;
                case "改築":
                    a = new Remodel(this);
                    a.Image = global::dominion.Properties.Resources.改築;
                    break;
                case "工房":
                    a = new Workshop(this);
                    a.Image = global::dominion.Properties.Resources.工房;
                    break;
                default:
                    a = new Curse(this);
                    break;
            }   
            a.Location = new System.Drawing.Point(x,y);
            a.Size = new System.Drawing.Size(70, 110);
            a.Name = s;
            a.SizeMode = PictureBoxSizeMode.StretchImage;
            form1.Controls.Add(a);
            a.BringToFront();
            ShowHand.Add(a);
            a.ChangePointPara(160 + 20 * ShowHand.Count, 540);
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].Refresh();
            }
            ShowDeck.Refresh();
            //
            //
            //
            //
            //
            //作れ
            //
            //
            //
            //
            //
        }

        override internal PlayCard GetShowDeck()
        {
            return ShowDeck;
        }

        internal override void TrashCard()
        {
            for (int i = 0; i < ShowHand.Count(); i++)
            {
                ShowHand[i].Trash(20,540);
                AddTrash(ShowHand[i].Name);
                Hand.Remove(ShowHand[i].Name);
                ShowHand.Remove(ShowHand[i]);
                TrashVisible();
            }
            if (ShowHand.Count != 0)
            {
                ShowHand[0].Sort();
            }
        }

        internal override void TrashCard(int p)
        {
           //
            //
            //
            //
            //作れ
            //
            //
            //
        }

        internal override void TrashCard(PlayCard p)
        {
            p.Trash(20,540);
            ShowHand.Remove(p);
            Hand.Remove(p.Name);
            AddTrash(p.Name);
            TrashVisible();
            if (ShowHand.Count != 0)
            {
                ShowHand[0].Sort();
            }
        }

        internal void EnemyTurn()
        {
            for (int i = 0; i < 3; i++)
            {
                Enemy[i].EndTurn();
                if (form1.EndGameFlag())
                {
                    GetForm().Invoke(new EndGameDelegate(form1.EndGame));
                    return;
                }
            }
        }

        internal override void EndTurn()
        {
            GetForm().Invoke(new AllSupplyClickDelegate(form1.AllSupplyClickOff));
            GetForm().Invoke(new AllSupplyClickDelegate(ShowDeck.CardClickOff));
            CardTrash();
            GetForm().Invoke(new TrashVisbleDelegate(TrashVisible));
            for (int i = 0; i < ShowHand.Count; i++)
            {
                GetForm().Invoke(new TrashDelegate(ShowHand[i].Trash), 20, 540);
            }
            for (int i = 0; i < ShowField.Count; i++)
            {
                GetForm().Invoke(new TrashDelegate(ShowField[i].Trash), 20, 540);
            }
            ShowField.Clear();
            ShowHand.Clear();
            DrawCard(5);
            GetForm().Invoke(new SetTurnDelegate(SetTurn));
            ChangeTurn();
            if (form1.EndGameFlag())
            {
                GetForm().Invoke(new EndGameDelegate(form1.EndGame));
            }
            else
            {
                EnemyTurn();
            }
            if (!form1.EndGameFlag())
            {
                GetForm().Invoke(new AllSupplyClickDelegate(ShowDeck.CardClickOn));
                GetForm().Invoke(new AllSupplyClickDelegate(form1.AllSupplyClickOn));
                ChangeTurn();
            }

        }

        internal override void Dispose()
        {
            base.Dispose();
            ShowDeck.Image = null;
            ShowDeck.Dispose();
            ShowTrash.Image = null;
            ShowTrash.Dispose();
        }

        internal override void AddMineMoney(int cost) 
        {
            form1.MineMode(cost);
        }
        internal override void MineModeOff(int cost)
        {
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].ClickOn();
            }
            ShowDeck.CardClickOn();
            form1.MineModeOff(cost);
        }

        internal override void DisCost(int p) 
        {
            if (ShowHand.Count != 0)
            {
                SupplyOff();
                ShowDeck.CardClickOff();
                for (int i = 0; i < ShowHand.Count; i++)
                {
                    ShowHand[i].DisModeOn(p);
                }
            }
        }

        internal override void AddSupplyToTrashOn(int p) 
        {
            form1.AddTrashOn(p);
        }

        internal override void DisModeOff() 
        {
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].DisModeOff();
            }
        }

        internal override void AddSupplyToTrashOff(int p) 
        {
            form1.AddTrashOff(p);
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].ClickOn();
            }
            ShowDeck.CardClickOn();
            SupplyOn();
            LabeUpdate();
        }

        internal override void DeckClickOff()
        {
            ShowDeck.CardClickOff();
        }
    }
}
