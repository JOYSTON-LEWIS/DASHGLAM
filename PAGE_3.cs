using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Introduction
{
    public partial class PAGE_3 : Form
    {
        SoundPlayer music = new SoundPlayer(Introduction.Properties.Resources.Corporate);
        // SoundPlayer SimpleSound = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Corporate.wav");

        public PAGE_3()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            PAGE_2 P2 = new PAGE_2();
            P2.Show();
            this.Hide();
            */

            this.Hide();
            // SimpleSound.Stop();
            music.Stop();
            PAGE_2 P2 = new PAGE_2();
            P2.Closed += (s, args) => this.Close();
            P2.Show();
        }

        private void PAGE_3_Load(object sender, EventArgs e)
        {
            // SimpleSound.Play();
            music.Play();
        }
    }
}
