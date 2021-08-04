using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introduction
{
    public partial class PAGE_7_GUESS_THE_WORD_GAME_t : Form
    {
        public PAGE_7_GUESS_THE_WORD_GAME_t()
        {
            InitializeComponent();
            label4.Text = "Final Score : " + PlayerDetails.FScore;
            label5.Text = "Player : " + PlayerDetails.FName + " " + PlayerDetails.LName;
        }

        Random random = new Random();
        string[] Word = new string[15]
        {   
          "Inferi",
          "Bureau",
          "Fabric",
          "Fiscal",
          "Former",
          "Intent",
          "Merger",
          "Museum",
          "Oxford",
          "Regime",
          "Survey",
          "Tender",
          "Deputy",
          "Foster",
          "Treaty" 
        };

        // "Inferi" , "Magnanimous", "Factoid", "Lant", "Imperturbable" , "Whippersnapper" , "Immortalize" , "Gobbledygook" , "Gibberish" , "Lollygag" , "Acronym" , "Anthropogenic" , "Benchmarking" , "Cerulean" , "Epiphany"};
        // store the current word being guessed and the current
        // letter index
        private string currentWord;
        private int currentLetter;
        int count = 0;

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game has started");
            btnCheckWord.Enabled = true;
            txtGuessWord.Enabled = true;
            lblstart.Text = "Guess the word!";

            // get the word to use
            this.currentWord = Word[random.Next(Word.Length - 1)];

            // start at position 0
            this.currentLetter = 0;

            char letter = this.currentWord[this.currentLetter];

            lblSecretWord.Text = letter.ToString();
        }

        private void btnCheckWord_Click(object sender, EventArgs e)
        {
            count++;
            label1.Text = "You Tried " + count.ToString() + " Times";
            // check guess against current word
            if (txtGuessWord.Text == currentWord)
            {
                MessageBox.Show("Word is Correct");
                lblSecretWord.Text = currentWord.ToString();
            }
                if ((count < 5) && (txtGuessWord.Text != currentWord))
                {
                // move to next letter position
                    this.currentLetter++;
                // get the letter from the current word
                    char letter = this.currentWord[this.currentLetter];
                // add the next letter to the label

                    lblSecretWord.Text += letter.ToString();
                }
                else
                {
                    lblSecretWord.Text = currentWord.ToString();
                    label1.Text = "You Tried " + count.ToString() + " Times";
                    label3.Text = "SOLVED , PLEASE PROCEED \n BY CLICKING NEXT =>";
                    // Scoring Implement
                    if (count <= 1)
                    {
                        PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
                    }
                    else if (count == 2)
                    {
                        PlayerDetails.FScore += PlayerDetails.FScore + 400 - PlayerDetails.FScore;
                    }
                    else if (count == 3)
                    {
                        PlayerDetails.FScore += PlayerDetails.FScore + 300 - PlayerDetails.FScore;
                    }
                    else if (count == 4)
                    {
                        PlayerDetails.FScore += PlayerDetails.FScore + 200 - PlayerDetails.FScore;
                    }
                    else if (count == 5)
                    {
                        PlayerDetails.FScore += PlayerDetails.FScore + 100 - PlayerDetails.FScore;
                    }
                    else if (count == 6)
                    {
                        PlayerDetails.FScore += PlayerDetails.FScore + 0 - PlayerDetails.FScore;
                    }
                label4.Text = "Final Score : "+ PlayerDetails.FScore;

                    btnStartGame.Enabled = false;
                }

                // TODO: This code needs updated so it knows when there
                // are no more letters left and stop the game
                // DONE BY JOYSTON
            
        }

        private void Chapter_1_Load(object sender, EventArgs e)
        {
            btnCheckWord.Enabled = false;
            txtGuessWord.Enabled = false;
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (label3.Text == "")
            {
                MessageBox.Show("Click on and Clear the Start Button First", "ERROR!!!");
            }
            else
            {
                PAGE_8_TIPS P8 = new PAGE_8_TIPS();
                P8.Show();
                this.Hide();
            }
        }

        private void btnStartGame_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Game has started");
            btnCheckWord.Enabled = true;
            txtGuessWord.Enabled = true;
            lblstart.Text = "Guess the word!";

            // get the word to use
            this.currentWord = Word[random.Next(Word.Length - 1)];

            // start at position 0
            this.currentLetter = 0;

            char letter = this.currentWord[this.currentLetter];

            lblSecretWord.Text = letter.ToString();
        }
    }
}
