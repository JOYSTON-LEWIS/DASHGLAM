using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Introduction
{
    public partial class PAGE_11_GUESS_THE_PATTERN_GAME : Form
    {
        public PAGE_11_GUESS_THE_PATTERN_GAME()
        {
            InitializeComponent();
            _ = PlayerDetails.FName;
            _ = PlayerDetails.LName;
            _ = PlayerDetails.FScore;
            Next.Enabled = false;
            label4.Text = "Final Score : " + PlayerDetails.FScore;
            label5.Text = "Player : " + PlayerDetails.FName + " " + PlayerDetails.LName;
        }
        Random random = new Random();
        string[] pattern = new string[15] 
        { 
          // functions include basic operators , squaring , modulo  
          "1 + 1 = 2 \n 1 + 2 = 5 \n 1 + 3 = 10 \n 1 + 4 = ?.", // ANSWER IS 17 LOGIC - second number square is added to 1st
          "1 + 1 = 1 \n 2 + 2 = 2 \n 3 + 3 = 3 \n 4 + 4 = ?.",  // ANSWER IS 4 LOGIC - second number is multiplied by 0
          "1 + 5 = 12 \n 2 + 10 = 24 \n 3 + 15 = 36 \n 4 + 20 = ?.", // ANSWER IS 48 LOGIC - LHS numbers are added and multiplied by 2
          "11 - 1 = 5 \n 22 - 2 = 10 \n 33 - 3 = 15 \n 44 - 4 = ?.", // ANSWER IS 20 LOGIC - LHS numbers are subtracted and divided by 2
          "10 - 1 = 10 \n 20 - 2 = 20 \n 30 - 3 = 30 \n 40 - 4 = ?.", // ANSWER IS 40 LOGIC - second number is multiplied by 0
          "100 - 2 = 90 \n 200 - 4 = 160 \n 400 - 8 = 320 \n 800 - 16 = ?.", // ANSWER IS 640 LOGIC - the second number is multiplied by 10 and then subtraction is done
          "1 * 1 = 2 \n 1 * 2 = 3 \n 1 * 3 = 4 \n 1 * 4 = ?.", // ANSWER IS 5 LOGIC - Symbol is * but the numbers are being added instead
          "1 * 2 = 4 \n 2 * 4 = 16 \n 3 * 8 = 48 \n 4 * 16 = ?.", // ANSWER IS 128 LOGIC - After product on LHS multiply it again with 2
          "1 * 1 = 6 \n 1 * 2 = 7 \n 1 * 3 = 8 \n 1 * 4 = ?.", // ANSWER IS 9 LOGIC - After product of LHS add 5 to it
          "1 / 1 = 11 \n 4 / 2 = 22 \n 9 / 3 = 33 \n 16 / 4 = ?.", // ANSWER IS 44 LOGIC - After division add 10 for the first, 20 to the second and so on
          "4 / 2 = 4 \n 8 / 2 = 16 \n 16 / 2 = 64 \n 32 / 2 = ?.", // ANSWER IS 256 LOGIC - After division the result number is squared
          "1 / 1 = 1 \n 8 / 2 = 16 \n 27 / 3 = 81 \n 64 / 4 = ?.", // ANSWER IS 256 LOGIC - After division the result number is squared
          "11 Modulo 1 = 5 \n 27 Modulo 11 = 10 \n 40 Modulo 15 = 15 \n 205 Modulo 20 = ?.", // ANSWER IS 10 LOGIC - After Modulo Remainder is added by 5
          "102 Modulo 100 = 6 \n 204 Modulo 200 = 12 \n 507 Modulo 10 = 21 \n 1011 Modulo 50 = ?.", // ANSWER IS 33 LOGIC - After Modulo Remainder is multiplied by 3
          "58 Modulo 3 = 1 \n 63 Modulo 20 = 9 \n 47 Modulo 15 = 4 \n 74 Modulo 10 = ?." // ANSWER IS 16 LOGIC - After Modulo remainder is squared
        };

        private string currentpattern;

        /* attempts failed
        string[0] = "0";
        pattern[1] = "1";
        pattern[2] = "2";
        pattern[3] = "3";
        pattern[4] = "4";
        pattern[5] = "5";
        pattern[6] = "6";
        pattern[7] = "7";
        pattern[8] = "8";
        pattern[9] = "9";
        pattern[10] = "10";
        pattern[11] = "11";
        pattern[12] = "12";
        pattern[13] = "13";
        pattern[14] = "14";
        pattern[15] = "15";
        
        //{ "Inferi", "Magnanimous", "Factoid", "Lant", "Imperturbable", "Whippersnapper", "Immortalize", "Gobbledygook", "Gibberish", "Lollygag", "Acronym", "Anthropogenic", "Benchmarking", "Cerulean", "Epiphany" };
        // store the current word being guessed and the current
        // letter index

        */

        private void Submit_Click(object sender, EventArgs e)
        {
            // puzzle 1
            if ((richTextBox1.Text == "1 + 1 = 2 \n 1 + 2 = 5 \n 1 + 3 = 10 \n 1 + 4 = ?.") && (textBox1.Text == "17"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 17 \n LOGIC :-\n Second number squared is added to the First Number";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 + 1 = 2 \n 1 + 2 = 5 \n 1 + 3 = 10 \n 1 + 4 = ?.") && (textBox1.Text != "17"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 17 \n LOGIC :-\n Second number squared is added to the First Number";
                Next.Enabled = true;
            }

            // puzzle 2
            if ((richTextBox1.Text == "1 + 1 = 1 \n 2 + 2 = 2 \n 3 + 3 = 3 \n 4 + 4 = ?.") && (textBox1.Text == "4"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 4 \n LOGIC :-\n Second number in Addition is multiplied by 0";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 + 1 = 1 \n 2 + 2 = 2 \n 3 + 3 = 3 \n 4 + 4 = ?.") && (textBox1.Text != "4"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 4 \n LOGIC :-\n Second number in Addition is multiplied by 0";
                Next.Enabled = true;
            }

            // puzzle 3
            if ((richTextBox1.Text == "1 + 5 = 12 \n 2 + 10 = 24 \n 3 + 15 = 36 \n 4 + 20 = ?.") && (textBox1.Text == "48"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 48 \n LOGIC :-\n Addition is carried out, then the result is multiplied by 2";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 + 5 = 12 \n 2 + 10 = 24 \n 3 + 15 = 36 \n 4 + 20 = ?.") && (textBox1.Text != "48"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 48 \n LOGIC :-\n Addition is carried out, then the result is multiplied by 2";
                Next.Enabled = true;
            }

            // puzzle 4
            if ((richTextBox1.Text == "11 - 1 = 5 \n 22 - 2 = 10 \n 33 - 3 = 15 \n 44 - 4 = ?.") && (textBox1.Text == "20"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 20 \n LOGIC :-\n Subtraction is carried out, then the result is divided by 2";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "11 - 1 = 5 \n 22 - 2 = 10 \n 33 - 3 = 15 \n 44 - 4 = ?.") && (textBox1.Text != "20"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 20 \n LOGIC :-\n Subtraction is carried out, then the result is divided by 2";
                Next.Enabled = true;
            }

            // puzzle 5
            if ((richTextBox1.Text == "10 - 1 = 10 \n 20 - 2 = 20 \n 30 - 3 = 30 \n 40 - 4 = ?.") && (textBox1.Text == "40"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 40 \n LOGIC :-\n Second number in Subtraction is multiplied by 0";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "10 - 1 = 10 \n 20 - 2 = 20 \n 30 - 3 = 30 \n 40 - 4 = ?.") && (textBox1.Text != "40"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 40 \n LOGIC :-\n Second number in Subtraction is multiplied by 0";
                Next.Enabled = true;
            }

            // puzzle 6
            if ((richTextBox1.Text == "100 - 2 = 90 \n 200 - 4 = 160 \n 400 - 8 = 320 \n 800 - 16 = ?.") && (textBox1.Text == "640"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 640 \n LOGIC :-\n Second number in Subtraction is multiplied by 10,\n then basic Subtraction is carried out";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "100 - 2 = 90 \n 200 - 4 = 160 \n 400 - 8 = 320 \n 800 - 16 = ?.") && (textBox1.Text != "640"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 640 \n LOGIC :-\n Second number in Subtraction is multiplied by 10,\n then basic Subtraction is carried out";
                Next.Enabled = true;
            }

            // puzzle 7
            if ((richTextBox1.Text == "1 * 1 = 2 \n 1 * 2 = 3 \n 1 * 3 = 4 \n 1 * 4 = ?.") && (textBox1.Text == "5"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 5 \n LOGIC :-\n Operator is * but the numbers are being added instead";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 * 1 = 2 \n 1 * 2 = 3 \n 1 * 3 = 4 \n 1 * 4 = ?.") && (textBox1.Text != "5"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 5 \n LOGIC :-\n Operator is * but the numbers are being added instead";
                Next.Enabled = true;
            }

            // puzzle 8
            if ((richTextBox1.Text == "1 * 2 = 4 \n 2 * 4 = 16 \n 3 * 8 = 48 \n 4 * 16 = ?.") && (textBox1.Text == "128"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 128 \n LOGIC :-\n After Product is obtained on left hand side,\n multiply the result again with 2";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 * 2 = 4 \n 2 * 4 = 16 \n 3 * 8 = 48 \n 4 * 16 = ?.") && (textBox1.Text != "128"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 128 \n LOGIC :-\n After Product is obtained on left hand side,\n multiply the result again with 2";
                Next.Enabled = true;
            }

            // puzzle 9
            if ((richTextBox1.Text == "1 * 1 = 6 \n 1 * 2 = 7 \n 1 * 3 = 8 \n 1 * 4 = ?.") && (textBox1.Text == "9"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 9 \n LOGIC :-\n After Product is obtained on left hand side, add 5 to it";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 * 1 = 6 \n 1 * 2 = 7 \n 1 * 3 = 8 \n 1 * 4 = ?.") && (textBox1.Text != "9"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 9 \n LOGIC :-\n After Product is obtained on left hand side, add 5 to it";
                Next.Enabled = true;
            }

            // puzzle 10
            if ((richTextBox1.Text == "1 / 1 = 11 \n 4 / 2 = 22 \n 9 / 3 = 33 \n 16 / 4 = ?.") && (textBox1.Text == "44"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 44 \n LOGIC :-\n After carrying put Division add 10 to the first equation,\n 20 to the second equation and so on";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 / 1 = 11 \n 4 / 2 = 22 \n 9 / 3 = 33 \n 16 / 4 = ?.") && (textBox1.Text != "44"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 44 \n LOGIC :-\n After carrying put Division add 10 to the first equation,\n 20 to the second equation and so on";
                Next.Enabled = true;
            }

            // puzzle 11
            if ((richTextBox1.Text == "4 / 2 = 4 \n 8 / 2 = 16 \n 16 / 2 = 64 \n 32 / 2 = ?.") && (textBox1.Text == "256"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 256 \n LOGIC :-\n After carrying out Division the result number is squared";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "4 / 2 = 4 \n 8 / 2 = 16 \n 16 / 2 = 64 \n 32 / 2 = ?.") && (textBox1.Text != "256"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 256 \n LOGIC :-\n After carrying out Division the result number is squared";
                Next.Enabled = true;
            }

            // puzzle 12
            if ((richTextBox1.Text == "1 / 1 = 1 \n 8 / 2 = 16 \n 27 / 3 = 81 \n 64 / 4 = ?.") && (textBox1.Text == "256"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 256 \n LOGIC :-\n After carrying out Division the result number is squared";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "1 / 1 = 1 \n 8 / 2 = 16 \n 27 / 3 = 81 \n 64 / 4 = ?.") && (textBox1.Text != "256"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 256 \n LOGIC :-\n After carrying out Division the result number is squared";
                Next.Enabled = true;
            }

            // puzzle 13
            if ((richTextBox1.Text == "11 Modulo 1 = 5 \n 27 Modulo 11 = 10 \n 40 Modulo 15 = 15 \n 205 Modulo 20 = ?.") && (textBox1.Text == "10"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 10 \n LOGIC :-\n After Modulo, the Remainder is added by 5";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "11 Modulo 1 = 5 \n 27 Modulo 11 = 10 \n 40 Modulo 15 = 15 \n 205 Modulo 20 = ?.") && (textBox1.Text != "10"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 10 \n LOGIC :-\n After Modulo, the Remainder is added by 5";
                Next.Enabled = true;
            }

            // puzzle 14
            if ((richTextBox1.Text == "102 Modulo 100 = 6 \n 204 Modulo 200 = 12 \n 507 Modulo 10 = 21 \n 1011 Modulo 50 = ?.") && (textBox1.Text == "33"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 33 \n LOGIC :-\n After Modulo, the Remainder is multiplied by 3";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "102 Modulo 100 = 6 \n 204 Modulo 200 = 12 \n 507 Modulo 10 = 21 \n 1011 Modulo 50 = ?.") && (textBox1.Text != "33"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 33 \n LOGIC :-\n After Modulo, the Remainder is multiplied by 3";
                Next.Enabled = true;
            }

            // puzzle 15
            if ((richTextBox1.Text == "58 Modulo 3 = 1 \n 63 Modulo 20 = 9 \n 47 Modulo 15 = 4 \n 74 Modulo 10 = ?.") && (textBox1.Text == "16"))
            {
                MessageBox.Show("YOU FIGURED IT OUT!", "CONGRATULATIONS!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 16 \n LOGIC :-\n After Modulo, the Remainder is squared";
                Next.Enabled = true;
                PlayerDetails.FScore += PlayerDetails.FScore + 500 - PlayerDetails.FScore;
            }
            else if ((richTextBox1.Text == "58 Modulo 3 = 1 \n 63 Modulo 20 = 9 \n 47 Modulo 15 = 4 \n 74 Modulo 10 = ?.") && (textBox1.Text != "16"))
            {
                MessageBox.Show("YOU ARE UNSUCESSFUL!", "OH NO!!!");
                Start.Enabled = false;
                label2.Text = "ANSWER : 16 \n LOGIC :-\n After Modulo, the Remainder is squared";
                Next.Enabled = true;
            }

            label4.Text = "Final Score : " + PlayerDetails.FScore;

            /*
             string createQuery = @"CREATE TABLE IF NOT EXISTS [LEADERBOARD]([FName] NVARCHAR(20) NULL,[LName] NVARCHAR(20) NULL),[FScore] INT NULL)";
             System.Data.SQLite.SQLiteConnection.CreateFile("DASHGLAM.db");
             using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("Data Source=DASHGLAM.db"))
             {
                 using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(con))
                 {
                     con.Open();
                     cmd.CommandText = createQuery;
                     // cmd.ExecuteNonQuery();
                     cmd.CommandText = "insert into LEADERBOARD values('" + PlayerDetails.FScore + "','" + PlayerDetails.FName + "','" + PlayerDetails.LName + "'";
                     // cmd.ExecuteNonQuery();
                     con.Close();
                 }
             }
            
            string createQuery = @"CREATE TABLE IF NOT EXISTS [LEADERBOARD]([FName] NVARCHAR(20) NULL,[LName] NVARCHAR(20) NULL),[FScore] INT NULL)";
            */

            SQLiteConnection.CreateFile("DASHGLAM.db");
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString =
            "Data Source=DASHGLAM.db" +
            "User Instance=true;" +
            "Integrated Security=true;" +
            "Connect Timeout = 30;";
            //+ "AttachDbFilename=Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\bin\\Debug\\DASHGLAM.db";
            using (SQLiteCommand cmd = new SQLiteCommand(con))
            {
                con.Open();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS [LEADERBOARD] ([FName] NVARCHAR(20) NOT NULL,[LName] NVARCHAR(20) NOT NULL,[FScore] INT NOT NULL)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Insert into LEADERBOARD values('" + PlayerDetails.FName + "','" + PlayerDetails.LName + "','" + PlayerDetails.FScore + "')";
                cmd.ExecuteNonQuery();

                /*
                cmd.CommandText = "SELECT * FROM LEADERBOARD";
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MessageBox.Show(reader["FName"]+":"+ reader["LName"] + ":"+ reader["FScore"] + ":");
                    }
                }
                */
                con.Close();
            }

            /*
        conn = new SqlConnection();
        conn.ConnectionString =
        "Data Source=XDJJoyPikaXT2X\\SQLEXPRESS01;" +
        "User Instance=true;" +
        "Integrated Security=true;" +
        "Connect Timeout = 30;" +
        "AttachDbFilename=Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\DashGlam.mdf;";
        conn.Open();


        // conn.ConnectionString = @"DataSource=.\SQLEXPRESS;
        // AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\knn.mdf;
        // IntegratedSecurity=True;Connect Timeout=30;User Instance=True";
        // conn.Open();  
        // cmd = new SqlCommand("INSERT INTO Customer VALUES(@FName,@LName,@FScore)", conn);

        cmd = new SqlCommand("insert into LeaderBoard values('" + PlayerDetails.FScore + "','" + PlayerDetails.FName + "','" + PlayerDetails.LName + "')", conn);
        cmd.ExecuteNonQuery();
        conn.Close();
            */


        }

        private void Chapter_3_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Start_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            MessageBox.Show("Game has started");
            /* unnecessary
            btnCheckWord.Enabled = true;
            txtGuessWord.Enabled = true;
            lblstart.Text = "Guess the word!";*/

            // get the word to use
            this.currentpattern = pattern[random.Next(pattern.Length - 1)];

            /* codes from above where array declared
            private int currentLetter;
            int count = 0;
            */

            // unnecessary
            // start at position 0
            // this.currentLetter = 0;

            string str = this.currentpattern;

            richTextBox1.Text = str.ToString();
            Start.Enabled = false;
        }

        private void Next_Click_1(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                /*
                PAGE_12_LEADERBOARD P12 = new PAGE_12_LEADERBOARD();
                P12.Show();
                this.Hide();
                */
                PAGE_12_LEADERBOARD P12 = new PAGE_12_LEADERBOARD();
                P12.Closed += (s, args) => this.Close();
                P12.Show();
            }
        }
    }
}
