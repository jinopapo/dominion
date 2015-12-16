using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dominion
{
    public partial class Form2 : Form
    {
        List<string> card = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void setbutton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                card.Add("地下貯蔵庫");
                card.Add("市場");
                card.Add("民兵");
                card.Add("鉱山");
                card.Add("堀");
                card.Add("改築");
                card.Add("鍛冶屋");
                card.Add("村");
                card.Add("木こり");
                card.Add("工房");
            }
            this.Close();
        }

        private void cardSelect(List<string> card)

        {
            Random seed = new Random(DateTime.Now.Second);
            Random r = new Random(seed.Next(10000));
            while (card.Count > 10)
            {
                card.Remove(card[r.Next(card.Count)]);
            }
        }

        private void randombutton_Click(object sender, EventArgs e)
        {
            card = getCheck(randomCheck);
            card = getCardList(card);
            cardSelect(card);
            this.Close();
        }

        private List<string> getCardList(List<string> card)
        {
            List<string> l = new List<string>();
            string s = "";
            s = global::dominion.Properties.Resources.基本;
            Console.WriteLine(s);
            StringReader sr = new StringReader(global::dominion.Properties.Resources.基本);
            while (card.Count > 0)
            {
                switch (card[0])
                {
                    case "基本" :
                        sr = new StringReader(global::dominion.Properties.Resources.基本);
                        break;
                    case "陰謀" :
                        sr = new StringReader(global::dominion.Properties.Resources.陰謀);
                        break;
                    case "海辺" :
                        sr = new StringReader(global::dominion.Properties.Resources.海辺);
                        break;
                    case "異郷":
                        sr = new StringReader(global::dominion.Properties.Resources.異郷);
                        break;
                    case "暗黒時代":
                        sr = new StringReader(global::dominion.Properties.Resources.暗黒時代);
                        break;
                    case "収穫祭":
                        sr = new StringReader(global::dominion.Properties.Resources.収穫祭);
                        break;
                    case "繁栄":
                        sr = new StringReader(global::dominion.Properties.Resources.繁栄);
                        break;
                    case "錬金術":
                        sr = new StringReader(global::dominion.Properties.Resources.錬金術);
                        break;
                    case "ギルド":
                        sr = new StringReader(global::dominion.Properties.Resources.ギルド);
                        break;
                    case "プロモ":
                        sr = new StringReader(global::dominion.Properties.Resources.プロモ);
                        break;
                }
                while((s = sr.ReadLine()) != null){
                    l.Add(s);
                }
                card.Remove(card[0]);
            }
            return l;
        }

        private void selectbutton_Click(object sender, EventArgs e)
        {
            card = getCheck(r_kihon);
            card.AddRange(getCheck(r_inbou));
            card.AddRange(getCheck(r_umibe));
            card.AddRange(getCheck(r_renkin));
            card.AddRange(getCheck(r_hanei));
            card.AddRange(getCheck(r_shukakusai));
            card.AddRange(getCheck(r_ikyou));
            card.AddRange(getCheck(r_ankokujidai));
            card.AddRange(getCheck(r_girudo));
            card.AddRange(getCheck(r_puromo));
            cardSelect(card);            
            this.Close();
        }

        private List<string> getCheck(CheckedListBox box)
        {
            var temp = box;
            List<string> list = new List<string>();
            foreach (string j in temp.CheckedItems)
            {
                list.Add(j);
            }
            return list;
        }

        public List<string> getCard()
        {
            return card;
        }

    }
}
