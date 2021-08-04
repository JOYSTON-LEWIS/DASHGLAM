using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Introduction
{
    public partial class PAGE_5_RIDDLE : Form
    {
        SoundPlayer music1 = new SoundPlayer(Introduction.Properties.Resources.Action);
        // SoundPlayer SimpleSound1 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Action.wav");
        int count = 0;
        string text1 = "YOU THINK YOUR ENGLISH IS EXCELLENT, HEHE WELL THEN GOOD LUCK WITH THIS RIDDLE :\n (HINT : IT IS A 6 LETTER WORD, NAUGHT IS OLD ENGLISH AND STANDS FOR 'NOTHING') \n 1 : FIRST THINK OF A PERSON IN DISGUISE WHO TELLS NAUGHT BUT LIES. \n 2 : THEN THINK OF A SOUND THAT IS HEARD IN THE SEARCH TO FIND A HARD TO FIND WORD. \n 3 : AND LASTLY THINK OF THIS WHICH CREATURE ON EARTH WOULD SCARE YOU BEYOND YOUR WITS.";
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public PAGE_5_RIDDLE()
        {
            InitializeComponent();
            _ = PlayerDetails.FName;
            _ = PlayerDetails.LName;
            _ = PlayerDetails.FScore;
            label4.Text = "Final Score : " + PlayerDetails.FScore;
            label5.Text = "Player : " + PlayerDetails.FName + " " + PlayerDetails.LName;
        }

        private void SetTimer(int milliseconds)
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 40;
            timer1.Start();
        }
        private void timer1_Tick(Object o, EventArgs e)
        {
            if (count < text1.Length)
            {
                richTextBox1.Text += text1[count];
                count++;
            }
            else
            {
                timer1.Stop();
                START.Enabled = true;
                richTextBox1.ReadOnly = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            START.Enabled = false;
            richTextBox1.ReadOnly = true;
            SetTimer(500);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "spider") || (textBox1.Text == "Spider") || (textBox1.Text == "SPIDER"))
            {
                MessageBox.Show("You Guessed it Right!!!", "CONGRATULATIONS");
                label2.Text = "Heres How You Get it \n 1 : refers to spy \n 2 : refers to err \n 3 : well its difficult to guess so put 1 : & 2 : together spy...err. ";
                // Scoring Implement
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
                label4.Text = "Final Score : " + PlayerDetails.FScore;
            }
            else
            {
                MessageBox.Show("You Got It Wrong!!!", "OH NO!!!");
                label2.Text = "Here Allow Me To Explain \n 1: refers to spy \n 2: refers to err \n 3: well its difficult to guess so put 1 : & 2 : together spy...err. \n Still don't get it? The Answer is 'SPIDER'";
                // Scoring Implement
                label4.Text = "Final Score : " + PlayerDetails.FScore;
            }
            START.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "" && textBox1.Text != "")
            {
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text == ".")
            {
                MessageBox.Show("Click on and Clear the Start Button First", "ERROR!!!");
            }
            else
            {
                PAGE_7_GUESS_THE_WORD_GAME C1 = new PAGE_7_GUESS_THE_WORD_GAME();
                C1.Show();
                this.Hide();
            }
        }

        private void Introduction_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void START_Click(object sender, EventArgs e)
        {
            START.Enabled = false;
            richTextBox1.ReadOnly = true;
            SetTimer(500);
        }

        private void NEXT_Click(object sender, EventArgs e)
        {
            if (label2.Text == "")
            {
                MessageBox.Show("Click on and Clear the Start Button First", "ERROR!!!");
            }
            else
            {
                /*
                PAGE_6_TIPS P6 = new PAGE_6_TIPS();
                P6.Show();
                this.Hide();
                */
                this.Hide();
                music1.Play();
                // SimpleSound1.Play();
                PAGE_8_TIPS P8 = new PAGE_8_TIPS();
                P8.Closed += (s, args) => this.Close();
                P8.Show();
            }
        }
    }
}

        /*
        void show()
        {
            System.Threading.Thread.Sleep(3000);
            MessageBox.Show("My name is Joyston. I Love to Game.");
        }
        */

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(show));
            thread.IsBackground = true;
            thread.Start();
            
        }
        */

        //WELCOME! WELCOME! TO ONE OF THE MOST IMPORTANT PART OF ACADEMICS - LANGUAGE OFCOURSELET ME ASK YOU ONE THING YOU MAY KNOW TO CREATE THE BEST ART IN THE WORLDOR CREATE THE WORLD'S BEST POETRY OR PLAY ANY KIND OF SPORTS
