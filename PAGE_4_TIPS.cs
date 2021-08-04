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
    public partial class PAGE_4_TIPS : Form
    {
        // SoundPlayer SimpleSound2 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Festive.wav");
        SoundPlayer music2 = new SoundPlayer(Introduction.Properties.Resources.Festive);
        public PAGE_4_TIPS()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PAGE_4_TIPS_Load(object sender, EventArgs e)
        {
            label1.Text = "!*BEFORE WE BEGIN*! \n \n" +
                "__About Riddles :- \n \n" +
                "Remember Doing who am I when you were younger? \n Well As You Grow Smarter The Nature of Riddles \n" +
                "grow in Difficulty, Coming up ahead is a riddle \n like such are you that well versed in English to Win ? \n \n" +
                "__Scoring Criteria :- \n \n" +
                "1 : You have one chance to Guess it. \n2 : Answer input by use of keyboard should be all lower case or all uppercase letters \n" +
                "3 : Guessing Right grants u 500 points. \n4 : Guessing Wrong grants u 0 points \n \n" +
                "GOOD LUCK AND HAVE FUN !!!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            PAGE_5_RIDDLE P5 = new PAGE_5_RIDDLE();
            P5.Show();
            this.Hide();
            */

            this.Hide();
            music2.Play();
            // SimpleSound2.Play();
            PAGE_5_RIDDLE P5 = new PAGE_5_RIDDLE();
            P5.Closed += (s, args) => this.Close();
            P5.Show();
        }
    }
}
