using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app3rework.Classes
{
    class SQLConnection
    {
        public const string connectionString = @"Server=MAIN\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True";
        public static void ReadDataFillGrid(string query, DataGridView dataGridView)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable dtbl1 = new DataTable();
            conn.Open();
            adapter.Fill(dtbl1);
            conn.Close();
            dataGridView.DataSource = dtbl1;
        }
    }
}
