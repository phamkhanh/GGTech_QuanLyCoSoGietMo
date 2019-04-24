using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GGTech_Common
{
    public class GGTechMsg
    {
        private static GGTechMsg instance; // Ctrl + R + E

        public static GGTechMsg Instance
        {
            get
            {
                if (instance == null)
                    instance = new GGTechMsg();
                return GGTechMsg.instance;
            }
            private set { GGTechMsg.instance = value; }
        }

        public void Red(Label label,string msg)
        {
            label.ForeColor = Color.White;
            label.BackColor = Color.Red;
            label.Text = msg;
        }

        public void Green(Label label, string msg)
        {
            label.ForeColor = Color.White;
            label.BackColor = Color.Green;
            label.Text = msg;
        }
    }
}
