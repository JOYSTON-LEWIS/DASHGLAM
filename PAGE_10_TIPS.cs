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
    public partial class PAGE_10_TIPS : Form
    {
        SoundPlayer music2 = new SoundPlayer(Introduction.Properties.Resources.Festive);
        // SoundPlayer SimpleSound2 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Festive.wav");
        public PAGE_10_TIPS()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            /*
            PAGE_11_GUESS_THE_PATTERN_GAME P11 = new PAGE_11_GUESS_THE_PATTERN_GAME();
            P11.Show();
            this.Hide();
            */
            this.Hide();
            music2.Play();
            // SimpleSound2.Play();
            PAGE_11_GUESS_THE_PATTERN_GAME P11 = new PAGE_11_GUESS_THE_PATTERN_GAME();
            P11.Closed += (s, args) => this.Close();
            P11.Show();
        }

        private void PAGE_10_TIPS_Load(object sender, EventArgs e)
        {
            label1.Text = "!*BEFORE WE BEGIN*! \n \n" +
            "__About Guess the Pattern Game :- \n \n" +
            "Remember Doing Some operator based games in newspapers? Well Here is such a Game which challenges your mapping skills.\n \n" +
            "__Scoring Criteria :- \n \n" +
            "1 : You have one chance to figure the '?' value based on the aboove patterns. \n2 : Guess and Input Answer by use of keyboard, input should be upto 3 digit numbers. \n" +
            "3 : Guessing Right grants u 500 points. \n4 : Guessing Wrong grants u 0 points. \n \n" +
            "GOOD LUCK AND HAVE FUN !!!";
        }
    }
}
