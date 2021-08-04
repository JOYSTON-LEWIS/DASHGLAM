# DASHGLAM
2.	DATABASE DUMP FILE
There is no Database implemented for development of the project
However SQLite Database is implemented to Store, Retrieve Data for The Final
Leaderboard
Every Time the application is downloaded and used the database file will be generated in the same directory as the game and the game will run with no errors so we cannot provide a dump f or the database.

3.	SYSTEM MANUAL
a) SYSTEM REQUIREMENTS :-
OS:- Windows 7,8,10
CPU:-Intel Pentium or Higher
RAM:-100 MB minimum
STORAGE:- 50MB to 100MB
Database:-  (USER NEED NOT INSTALL ANY DATABASE)
SQLite used within Visual Studio

column header names for the database
Fname,LName NVARCHAR(20) NOT NULL
FScore INT NOT NULL
FName	LName	FScore
Test	Test	1312

SQL QUERY USED To ENTER DATA BY INPUT FROM FORM:-
            SQLiteConnection.CreateFile("DASHGLAM.db");
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString =
            "Data Source=DASHGLAM.db" +
            "User Instance=true;" +
            "Integrated Security=true;" +
            "Connect Timeout = 30;";
            using (SQLiteCommand cmd = new SQLiteCommand(con))
            {
                con.Open();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS [LEADERBOARD] ([FName] NVARCHAR(20) NOT NULL,[LName] NVARCHAR(20) NOT NULL,[FScore] INT NOT NULL)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Insert into LEADERBOARD values('" + PlayerDetails.FName + "','" + PlayerDetails.LName + "','" + PlayerDetails.FScore + "')";
                cmd.ExecuteNonQuery();

                con.Close();
            }
SQL QUERY USED To DISPLAY DATA IN LEADERBOARD:-
            try
            {
                string CommandText = "Select * from LEADERBOARD ORDER BY FScore DESC;";

                SQLiteConnection con = new SQLiteConnection();
                con.ConnectionString =
                "Data Source=DASHGLAM.db" +
                "User Instance=true;" +
                "Integrated Security=true;" +
                "Connect Timeout = 30;";
                    con.Open();
                    SQLiteDataAdapter sqlda = new SQLiteDataAdapter(CommandText, con);
                    using (DataTable ds = new DataTable())
                    {
                        sqlda.Fill(ds);
                        dataGridView1.DataSource = ds;

                    dataGridView1.DataSource = ds; ;
                        this.dataGridView1.AllowUserToAddRows = false;
                        this.dataGridView1.DataSource = AutoNumberedTable(ds);
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView1.Columns[i].ReadOnly = true;
                        }
                    }
                    con.Close();
            }
b)Steps for “How to Install/deploy game using the source code”
Install Visual Studio 2019 with minimum stuff including C# environment and .NET support
Make Sure all its libraries and functions are up to date
Install SqlLite Library from the NuGet Packet Manager
Build the Solution and Run the Project
c)Dependencies
Images as above
Libraries Used :-
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;



4.	USER MANUAL
a) NAME OF GAME :- DASHGLAM
DESCRIPTION :
DashGlam is a game cum knowledge enhancing technique which is necessary to both apply mind into solving a riddle and increase some sort of interest in gaining some understanding of concepts related to the syllabus. With the aim to learn and have some fun while learning let's get started!!
b) LEARNING OBJECTIVE :- Learning English and Mathematics Through a series of Game Activities that award you Points and publish the Leaderboard.
c) Topic & Level
	1) GUESS THE WORD GAME (5 TRIES)
	2) RIDDLE GAME (1 TRY)
	3) ACHIEVE THE TARGET GAME (9-10 TRIES)
	4) GUESS THE PATTERN GAME (1 TRY)
d) TARGET USERS :- STANDARD VII TO X
e) Pre-requisites:- .NET FRAMEWORK above version 3.0
f) Steps for How to Use the Game:-
1) Download the Zip file of the Game
(My Google Drive Shared File)
https://drive.google.com/file/d/1Z8g4bcuoJZE_cS5zLVLxY_zufKWKvX0J/view?usp=sharing

OR in this reporsitory navigate to bin folder - Release Folder - within these files follow the instructions below.
2) Open the Game Folder and look for Introduction.exe File
3) Double Click on it to Start the Game
4) Play the game until the Leaderboard appears then close the game and run it again
g) Guidelines to Use the Game:-
Same as Above
h) License Informations:-
OPEN SOURCE SOFTWARE
WE HEREBY DECLARE THAT ALL THE INFORMATION , SOURCE CODE , IDEAS ,ETC USED IN THIS PROJECT ARE OUR OWN OR FROM WEB SOURCES WHICH ARE OPEN SOURCE, WE HAVE NOT USED ANY COPYRIGHTED MATERIAL.
