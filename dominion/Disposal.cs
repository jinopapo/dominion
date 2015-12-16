using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dominion
{
    class Disposal : PictureBox
    {
        List<String> l= new List<String>();
        public Disposal()
        {
            Image = global::dominion.Properties.Resources.back;
            Location = new System.Drawing.Point(980, 540);
            Click += new EventHandler(CardClick);
            Name = "Disposal";
            Size = new System.Drawing.Size(70, 110);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Visible = false;
        }

        private void CardClick(object sender, EventArgs e)
        {
            
        }

        public void AddDis(String s)
        {
            l.Add(s);
            Visible = true;
            BringToFront();
        }

        public String GetDis(String s)
        {
            l.Remove(s);
            if (l.Count == 0)
            {
                Visible = false;
            }
            return s;
        }
    }
}
