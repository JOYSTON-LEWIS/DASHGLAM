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
    public partial class PAGE_0_HOME : Form
    {
        // SoundPlayer SimpleSound = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Corporate.wav");
        SoundPlayer music = new SoundPlayer(Introduction.Properties.Resources.Corporate);
        public PAGE_0_HOME()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // SimpleSound.Play();

            music.Play();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            PAGE_1 P1 = new PAGE_1();
            P1.Show();
            this.Hide();
            */
            // SimpleSound.Stop();
            music.Stop();
            this.Hide();
            PAGE_1 P1 = new PAGE_1();
            P1.Closed += (s, args) => this.Close();
            P1.Show();
        }
    }
}
