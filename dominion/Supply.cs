using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace dominion
{
    class Supply : PlayCard
    {
        PictureBox Counter = new PictureBox();
        Label Supplycount = new Label();
        int Count = 0;
        int minecost;
        int TrashCost;
        
        public Supply(Player p, int n,int m,Form1 f,string s)
        {
            cost = n;
            player = p;
            Click += new EventHandler(CardClick);
            this.Counter.Location = new System.Drawing.Point(40, 0);
            this.Counter.Size = new System.Drawing.Size(30, 30);
            this.Counter.Image = global::dominion.Properties.Resources.カウンター;
            this.Counter.BackColor = System.Drawing.Color.Transparent;
            this.Counter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Counter.Name = "カウント";
            this.Supplycount.AutoSize = true;
            this.Supplycount.BackColor = System.Drawing.Color.Transparent;
            this.Supplycount.Location = new System.Drawing.Point(8, 8);
            this.Supplycount.Name = "テキスト";
            this.Supplycount.Size = new System.Drawing.Size(17, 12);
            this.Supplycount.Text = m.ToString();
            this.Counter.Controls.Add(this.Supplycount);
            this.Controls.Add(this.Counter);
            Type[s] = true;
            Count = m;
            this.f = f;
            this.f = player.GetForm();
            MouseHover += new EventHandler(PopText);
            MouseLeave += new EventHandler(CloseText);
        }

        private void CardClick(object sender, EventArgs e)
        {
                if (player.GetTurn() && Count > 0)
                {
                    if (cost <= player.GetMoney() && player.GetBuy() != 0)
                    {
                        AddTrash();
                        player.UseBuy(1);
                        player.UseMoney(cost);
                        player.LabeUpdate();
                        if (player.GetBuy() == 0)
                        {
                            Thread t = new Thread(new ThreadStart(player.EndTurn));
                            t.IsBackground = true;
                            t.Start();
                        }
                    }
                }
        }

        private void MineMode(object sender, EventArgs e)
        {
            player.AddHand(this.Name);
            player.MineModeOff(minecost);
            player.ShowCard(this.Name,Location.X,Location.Y);
            Count--;
            Supplycount.Text = Count.ToString();
            player.SupplyOn();
        }

        private void AddTrashDis(object sender, EventArgs e)
        {
            AddTrash();
            player.AddSupplyToTrashOff(TrashCost);
        }

        void AddTrash()
        {
            player.p.Visible = true;
            player.p.Image = Image;
            player.p.Location = Location;
            player.p.ChangePointPara(20, 540);
            player.p.Visible = false;
            f.AllSupplyRefresh();
            Count--;
            Supplycount.Text = Count.ToString();
            if (Count == 0)
            {
                Image = null;
            }
            player.AddTrash(Name);
            player.TrashVisible();
        }

        internal void AddTrash(Player p)
        {
            PlayCard hoge = new PlayCard();
            hoge.Size = new System.Drawing.Size(70, 110);
            hoge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            f.Controls.Add(hoge);
            hoge.Visible = true;
            hoge.Image = Image;
            hoge.Location = Location;
            hoge.ChangePointPara(p.trashTop, p.trashLeft);
            Count--;
            Supplycount.Text = Count.ToString();
            if (Count == 0)
            {
                Image = null;
            }
            Refresh();
            hoge.Visible = false;
            hoge.Refresh();
        }

        internal int GetSupplyCount()
        {
            return Count;
        }

        internal void SupplyMineModeOn(int cost)
        {
            Click += new EventHandler(MineMode);
            minecost = cost;
        }

        internal void SupplyMineModeOff()
        {
            Click -= new EventHandler(MineMode);
        }

        internal void AddTrashOn(int p)
        {
            Click += new EventHandler(AddTrashDis);
            TrashCost = p;
        }

        internal void AddTrashOff()
        {
            Click -= new EventHandler(AddTrashDis);
        }

        internal int GetCount()
        {
            return Count;
        }
    }
}
