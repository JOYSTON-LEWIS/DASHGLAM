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
    public delegate void CheckLeter(string letter);
    public partial class PAGE_7_GUESS_THE_WORD_GAME : Form
    {
        SoundPlayer music1 = new SoundPlayer(Introduction.Properties.Resources.Action);
        // SoundPlayer SimpleSound1 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Action.wav");

        const int MAX_NUMBER_OF_CHANCE = 5;
        //An event that is invoked everytime when any letter is guessed
        event CheckLeter ChkLtr;

        string input;
        string missedLetters = "";

        //A word which is to find
        string wordToFind = "";

        //Current status of the found letters in the word
        string wordToDisplay = "";

        //Character array of word
        char[] wordToFindArray;
        int[] wordToFindLettersPosition;
        bool IsLetterFound = false;

        //Random number generator class to get word randomly from the word list
        Random rndm = new Random(0);

        //Collection of word
        List<string> wordList = new List<string>();

        // A list of index positions to keep track which word is already played
        List<int> wordsIndexAlreadyPlayed = new List<int>();

        int missedLetterCount = 0;


        // Joys stuff
        int count = 0;
        int won = 0;
        int lost = 0;
        public PAGE_7_GUESS_THE_WORD_GAME()
        {
            InitializeComponent();
            _ = PlayerDetails.FName;
            _ = PlayerDetails.LName;
            _ = PlayerDetails.FScore;
            button3.Enabled = false;
            label4.Text = "Final Score : " + PlayerDetails.FScore;
            label5.Text = "Player : " + PlayerDetails.FName + " " + PlayerDetails.LName;

            //Subscribe the event
            this.ChkLtr += new CheckLeter(Form2_ChkLtr);

            //Create a word list
            CreateWordList();

            // Start a new game
            RestartTheGame();
        }

        //Event handler
        private void Form2_ChkLtr(string currentInputletter)
        {
            try
            {
                if (missedLetterCount < MAX_NUMBER_OF_CHANCE)
                {

                    IsLetterFound = false;
                    for (int i = 0; i < wordToFindArray.Length; i++)
                    {
                        if (currentInputletter[0] == wordToFindArray[i])
                        {
                            wordToFindLettersPosition[i] = 1;
                            IsLetterFound = true;
                        }
                    }

                    if (IsLetterFound == false)
                    {
                        missedLetters += currentInputletter + ", ";
                        missedLetterCount++;
                        label_MissedLtrCnt.Text = (MAX_NUMBER_OF_CHANCE - missedLetterCount).ToString();
                    }

                    wordToDisplay = "";
                    for (int i = 0; i < wordToFindArray.Length; i++)
                    {
                        if (wordToFindLettersPosition[i] == 1)
                        {
                            wordToDisplay += wordToFindArray[i].ToString();
                        }
                        else
                        {
                            wordToDisplay += "-";
                        }
                    }

                    label_Word.Text = wordToDisplay.ToUpper();
                    label_MissedLetters.Text = missedLetters;

                    if (wordToFindLettersPosition.All(e => e == 1))
                    {
                        MessageBox.Show("CONGRATS! YOU GOT THE WORD.", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        won = won + 1;
                        MessageBox.Show("You have won " + won + " times", "RESULT");
                        RestartTheGame();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, you lost the game" + "\nThe correct word was: " + wordToFind, "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lost = lost + 1;
                    MessageBox.Show("You have lost " + lost + " times" , "RESULT");
                    RestartTheGame();
                }
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void CreateWordList()
        {
            // A hardcoded word list with 15 words
            wordList.Add("Location");
            wordList.Add("Invocation");
            wordList.Add("Education");
            wordList.Add("Country");
            wordList.Add("National");
            wordList.Add("Computer");
            wordList.Add("Calculator");
            wordList.Add("Transmission");
            wordList.Add("Continental");
            wordList.Add("Fashionable");
            wordList.Add("Operation");
            wordList.Add("Seasonal");
            wordList.Add("Tomorrow");
            wordList.Add("Yesterday");
            wordList.Add("Perfume");
        }

        private string GetNewWordFromPool()
        {
            bool IsNewWord = false;
            //Default word
            string temp = "HANGMAN";

            try
            {
                while (IsNewWord == false)
                {
                    //-------------To get word randomly from words pool ------------
                    int index = rndm.Next();

                    //To plot the number in our WordList range
                    index = index % wordList.Count;

                    //----------- But Not taking repeated word --------------------

                    //Here I used lambda expression to check whether word is already played or not
                    if (!wordsIndexAlreadyPlayed.Exists(e => e == index))
                    {
                        temp = wordList[index];
                        wordsIndexAlreadyPlayed.Add(index);
                        IsNewWord = true;
                        break;
                    }
                    else
                    {
                        IsNewWord = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return temp.ToUpper();
        }

        private void RestartTheGame()
        {
            count++;
            if (count < 6)
            {
                try
                {
                    wordToFind = GetNewWordFromPool();
                    wordToFind = wordToFind.ToUpper();
                    wordToFindArray = wordToFind.ToCharArray();

                    wordToFindLettersPosition = new int[wordToFind.Length];

                    //Resetting other counters and variables
                    input = "";
                    wordToDisplay = "";
                    for (int i = 0; i < wordToFind.Length; i++)
                    {
                        wordToDisplay += "-";
                    }

                    missedLetters = "";
                    missedLetterCount = 0;

                    label_Word.Text = wordToDisplay.ToUpper();
                    label_MissedLetters.Text = missedLetters;
                    label_MissedLtrCnt.Text = MAX_NUMBER_OF_CHANCE.ToString();
                    Application.DoEvents();

                    // joys stuff
                    if (wordToFind == "LOCATION")
                    {
                        label6.Text = "HINT : A position or site or a place marked by some distinguishing feature.";
                    }
                    else if (wordToFind == "INVOCATION")
                    {
                        label6.Text = "HINT : The act or process of petitioning for help or support.";
                    }
                    else if (wordToFind == "EDUCATION")
                    {
                        label6.Text = "HINT : Process of facilitating learning, or the acquisition of knowledge, skills.";
                    }
                    else if (wordToFind == "COUNTRY")
                    {
                        label6.Text = "HINT : An area of land with particular physical features.";
                    }
                    else if (wordToFind == "NATIONAL")
                    {
                        label6.Text = "HINT : Belonging to the whole country.";
                    }
                    else if (wordToFind == "COMPUTER")
                    {
                        label6.Text = "HINT : Machine to program arithmetic or logical operators.";
                    }
                    else if (wordToFind == "CALCULATOR")
                    {
                        label6.Text = "HINT : Your buddy for mathematics.";
                    }
                    else if (wordToFind == "TRANSMISSION")
                    {
                        label6.Text = "HINT : An act, process, or instance of transfereing something.";
                    }
                    else if (wordToFind == "CONTINENTAL")
                    {
                        label6.Text = "HINT : Related to one of several large landmasses.";
                    }
                    else if (wordToFind == "FASHIONABLE")
                    {
                        label6.Text = "HINT : Related to one's beautiful attire";
                    }
                    else if (wordToFind == "OPERATION")
                    {
                        label6.Text = "HINT : Performance of practical application of principles or processes";
                    }
                    else if (wordToFind == "SEASONAL")
                    {
                        label6.Text = "HINT : Related to change in climate";
                    }
                    else if (wordToFind == "TOMORROW")
                    {
                        label6.Text = "HINT : The Day after Today";
                    }
                    else if (wordToFind == "YESTERDAY")
                    {
                        label6.Text = "HINT : The Day Before Today";
                    }
                    else if (wordToFind == "PERFUME")
                    {
                        label6.Text = "HINT : A Sweet Appealing Fragrance";
                    }
                    else
                    {
                        label6.Text = "";
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            else
            {
                MessageBox.Show("Done 5 attempts for this game, Click Next to Proceed");
                button_A.Enabled = false;
                button_B.Enabled = false;
                button_C.Enabled = false;
                button_D.Enabled = false;
                button_E.Enabled = false;
                button_F.Enabled = false;
                button_G.Enabled = false;
                button_H.Enabled = false;
                button_I.Enabled = false;
                button_J.Enabled = false;
                button_K.Enabled = false;
                button_L.Enabled = false;
                button_M.Enabled = false;
                button_N.Enabled = false;
                button_O.Enabled = false;
                button_P.Enabled = false;
                button_Q.Enabled = false;
                button_R.Enabled = false;
                button_S.Enabled = false;
                button_T.Enabled = false;
                button_U.Enabled = false;
                button_V.Enabled = false;
                button_W.Enabled = false;
                button_X.Enabled = false;
                button_Y.Enabled = false;
                button_Z.Enabled = false;
                button3.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 100*won;
                label4.Text = "Final Score : " + PlayerDetails.FScore;
            }

        }

        #region Getting Alphabets
        private void button_A_Click(object sender, EventArgs e)
        {
            input = "A";

            ChkLtr(input);
        }

        private void button_B_Click(object sender, EventArgs e)
        {
            input = "B";

            ChkLtr(input);
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            input = "C";

            ChkLtr(input);
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            input = "D";

            ChkLtr(input);
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            input = "E";

            ChkLtr(input);
        }

        private void button_F_Click(object sender, EventArgs e)
        {
            input = "F";

            ChkLtr(input);
        }

        private void button_G_Click(object sender, EventArgs e)
        {
            input = "G";

            ChkLtr(input);
        }

        private void button_H_Click(object sender, EventArgs e)
        {
            input = "H";

            ChkLtr(input);
        }

        private void button_I_Click(object sender, EventArgs e)
        {
            input = "I";

            ChkLtr(input);
        }

        private void button_J_Click(object sender, EventArgs e)
        {
            input = "J";

            ChkLtr(input);
        }

        private void button_K_Click(object sender, EventArgs e)
        {
            input = "K";

            ChkLtr(input);
        }

        private void button_L_Click(object sender, EventArgs e)
        {
            input = "L";

            ChkLtr(input);
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            input = "M";

            ChkLtr(input);
        }

        private void button_N_Click(object sender, EventArgs e)
        {
            input = "N";

            ChkLtr(input);
        }

        private void button_O_Click(object sender, EventArgs e)
        {
            input = "O";

            ChkLtr(input);
        }

        private void button_P_Click(object sender, EventArgs e)
        {
            input = "P";

            ChkLtr(input);
        }

        private void button_Q_Click(object sender, EventArgs e)
        {
            input = "Q";

            ChkLtr(input);
        }

        private void button_R_Click(object sender, EventArgs e)
        {
            input = "R";

            ChkLtr(input);
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            input = "S";

            ChkLtr(input);
        }

        private void button_T_Click(object sender, EventArgs e)
        {
            input = "T";

            ChkLtr(input);
        }

        private void button_U_Click(object sender, EventArgs e)
        {
            input = "U";

            ChkLtr(input);
        }

        private void button_V_Click(object sender, EventArgs e)
        {
            input = "V";

            ChkLtr(input);
        }

        private void button_W_Click(object sender, EventArgs e)
        {
            input = "W";

            ChkLtr(input);
        }

        private void button_X_Click(object sender, EventArgs e)
        {
            input = "X";

            ChkLtr(input);
        }

        private void button_Y_Click(object sender, EventArgs e)
        {
            input = "Y";

            ChkLtr(input);
        }

        private void button_Z_Click(object sender, EventArgs e)
        {
            input = "Z";

            ChkLtr(input);
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            /*
                PAGE_8_TIPS P8 = new PAGE_8_TIPS();
                P8.Show();
                this.Hide();
            */
            this.Hide();
            music1.Play();
            // SimpleSound1.Play();
            PAGE_4_TIPS P4 = new PAGE_4_TIPS();
            P4.Closed += (s, args) => this.Close();
            P4.Show();
        }
    }
}
