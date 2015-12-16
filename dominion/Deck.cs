using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace dominion
{
    class Deck : PlayCard
    {
        private PictureBox pictureBox2;
        private Label DeckCount;
        private Me me;
        public delegate void MyEventHandler();

        public Deck(Me p,List<PlayCard> f,List<PlayCard> l)
        {
            me = p;
            Field = f;
            Hand = l;
            Click += new EventHandler(CardClick);
            this.pictureBox2 = new PictureBox();
            this.DeckCount = new Label();

            this.Controls.Add(this.pictureBox2);
            this.Image = global::dominion.Properties.Resources.back;
            this.Location = new System.Drawing.Point(100, 540);
            this.Name = "deck";
            this.Size = new System.Drawing.Size(70, 110);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TabIndex = 8;
            this.TabStop = false;
            this.Visible = true;

            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Controls.Add(this.DeckCount);
            this.pictureBox2.Image = global::dominion.Properties.Resources.カウンター;
            this.pictureBox2.Location = new System.Drawing.Point(40, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;

            this.DeckCount.AutoSize = true;
            this.DeckCount.BackColor = System.Drawing.Color.Transparent;
            this.DeckCount.Location = new System.Drawing.Point(7, 9);
            this.DeckCount.Name = "deckCount";
            this.DeckCount.Size = new System.Drawing.Size(11, 12);
            this.DeckCount.TabIndex = 12;
            this.DeckCount.Text = "0";
        }

        public Label GetDeckCount()
        {
            return DeckCount;
        }

        private void CardClick(object sender, System.EventArgs e)
        {
            if(me.GetTurn())
            {
                Thread t = new Thread(new ThreadStart(me.EndTurn));
                t.IsBackground = true;
                t.Start();
            }
        }

        internal void SetPoint(int p1, int p2)
        {
            DeckCount.Location = new System.Drawing.Point(7, 9);
        }

        internal void SetCount(int p)
        {
            DeckCount.Text = p.ToString();
            
            if (p == 0)
            {
                Image.Dispose();
                Image = null;
            }
            else
            {
                Image = global::dominion.Properties.Resources.back;
            }
            if (p >= 10)
            {
                SetPoint(7, 9);
            }
            else
            {
                SetPoint(10, 9);
            }
            Refresh();
        }

        internal void CardClickOff()
        {
            Enabled = false;
        }
        internal void CardClickOn()
        {
            Enabled = true;
        }
    }
}
