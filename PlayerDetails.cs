using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class PlayerDetails
    {
        // All 4 Game's variables
        static string Fname, Lname;
        static double Fscore = 0;
        public static string FName
        {
            get
            {
                return Fname;
            }
            set
            {
                Fname = value;
            }
        }
        public static string LName
        {
            get
            {
                return Lname;
            }
            set
            {
                Lname = value;
            }
        }
        public static double FScore
        {
            get
            {
                return Fscore;
            }
            set
            {
                Fscore = value;
            }
        }

        // Hangman Game variables
        static string HFname, HLname;
        static double HFscore = 0;
        public static string HFName
        {
            get
            {
                return HFname;
            }
            set
            {
                HFname = value;
            }
        }
        public static string HLName
        {
            get
            {
                return HLname;
            }
            set
            {
                HLname = value;
            }
        }
        public static double HFScore
        {
            get
            {
                return HFscore;
            }
            set
            {
                HFscore = value;
            }
        }

        // Achieve Target Variables
        static string TFname, TLname;
        static double TFscore = 0;
        public static string TFName
        {
            get
            {
                return TFname;
            }
            set
            {
                TFname = value;
            }
        }
        public static string TLName
        {
            get
            {
                return TLname;
            }
            set
            {
                TLname = value;
            }
        }
        public static double TFScore
        {
            get
            {
                return TFscore;
            }
            set
            {
                TFscore = value;
            }
        }

        // Pattern Game Variables
        static string PFname, PLname;
        static double PFscore = 0;
        public static string PFName
        {
            get
            {
                return PFname;
            }
            set
            {
                PFname = value;
            }
        }
        public static string PLName
        {
            get
            {
                return PLname;
            }
            set
            {
                PLname = value;
            }
        }
        public static double PFScore
        {
            get
            {
                return PFscore;
            }
            set
            {
                PFscore = value;
            }
        }
    }
}
