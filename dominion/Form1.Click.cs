using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominion
{
    partial class Form1
    {
        private void StartClick(object sender, EventArgs e)
        {
            List<string> s = new List<string>();
            Form2 option = new Form2();
            option.ShowDialog();
            s = option.getCard();
            DrawStart(s);
        }
    }
}
