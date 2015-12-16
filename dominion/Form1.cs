using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace dominion
{
    public partial class Form1 : Form
    {
        
        const int pack = 10;

        Supply[] supply = new Supply[10];
        Player[] Player = new Player[4];
        PictureBox[] counter = new PictureBox[10];
        Label[] supplycount = new Label[10];
        List<String> card = new List<String>();
        Disposal Dis = new Disposal();
 

        public Form1()
        {
            InitializeComponent();
        }

        public void DrawStart(List<string> l)
        {
            START.Visible = false;
            pictureBox1.Visible = false;
            card = l;
            Player[0] = new Me(this, Dis);
            for (var i = 1; i < 4; i++)
            {
                Player[i] = new Enemy(this, i, Dis);
            }
            setSupply(l);
            Refresh();
            for (var i = 1; i < 4; i++) 
            {
                Player[i].setFirstDeck();
                Player[i].DrawCard(5);
            }
            Player[0].setFirstDeck();
            Player[0].DrawCard(5);
            Player[0].ChangeTurn();
            for (int i = 0; i < 4; i++)
            {
                int k = 0;
                for (int j = i;k!=3 ; j++)
                {
                    if(j==4)
                    {
                        j = 0;
                    }
                    if (i != j)
                    {
                        Player[i].SetEnemy(Player[j]);
                        k++;
                    }
                }
            }
        }

        public void LabelUpDate()
        {
            MoneyLabel.Text = Player[0].GetMoney().ToString();
            ActioLabel.Text = Player[0].GetAction().ToString();
            BuyLabel.Text = Player[0].GetBuy().ToString();
        }

        internal void EndGame()
        {
            int k,n=0;
            List<int> l = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                k = Player[i].countVictory();
                l.Add(k);
                switch (Player[i].Getname())
                {
                    case "あなた":
                        n = k;
                        label8.Text = k.ToString();
                        break;
                    case "CPU1":
                        label9.Text = k.ToString();
                        break;
                    case "CPU2":
                        label10.Text = k.ToString();
                        break;
                    case "CPU3":
                        label11.Text = k.ToString();
                        break;
                }
            }
            l.Sort();
            for (int i = 0; i < 4; i++)
            {
                if (l[i] == n)
                {
                    n = i;
                    break;
                }
            }
            switch(n){
                case 3:
                    pictureBox4.Image = global::dominion.Properties.Resources.s_ribbon0939;
                    break;
                case 2:
                    pictureBox4.Image = global::dominion.Properties.Resources.s_ribbon0940;
                    break;
                case 1:
                    pictureBox4.Image = global::dominion.Properties.Resources.s_ribbon0941;
                    break;
                case 0:
                    pictureBox4.Image = global::dominion.Properties.Resources.s_ribbon0942;
                    break;
            }
            button1.Visible = true;
            button2.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox2.BringToFront();
            button1.BringToFront();
            button2.BringToFront();
            LabelUpDate();
            Refresh();
        }

        internal int SupplyCount()
        {
            int k=0;
            for (int i = 0; i < 10; i++)
            {
                if (supply[i].GetSupplyCount() == 0)
                {
                    k++;
                }
            }
            if (呪い.GetSupplyCount() == 0)
            {
                k++;
            }
            if (銅貨.GetSupplyCount() == 0)
            {
                k++;
            }
            if (銀貨.GetSupplyCount() == 0)
            {
                k++;
            }
            if (金貨.GetSupplyCount() == 0)
            {
                k++;
            }
            if (屋敷.GetSupplyCount() == 0)
            {
                k++;
            }
            if (公領.GetSupplyCount() == 0)
            {
                k++;
            }
            return k;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                supply[i].Image = null;
                supply[i].Dispose();
            }
            呪い.Image =null;
            呪い.Dispose();
            銅貨.Image = null;
            銅貨.Dispose();
            銀貨.Image =null;
            銀貨.Dispose();
            金貨.Image = null;
            金貨.Dispose();
            公領.Image =null;
            公領.Dispose();
            屋敷.Image = null;
            屋敷.Dispose();
            属州.Image = null;
            属州.Dispose();
            for (int i = 0; i < 4; i++)
            {
                Player[i].Dispose();
            }
            button1.Visible = false;
            button2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            DrawStart(card);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            START.Visible = true;
            pictureBox1.Visible = true;
            for (int i = 0; i < 10; i++)
            {
                supply[i].Image = null;
                supply[i].Dispose();
            }
            呪い.Image = null;
            呪い.Dispose();
            銅貨.Image = null;
            銅貨.Dispose();
            銀貨.Image = null;
            銀貨.Dispose();
            金貨.Image = null;
            金貨.Dispose();
            公領.Image = null;
            公領.Dispose();
            屋敷.Image = null;
            屋敷.Dispose();
            属州.Image = null;
            属州.Dispose();
            for (int i = 0; i < 4; i++)
            {
                Player[i].Dispose();
            }
            button1.Visible = false;
            button2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox1.BringToFront();
            START.BringToFront();
        }
    }
}

