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
    public partial class Form3 : Form
    {
        MediaPlayer.MediaPlayerClass mp3 = new MediaPlayer.MediaPlayerClass();
        SoundPlayer cs = new SoundPlayer();
        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
            this.Text = "윷놀이 게임";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.mp3.EnableContextMenu = true;
            this.mp3.FileName = @"C:\Lecture\_5_CSharp\TeamProject\Team_3\윷놀이_0827_최종본\_16_NetworkStreamClientForm\bin\Debug/처음.mp3";
            cs.SoundLocation = "클릭.wav";
        }

        private void Btconnetc_Click(object sender, EventArgs e)
        {
            cs.Play();
            Form1 fm1 = new Form1();
            this.Hide();
           mp3.Stop();
            fm1.Show();

        }

        private void Btdisconnect_Click(object sender, EventArgs e)
        {
            cs.Play();
            this.Close();
        }
    }
}
