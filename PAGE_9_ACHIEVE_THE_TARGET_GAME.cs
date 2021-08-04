using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;


namespace Introduction
{
    public partial class PAGE_9_ACHIEVE_THE_TARGET_GAME : Form
    {
        SoundPlayer music1 = new SoundPlayer(Introduction.Properties.Resources.Action);
        // SoundPlayer SimpleSound1 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Action.wav");
        bool bolInit = false;
        int conOperationsQueueLength = 10;
        int conMaxValue = 100;
        int intScore;
        int intLevel;
        int intValueTarget;
        int intValueCurrent;
        int intLevelDelay;
        string strOperationsQueue;
        string strOperationNext;
        Random rndGenerator;

        public PAGE_9_ACHIEVE_THE_TARGET_GAME()
        {
            InitializeComponent();
            _ = PlayerDetails.FName;
            _ = PlayerDetails.LName;
            _ = PlayerDetails.FScore;
            label4.Text = "Final Score : " + PlayerDetails.FScore;
            label5.Text = "Player : " + PlayerDetails.FName + " " + PlayerDetails.LName;
        }
        private void btnNum1_Click(object sender, EventArgs e) { performOperation((btnNum1.Text == "1") ? 1 : 10); }
        private void btnNum2_Click(object sender, EventArgs e) { performOperation(2); }
        private void btnNum3_Click(object sender, EventArgs e) { performOperation(3); }
        private void btnNum4_Click(object sender, EventArgs e) { performOperation(4); }
        private void btnNum5_Click(object sender, EventArgs e) { performOperation(5); }
        private void btnNum6_Click(object sender, EventArgs e) { performOperation(6); }
        private void btnNum7_Click(object sender, EventArgs e) { performOperation(7); }
        private void btnNum8_Click(object sender, EventArgs e) { performOperation(8); }
        private void btnNum9_Click(object sender, EventArgs e) { performOperation(9); }
        private void btnNum0_Click(object sender, EventArgs e) { performOperation((btnNum0.Text == "0") ? 0 : 10); }
        private void btnSkip_Click(object sender, EventArgs e) { performOperation(-1); }


        private void performOperation(int intValue)
        {
            if (intValue >= 0)
            {
                switch (strOperationNext)
                {
                    case "+":
                        lblLastOperation.Text = intValueCurrent.ToString() + " + " + intValue.ToString() + " = ";
                        intValueCurrent += intValue;
                        break;

                    case "-":
                        lblLastOperation.Text = intValueCurrent.ToString() + " - " + intValue.ToString() + " = ";
                        intValueCurrent -= intValue;
                        break;

                    case "÷":
                        lblLastOperation.Text = intValueCurrent.ToString() + " ÷ " + intValue.ToString() + " = ";
                        intValueCurrent /= intValue;
                        break;

                    case "X":
                        lblLastOperation.Text = intValueCurrent.ToString() + " X " + intValue.ToString() + " = ";
                        intValueCurrent *= intValue;
                        break;

                    case "M":
                        lblLastOperation.Text = intValueCurrent.ToString() + " modulo " + intValue.ToString() + " = ";
                        if (intValue == 0) intValue = 10;
                        intValueCurrent = intValueCurrent % intValue;
                        break;
                }
                lblValueCurrent.Text = intValueCurrent.ToString();
                lblLastOperation.Text += intValueCurrent.ToString();
            }
            else
            {
                lblLastOperation.Text = "Skipped Operation - 5 seconds";
                intLevelDelay -= 5;
            }
            nextOperation();
            testEndLevel();

        }

        private void testEndLevel()
        {
            if (intValueCurrent == intValueTarget) levelCompleted(true);
            else if (intValueCurrent == 0) levelCompleted(false);
        }


        private void levelCompleted(bool bolSuccessfully)
        {
            lblLevelCompleted.Text = lblLastOperation.Text;
            if (bolSuccessfully)
            {
                // multiply by 1 for easy, 2 for normal, or else 3 (difficult)
                intScore += intLevelDelay * ((mnuEasy.Checked) ? 1 : (mnuNormal.Checked) ? 2 : 3);
                lblLevelCompleted.ForeColor = Color.Blue;
                string[] strRemarks = new string[7];

                strRemarks[0] = "woohoo";
                strRemarks[1] = "way to go";
                strRemarks[2] = "good stuff";
                strRemarks[3] = "superb!";
                strRemarks[4] = "excellent";
                strRemarks[5] = "keep it up";
                strRemarks[6] = "that's how its done";

                int intIndex = 0;
                while (intIndex == 0)
                    intIndex = (int)(rndGenerator.NextDouble() * 6);
                lblLevelCompleted.Text += "     " + strRemarks[intIndex];
            }
            else
            {
                intScore -= intValueTarget;
                lblLevelCompleted.ForeColor = Color.Red;
                lblLevelCompleted.Text += "   : You are not allowed to make ZERO.";
            }

            lblScore.Text = "Current Score : " + intScore.ToString();
            lblLevelCompleted.Visible = true;
            tmrEraseEndLevelLabel.Enabled = true;
            initLevel();
        }

        private void newGame()
        {
            lblGameOver.Visible = false;
            rndGenerator = new Random();
            intScore = 0; lblScore.Text = "Current Score : 0";
            intLevel = 0; lblLevel.Text = "Level : 1";
            lblLevelCompleted.Text = "";
            initLevel();
        }

        private int getRndValue()
        { return (int)(rndGenerator.Next(conMaxValue) * ((mnuExpert.Checked) ? 2 : 1)) + 1; }

        private void initLevel()
        {
            tmrLevel.Enabled = true;
            intLevel++; lblLevel.Text = "Level : " + intLevel.ToString();

            // Joy Modified
            if ((lblLevel.Text == "Level : 1") || (lblLevel.Text == "Level : 2")  || (lblLevel.Text == "Level : 3") || (lblLevel.Text == "Level : 4") || (lblLevel.Text == "Level : 5") || (lblLevel.Text == "Level : 6") || (lblLevel.Text == "Level : 7") || (lblLevel.Text == "Level : 8") || (lblLevel.Text == "Level : 9") )
            {
                initOperationsQueue();
                intValueCurrent = getRndValue();
                lblValueCurrent.Text = intValueCurrent.ToString();
                lblLastOperation.Text = "";
            }
            else
            {
                tmrLevel.Enabled = false;
                DialogResult result = MessageBox.Show("YOU MAY PROCEED", "GAME END", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    btnNum0.Enabled = false;
                    btnNum1.Visible = false;
                    btnNum2.Enabled = false;
                    btnNum3.Enabled = false;
                    btnNum4.Enabled = false;
                    btnNum5.Enabled = false;
                    btnNum6.Enabled = false;
                    btnNum7.Enabled = false;
                    btnNum8.Enabled = false;
                    btnNum9.Enabled = false;
                    btnSkip.Enabled = false;
                    lblValueCurrent.Text = "";
                    lblValueTarget.Text = "";
                    lblLastOperation.Text = "";
                    lblGameOver.Visible = true;
                    lblGameOver.Text = "GAME OVER";
                    PlayerDetails.FScore += PlayerDetails.FScore + intScore - PlayerDetails.FScore;
                    label4.Text = "Final Score : " + PlayerDetails.FScore;
                }
            }
             // Joy Modified End

            // we want to make certain that the target value is not a prime number
            do
            {
                intValueTarget = getRndValue();
                int intFactor = 0;
                while (intFactor == 0)
                    intFactor = (int)rndGenerator.Next(10);

                intValueTarget /= intFactor;
                intValueTarget *= intFactor;
            } while (intValueTarget == 0);

            lblValueTarget.Text = "= " + intValueTarget.ToString();
            nextOperation();
            intLevelDelay = 120 - intLevel;
            if (mnuEasy.Checked)
            {
                if (intLevelDelay < 60)
                    intLevelDelay = 60;
            }
            else
            {
                if (intLevelDelay < 30)
                    intLevelDelay = 30;
            }

            lblLastOperation.Visible = true;
            lblLevelCompleted.Visible = true;
            lblOperationNext.Visible = true;
            lblOperationQueue.Visible = true;
            lblScore.Visible = true;
            lblTimeRemaining.Visible = true;
            lblValueCurrent.Visible = true;
            lblValueTarget.Visible = true;

        }

        private void nextOperation()
        {
            strOperationNext = strOperationsQueue.Substring(1, 1);
            lblOperationNext.Text = (strOperationNext == "M") ? "Modulo" : strOperationNext;
            lblOperationNext.Left = pnlNumKeys.Left - lblOperationNext.Width - 10;
            lblValueCurrent.Left = lblOperationNext.Left - lblValueCurrent.Width - 10;
            strOperationsQueue = strOperationsQueue.Substring(1) + getRandomLegalOperation();
            lblOperationQueue.Text = strOperationsQueue;
            setNumericKeyEnables();
        }

        private void setNumericKeyEnables()
        {
            int intCounter;
            // turn 'on' all buttons
            for (intCounter = 0; intCounter < 10; intCounter++)
                setButtonEnabled(intCounter, true);

            // modulo 1 must be refused(disable '1' button if modulo operation)
            btnNum1.Enabled = !("M".Contains(strOperationNext));

            // we neither divide, multiply or modulo with a zero
            // turn the zero to a ten in these cases
            btnNum0.Text = ("÷XM".Contains(strOperationNext)) ? "10" : "0";

            // at expert level : multiplying by 10 is too easy - disable '1' button
            if (mnuExpert.Checked)
            { btnNum1.Enabled = !("÷X".Contains(strOperationNext)); }

            // when subtracting prevent the player from reaching into negative numbers
            // by toggling off buttons that would result in negative values
            if (("-").Contains(strOperationNext))
            {
                if (intValueCurrent < 10)
                {
                    for (intCounter = intValueCurrent; intCounter < 10; intCounter++)
                        setButtonEnabled(intCounter, false);
                }
            }
        }

        private void setButtonEnabled(int intButton, bool bolValue)
        {
            if (((lblLevel.Text == "Level : 1") || (lblLevel.Text == "Level : 2")  || (lblLevel.Text == "Level : 3") || (lblLevel.Text == "Level : 4") || (lblLevel.Text == "Level : 5") || (lblLevel.Text == "Level : 6") || (lblLevel.Text == "Level : 7") || (lblLevel.Text == "Level : 8") || (lblLevel.Text == "Level : 9") ) && (lblLevelCompleted.ForeColor != Color.Red))
            {
                switch (intButton)
                {
                    case 0:
                        btnNum0.Enabled = bolValue;
                        break;
                    case 1:
                        btnNum1.Enabled = bolValue;
                        break;
                    case 2:
                        btnNum2.Enabled = bolValue;
                        break;
                    case 3:
                        btnNum3.Enabled = bolValue;
                        break;
                    case 4:
                        btnNum4.Enabled = bolValue;
                        break;
                    case 5:
                        btnNum5.Enabled = bolValue;
                        break;
                    case 6:
                        btnNum6.Enabled = bolValue;
                        break;
                    case 7:
                        btnNum7.Enabled = bolValue;
                        break;
                    case 8:
                        btnNum8.Enabled = bolValue;
                        break;
                    case 9:
                        btnNum9.Enabled = bolValue;
                        break;
                }
            }
            else
            {
                tmrLevel.Enabled = false;
                btnNum0.Enabled = false;
                btnNum1.Visible = false;
                btnNum2.Enabled = false;
                btnNum3.Enabled = false;
                btnNum4.Enabled = false;
                btnNum5.Enabled = false;
                btnNum6.Enabled = false;
                btnNum7.Enabled = false;
                btnNum8.Enabled = false;
                btnNum9.Enabled = false;
                btnSkip.Enabled = false;
                lblValueCurrent.Text = "";
                lblValueTarget.Text = "";
                lblLastOperation.Text = "";
                lblGameOver.Visible = true;
                lblGameOver.Text = "GAME OVER";
                PlayerDetails.FScore += PlayerDetails.FScore + intScore - PlayerDetails.FScore;
                label4.Text = "Final Score : " + PlayerDetails.FScore;
            }

        }

        private void initOperationsQueue()
        {
            int intCounter;
            strOperationsQueue = "";
            for (intCounter = 0; intCounter < conOperationsQueueLength; intCounter++)
            {
                strOperationsQueue += getRandomLegalOperation();
            }
            lblOperationQueue.Text = strOperationsQueue;
        }

        private string getLegalOperations()
        {
            // depending on game skill level certain operations may or may not be allowed
            string strLocalLegalOperations = "";
            if (btnLegalOperationsAdd.Enabled) { strLocalLegalOperations += "+"; }
            if (btnLegalOperationsSubtract.Enabled) { strLocalLegalOperations += "-"; }
            if (btnLegalOperationsDivide.Enabled) { strLocalLegalOperations += "÷"; }
            if (btnLegalOperationsMultiply.Enabled) { strLocalLegalOperations += "X"; }
            if (btnLegalOperationsModulo.Enabled) { strLocalLegalOperations += "M"; }
            return strLocalLegalOperations;
        }

        private string getRandomLegalOperation()
        {
            string strLegalOperations = getLegalOperations();
            int intRndNum = 0;
            int intLen = strLegalOperations.Length;
            if (!mnuExpert.Checked)
            {   // here we controls the likelihood that certain operations will be randomly selected
                // e.g. addition is ten times as likely to be selected than modulo, multiplication six times as likely
                string strTemp = strLegalOperations;
                strLegalOperations = "";
                int intCounter;
                for (intCounter = 0; intCounter < strTemp.Length; intCounter++)
                {
                    switch (strTemp.Substring(intCounter, 1))
                    {
                        case "+":
                            strLegalOperations += "++++++++++".Substring((int)(rndGenerator.NextDouble() * 6));
                            break;
                        case "-":
                            strLegalOperations += "----------".Substring((int)(rndGenerator.NextDouble() * 6));
                            break;
                        case "÷":
                            strLegalOperations += "÷÷÷÷÷÷".Substring((int)(rndGenerator.NextDouble() * 6));
                            break;
                        case "X":
                            strLegalOperations += "XXXXXX".Substring((int)(rndGenerator.NextDouble() * 6));
                            break;
                        case "M":
                            strLegalOperations += "M";
                            break;
                    }
                }
            }

            intRndNum = (int)(rndGenerator.NextDouble() * strLegalOperations.Length);
            string strRetValue = strLegalOperations.Substring(intRndNum, 1);
            return strRetValue;
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tmrLevel_Tick(object sender, EventArgs e)
        {
            if (!bolInit)
            {
                newGame();
                bolInit = true;
            }
            intLevelDelay -= 1;
            if (intLevelDelay <= 0)
                gameOver();
            displayTimeRemaining();

        }

        private void gameOver()
        {
            lblGameOver.Visible = true;
            lblGameOver.Text = "GAME OVER";
            tmrLevel.Enabled = false;
            lblValueCurrent.Text = "";
            lblValueTarget.Text = "";
            lblLastOperation.Text = "";
            btnNum0.Enabled = false;
            btnNum1.Visible = false;
            btnNum2.Enabled = false;
            btnNum3.Enabled = false;
            btnNum4.Enabled = false;
            btnNum5.Enabled = false;
            btnNum6.Enabled = false;
            btnNum7.Enabled = false;
            btnNum8.Enabled = false;
            btnNum9.Enabled = false;
            btnSkip.Enabled = false;
            PlayerDetails.FScore += PlayerDetails.FScore + intScore - PlayerDetails.FScore;
            label4.Text = "Final Score : " + PlayerDetails.FScore;
        }

        private void displayTimeRemaining()
        {
            if (!bolInit)
            {
                bolInit = true;
                newGame();
            }
            if (intLevelDelay >= 0)
            {
                lblTimeRemaining.Text = intLevelDelay.ToString();
            }
            else
            {
                lblTimeRemaining.Text = "0";
            }

        }

        private void mnuNewGame_Click_1(object sender, EventArgs e)
        {
            newGame();
        }

        private void tmrEraseEndLevelLabel_Tick(object sender, EventArgs e)
        {
            lblLevelCompleted.Visible = false;
            tmrEraseEndLevelLabel.Enabled = false;
        }

        private void mnuEasy_Click(object sender, EventArgs e)
        {
            mnuNormal.Checked = false;
            mnuExpert.Checked = false;
            grbLegalOperations.Visible = true;
            newGame();
            setNumericKeyEnables();
        }

        private void mnuNormal_Click(object sender, EventArgs e)
        {
            mnuEasy.Checked = false;
            mnuExpert.Checked = false;
            grbLegalOperations.Visible = false;
            newGame();
            setNumericKeyEnables();
        }

        private void mnuExpert_Click(object sender, EventArgs e)
        {
            mnuEasy.Checked = false;
            mnuNormal.Checked = false;
            grbLegalOperations.Visible = false;
            newGame();
            setNumericKeyEnables();
        }

        private void btnLegalOperationsAdd_Click(object sender, EventArgs e)
        {
            strOperationNext = "+";
            lblOperationNext.Text = "+";
            lblLastOperation.Text = "Force Operation to + costs 5 second";
            intLevelDelay -= 5;
        }

        private void btnLegalOperationsSubtract_Click(object sender, EventArgs e)
        {
            strOperationNext = "-";
            lblOperationNext.Text = "-";
            lblLastOperation.Text = "Force Operation to - costs 5 second";
            intLevelDelay -= 5;
        }

        private void btnLegalOperationsDivide_Click(object sender, EventArgs e)
        {
            strOperationNext = "÷";
            lblOperationNext.Text = "÷";
            lblLastOperation.Text = "Force Operation to ÷ costs 5 second";
            intLevelDelay -= 5;
        }

        private void btnLegalOperationsMultiply_Click(object sender, EventArgs e)
        {
            strOperationNext = "X";
            lblOperationNext.Text = "X";
            lblLastOperation.Text = "Force Operation to X costs 5 second";
            intLevelDelay -= 5;
        }

        private void btnLegalOperationsModulo_Click(object sender, EventArgs e)
        {
            strOperationNext = "M";
            lblOperationNext.Text = "M";
            lblLastOperation.Text = "Force Operation to Modulo costs 5 second";
            intLevelDelay -= 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblGameOver.Text == "GAME OVER")
            {
                PAGE_11_GUESS_THE_PATTERN_GAME C3 = new PAGE_11_GUESS_THE_PATTERN_GAME();
                C3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Complete To Proceed", "ERROR!!!");
            }
        }

        private void Chapter_2_Load(object sender, EventArgs e)
        {
            label6.Text = "SAMPLE : \n 20 + THE NUMPAD 25\n You have to select 5 to reach 25";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblGameOver.Text == "GAME OVER")
            {
                /*
                PAGE_10_TIPS P10 = new PAGE_10_TIPS();
                P10.Show();
                this.Hide();
                */
                this.Hide();
                music1.Play();
                // SimpleSound1.Play();
                PAGE_10_TIPS P10 = new PAGE_10_TIPS();
                P10.Closed += (s, args) => this.Close();
                P10.Show();
            }
            else
            {
                MessageBox.Show("Complete To Proceed", "ERROR!!!");
            }
        }
    }
}