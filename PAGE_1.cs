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

namespace Introduction
{
    public partial class PAGE_1 : Form
    {
        // SoundPlayer SimpleSound = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Corporate.wav");
        SoundPlayer music = new SoundPlayer(Introduction.Properties.Resources.Corporate);
        public PAGE_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((richTextBox1.Text == "") || (richTextBox1.Text == ""))
            {
                MessageBox.Show("Please Enter Your First Name or Last Name", "Error!!!");
            }
            else
            {
                PlayerDetails.FName += richTextBox1.Text;
                PlayerDetails.LName += richTextBox2.Text;
                // SimpleSound.Stop();
                music.Stop();
                this.Hide();
                PAGE_2 P2 = new PAGE_2();
                P2.Closed += (s, args) => this.Close();
                P2.Show();
            }

            /*
            PlayerDetails.HFName += richTextBox1.Text;
            PlayerDetails.TFName += richTextBox1.Text;
            PlayerDetails.PFName += richTextBox1.Text;
            PlayerDetails.HLName += richTextBox2.Text;
            PlayerDetails.TLName += richTextBox2.Text;
            PlayerDetails.PLName += richTextBox2.Text;
            */
            /*PAGE_2 P2 = new PAGE_2();
            P2.Show();
            this.Hide();
            */

        }

        private void PAGE_1_Load(object sender, EventArgs e)
        {
            music.Play();
            // SimpleSound.Play();
        }

        /*
        private void button2_Click(object sender, EventArgs e)
        {
            Introduction I = new Introduction();
            I.Show();
            this.Hide();
        }
        */
    }
}
