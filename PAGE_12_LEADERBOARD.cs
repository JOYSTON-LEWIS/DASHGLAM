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
using System.Data.SqlClient;

namespace Introduction
{
    public partial class PAGE_12_LEADERBOARD : Form
    {
        public PAGE_12_LEADERBOARD()
        {
            InitializeComponent();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            try
            {
                string CommandText = "Select * from LEADERBOARD ORDER BY FScore DESC;";

                SQLiteConnection con = new SQLiteConnection();
                con.ConnectionString =
                "Data Source=DASHGLAM.db" +
                "User Instance=true;" +
                "Integrated Security=true;" +
                "Connect Timeout = 30;";
                // + "AttachDbFilename=Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\bin\\Debug\\DASHGLAM.db";
                    con.Open();
                    SQLiteDataAdapter sqlda = new SQLiteDataAdapter(CommandText, con);
                    using (DataTable ds = new DataTable())
                    {
                        sqlda.Fill(ds);
                        dataGridView1.DataSource = ds;

                    dataGridView1.DataSource = ds; ;
                        this.dataGridView1.AllowUserToAddRows = false;
                        // dataGridView1.DataBind();
                        this.dataGridView1.DataSource = AutoNumberedTable(ds);
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                            dataGridView1.Columns[i].ReadOnly = true;
                        }
                    }
                    con.Close();
            }

            catch

            {

                MessageBox.Show("No Record Found");

            }

        }

        private DataTable AutoNumberedTable(DataTable SourceTable)

        {

            DataTable ResultTable = new DataTable();

            DataColumn AutoNumberColumn = new DataColumn();

            AutoNumberColumn.ColumnName = "RANK";

            dataGridView1.Columns[0].HeaderText = "FIRST NAME";

            dataGridView1.Columns[1].HeaderText = "LAST NAME";

            dataGridView1.Columns[2].HeaderText = "FINAL SCORE";

            AutoNumberColumn.DataType = typeof(int);

            AutoNumberColumn.AutoIncrement = true;

            AutoNumberColumn.AutoIncrementSeed = 1;

            AutoNumberColumn.AutoIncrementStep = 1;

            ResultTable.Columns.Add(AutoNumberColumn);


            ResultTable.Merge(SourceTable);

            return ResultTable;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*
SQLiteCommand cmd = new SQLiteCommand("select Fname,LName,FScore from LEADERBOARD ORDER BY FScore DESC;");
cmd.ExecuteNonQuery();

con.Close();


cmd.CommandType = CommandType.Text;

SqlDataAdapter da = new SqlDataAdapter(cmd);

DataTable ds = new DataTable();
*/
        /*
while (reader.Read())
{
    MessageBox.Show(reader["FName"] + ":" + reader["LName"] + ":" + reader["FScore"] + ":");
}*/

        /*
SqlConnection con = new SqlConnection();//connection name
con.ConnectionString =
"Data Source=XDJJoyPikaXT2X\\SQLEXPRESS01;" +
"User Instance=true;" +
"Integrated Security=true;" +
"Connect Timeout = 30;" +
"AttachDbFilename=Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\DashGlam.mdf;";
con.Open();


using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("Data Source=DASHGLAM.db"))
{
    using (System.Data.SQLite.SQLiteCommand comd = new System.Data.SQLite.SQLiteCommand(con))
    {
        con.Open();
        // cmd.ExecuteNonQuery();
        // cmd.CommandText = "select Fname,LName,FScore from LEADERBOARD ORDER BY FScore DESC;";
        // cmd.ExecuteNonQuery();
    }
}*/

        /*
                    conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=XDJJoyPikaXT2X\\SQLEXPRESS01;" +
            "User Instance=true;" +
            "Integrated Security=true;" +
            "Connect Timeout = 30;" +
            "AttachDbFilename=Z:\\WORK DRIVE\\Studies\\Languages Training\\GAME DEVELOPMENT NOTES\\English Section\\Introduction\\DashGlam.mdf;";
            conn.Open();
            /*
            conn.ConnectionString = @"DataSource=.\SQLEXPRESS;
            AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\knn.mdf;
            IntegratedSecurity=True;Connect Timeout=30;User Instance=True";
            conn.Open();
            */
        // cmd = new SqlCommand("INSERT INTO Customer VALUES(@FName,@LName,@FScore)", conn);
        //cmd = new SqlCommand("insert into LeaderBoard values('" + PlayerDetails.FScore + "','" + PlayerDetails.FName + "','" + PlayerDetails.LName + "')", conn);
        //cmd.ExecuteNonQuery();
        //    conn.Close();

    }
}
