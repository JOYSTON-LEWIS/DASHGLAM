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
    public partial class PAGE_6_TIPS : Form
    {
        SoundPlayer music2 = new SoundPlayer(Introduction.Properties.Resources.Festive);
        // SoundPlayer SimpleSound2 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Festive.wav");
        public PAGE_6_TIPS()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            /*
            PAGE_7_GUESS_THE_WORD_GAME P7 = new PAGE_7_GUESS_THE_WORD_GAME();
            P7.Show();
            this.Hide();
            */
            this.Hide();
            music2.Play();
            // SimpleSound2.Play();
            PAGE_7_GUESS_THE_WORD_GAME P7 = new PAGE_7_GUESS_THE_WORD_GAME();
            P7.Closed += (s, args) => this.Close();
            P7.Show();
        }

        private void PAGE_6_TIPS_Load(object sender, EventArgs e)
        {
            label1.Text = "!*BEFORE WE BEGIN*! \n" +
            "__About Guess the Word Game :- \n" +
            "Remember Doing Hangman games when you were\nyounger? Well Here is such a Game which challenges \nyour vocabulary skills." +
            "  With the little support that \n you get are you that well versed in English to Guess It ? \n" +
            "__Scoring Criteria :- \n" +
            "1 : You have 6 chances to Guess it by clicking any letter in keypad. Once your 6 chances are over or you guess the word correctly, a new word with blank underlines will appear and you can guess for it again. \n2 : " + "You can score 100 points for every time you guess right and win, You can do so for total 5 attempts(win/lose included)\n" +
            "3 : Every time you guess a correct letter for the word it will be added everywhere for the word to be guessed and reclicking it will have no effect. \n4 : Every wrongly guessed letter will appear so that you dont wrongly guess that letter again. \n"
            + "5 : A Hint will be provided to help you guess the word.\n" +
            "GOOD LUCK AND HAVE FUN !!!";

            /*label1.Text = "!*BEFORE WE BEGIN*! \n \n" +
            "__About Guess the Word Game :- \n \n" +
            "Remember Doing Hangman games when you were\nyounger? Well Here is such a Game which challenges \nyour vocabulary skills." +
            "  With the little support that \n you get are you that well versed in English to Guess It ? \n \n" +
            "__Scoring Criteria :- \n \n" +
            "1 : You have 5 chances to Guess it by clicking the check buttton. \n2 : " + "Maximum Points is 500 if you guess in 1st try\n" +
            "3 : Max Points reduce by 100 every time u hit check button. \n4 : If the word is points you have to type Points and hit check \n \n" +
            "GOOD LUCK AND HAVE FUN !!!";
            */
        }
    }
}
