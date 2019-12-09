using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_NetworkStreamClientForm
{
    public partial class Form2 : Form
    {

       static public string name;
        SoundPlayer SC = new SoundPlayer();

        public Form2()
        {
            InitializeComponent();
            this.Text = "닉네임";
          
        }

        private void BtNickSave_Click(object sender, EventArgs e)
        {
            SC.SoundLocation = "클릭.wav";
            SC.Play();
            name = tbNick.Text;
            this.Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            SC.Play();
            this.Close();
        }
    }
}
