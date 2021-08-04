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
    public partial class PAGE_8_TIPS : Form
    {
        SoundPlayer music2 = new SoundPlayer(Introduction.Properties.Resources.Festive);
        // SoundPlayer SimpleSound2 = new SoundPlayer(@"Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\Resources\\Festive.wav");
        public PAGE_8_TIPS()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            /*
            PAGE_9_ACHIEVE_THE_TARGET_GAME P9 = new PAGE_9_ACHIEVE_THE_TARGET_GAME();
            P9.Show();
            this.Hide();
            */
            this.Hide();
            music2.Play();
            // SimpleSound2.Play();
            PAGE_9_ACHIEVE_THE_TARGET_GAME P9 = new PAGE_9_ACHIEVE_THE_TARGET_GAME();
            P9.Closed += (s, args) => this.Close();
            P9.Show();
        }

        private void PAGE_8_TIPS_Load(object sender, EventArgs e)
        {
            label1.Text = "!*BEFORE WE BEGIN*! \n" +
            "__Rules for The Achieve The Target Game (9-10 levels):- \n" +
            "1 : Basic operators are provided '+' for ADD, '-' For Subtract, " + "'*' for PRODUCT, '/' For DIVIDE and 'M' for MODULO\n" +
            "2 : Your goal is to achieve the same value seen on your right side to " + "your left side with help of operators and numpad.\n" +
            "3 : M is Modulo Operator which will divide LHS by the number u select in numpad and the remainder will be left on LHS, so be careful of the modulo operator as it will trick you into making 0.\n" +
            "4 : Penalty for skipping any operation = minus 5 seconds\n" +
            "__Scoring Criteria :- \n" +
            "1 : Scores = Timer remaining time * 2 , Also You Score will be = Current score – target value which you failed to achieve before 'GAME OVER' Screen. \n2 : " + "If you choose to stop solving you can keep skipping the operators till the timer runs to 0. \n" +
            "3 : Negative scores will be reduced from your previous achieved scores. \n4 : Timer will increase on completion of level \n" +
            "GET READY TIMER STARTS AS SOON AS YOU CLICK NEXT!!!";
        }
    }
}
