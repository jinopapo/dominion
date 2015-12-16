using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion
{
    class Player
    {
        protected List<string> Deck = new List<string>();
        protected List<string> Hand = new List<string>();
        protected List<string> Trash = new List<string>();
        protected List<string> Field = new List<string>();
        protected List<PlayCard> ShowField = new List<PlayCard>();
        protected List<PlayCard> ShowHand = new List<PlayCard>();
        protected PlayCard ShowTrash = new PlayCard();
        protected Form1 form1;
        protected bool Turn = false;
        protected int Money = 0;
        public PlayCard p = new PlayCard();
        protected int action=1;
        protected int buy = 1;
        protected int fieldLeft;
        protected int fieldTop;
        internal int trashLeft;
        internal int trashTop;
        protected string name;
        protected Disposal Dis;
        protected int keepbuy;
        protected List<Player> Enemy = new List<Player>();
        protected delegate void AddDeckDelegate(int x, int y);
        protected delegate void EndGameDelegate();

        internal void SetEnemy(Player p)
        {
            Enemy.Add(p);
        }

        virtual internal void setDeck()
        {
            Deck.AddRange(Trash);
            Trash.Clear();
            GetForm().Invoke(new AddDeckDelegate(ShowTrash.AddDeck), 100, 540);
        }

        virtual internal void DrawCard(int n) { }

        virtual internal void ShowCard(string s,int x,int y){ }

        public void TrashVisible()
        {
            if (Trash.Count != 0)
            {
                ShowTrash.Visible = true;
                ShowTrash.Refresh();
                ShowTrash.BringToFront();
            }
        }

        internal void setFirstDeck()
        {
            for (int i = 0; i < 7; i++)
            {
                Deck.Add("銅貨");
            }
            for (int i = 0; i < 3; i++)
            {
                Deck.Add("屋敷");
            }
        }

        internal List<string> getHand()
        {
            return Hand;
        }

        internal void CardTrash()
        {
            Trash.AddRange(Hand);
            Trash.AddRange(Field);
            Hand.Clear();
            Field.Clear();
        }

        internal bool GetTurn()
        {
            return Turn;
        }

        internal void AddTrash(string Name)
        {
            Trash.Add(Name);
        }

        internal int getDeckCount()
        {
            return Deck.Count;
        }

        internal void ChangeTurn()
        {
            Turn = !Turn;
        }

        internal List<string> GetField()
        {
            return Field;
        }

        internal List<PlayCard> GetShowField()
        {
            return ShowField;
        }
        internal List<PlayCard> GetShowHand()
        {
            return ShowHand;
        }

        virtual internal PlayCard GetShowDeck()
        {
            return null;
        }

        internal void UseAction(int action)
        {
            this.action -= action;
        }
        internal int GetAction()
        {
            return action;
        }

        internal void EndAction()
        {
            action = 0;
            for (int i = 0; i < ShowHand.Count; i++)
            {
                if (ShowHand[i].ShowType("action"))
                {
                    ShowHand[i].Click -= new EventHandler(ShowHand[i].MoveField);
                }
            }
        }

        internal void UseBuy(int buy)
        {
            this.buy -= buy;
        }

        internal int GetBuy()
        {
            return buy;
        }

        internal void SetTurn()
        {
            action = 1;
            buy = 1;
            Money = 0;
            form1.LabelUpDate();
            form1.Refresh();
        }

        internal void UseMoney(int money)
        {
            this.Money -= money;
        }

        internal int GetMoney()
        {
            return Money;
        }

        internal void LabeUpdate()
        {
            form1.LabelUpDate();
        }

        internal virtual void EndTurn(){ }

        internal virtual void TrashCard(){ }

        internal virtual void TrashCard(int p) { }

        internal virtual void TrashCard(PlayCard p) { }

        internal int GetFieldLeft()
        {
            return fieldLeft;
        }

        internal int GetFieldTop()
        {
            return fieldTop;
        }

        internal int countVictory()
        {
            Deck.AddRange(Hand);
            Deck.AddRange(Trash);
            Deck.AddRange(Field);
            int k = 0;
            Console.WriteLine(name);
            for (int i = 0; i < Deck.Count; i++)
            {
                Console.WriteLine(Deck[i]);
                switch (Deck[i])
                {
                    case "屋敷":
                        k++;
                        break;
                    case "公領":
                        k += 3;
                        break;
                    case "属州":
                        k += 6;
                        break;
                    case "呪い":
                        k--;
                        break;
                    default:
                        break;
                }
            }
            return k;
        }

        internal string Getname()
        {
            return name;
        }

        internal virtual void Dispose()
        {
            for (int i = 0; i < ShowHand.Count; i++)
            {
                ShowHand[i].Image = null;
                ShowHand[i].Dispose();
            }
            for (int i = 0; i < ShowField.Count; i++)
            {
                ShowField[i].Image = null;
                ShowField[i].Dispose();
            }
        }

        internal void AddDis(string s)
        {
            Dis.AddDis(s);
        }

        virtual internal void AddMineMoney(int cost){ }

        internal void AddHand(string p)
        {
            Hand.Add(p);
        }

        internal void SupplyOff()
        {
            keepbuy = buy;
            buy = 0;
        }

        internal void SupplyOn()
        {
            buy = keepbuy;
        }

        internal virtual void MineModeOff(int cost){ }

        internal List<Player> GetEnemy()
        {
            return Enemy;
        }

        internal virtual void DisCost(int p){ }

        internal virtual void AddSupplyToTrashOn(int p){ }

        internal virtual void AddSupplyToTrashOff(int p){ }

        internal virtual void DisModeOff(){ }

        internal virtual void DeckClickOff() { }

        internal virtual void RemoveHandCard(PlayCard p)
        {
            ShowHand.Remove(p);
            Hand.Remove(p.Name);
        }

        internal Form1 GetForm()
        {
            return form1;
        }
    }
}
