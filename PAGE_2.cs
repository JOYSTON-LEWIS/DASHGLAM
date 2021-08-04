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
    public partial class PAGE_2 : Form
    {
        SoundPlayer music = new SoundPlayer(Introduction.Properties.Resources.Corporate);
        SoundPlayer music1 = new SoundPlayer(Introduction.Properties.Resources.Action);
        // SoundPlayer SimpleSound = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Corporate.wav");
        // SoundPlayer SimpleSound1 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Action.wav");
        public PAGE_2()
        {
            InitializeComponent();
            button3.Visible = false;
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            PAGE_4_TIPS P4 = new PAGE_4_TIPS();
            P4.Show();
            this.Hide();
            */

            this.Hide();
            music1.Play();
            // SimpleSound1.Play();
            PAGE_6_TIPS P6 = new PAGE_6_TIPS();
            P6.Closed += (s, args) => this.Close();
            P6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            PAGE_3 P3 = new PAGE_3();
            P3.Show();
            this.Hide();
            */

            this.Hide();
            PAGE_3 P3 = new PAGE_3();
            P3.Closed += (s, args) => this.Close();
            P3.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PAGE_2_Load(object sender, EventArgs e)
        {
            // label2.Text = "Recommended For Beginners : \n Play any game you want, see how good you are \n Once you're prepared do try to 'PLAY ALL'";
            label3.Text = " 4 Game Challenge, see how good you are \n Compete with your friends and family";
            // SimpleSound.Play();
            music.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            this.Hide();
            PAGE_13_GAME_MENU P13 = new PAGE_13_GAME_MENU();
            P13.Closed += (s, args) => this.Close();
            P13.Show();
            */
        }
    }
}
