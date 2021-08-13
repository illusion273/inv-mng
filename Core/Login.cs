using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app3rework.Core
{
    public partial class Login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static int UserID { get; set; }
        public static string UserName { get; set; }

        private int counter = 0;

        public Login()
        {
            InitializeComponent();
            lbl_2.Parent = pictureBox;
            lbl_2.BackColor = Color.Transparent;
            btn_exit.Parent = pictureBox;
            btn_exit.BackColor = Color.Transparent;
            lbl_3.Parent = pictureBox;
            lbl_3.BackColor = Color.Transparent;
            lbl_4.Parent = pictureBox;
            lbl_4.BackColor = Color.Transparent;

            Timer timer = new Timer();
            timer.Interval = 200;
            timer.Enabled = false;
            timer.Tick += new System.EventHandler(timer_Tick);

            Timer timer2 = new Timer();
            timer2.Interval = 4000;
            timer2.Enabled = false;
            timer2.Tick += new System.EventHandler(timer2_Tick);

            txt_userid.Text = "278";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CheckUser()
        {
            int parseresault;
            bool tryparse;
            if (txt_userid.Text == "")
            {
                lbl_3.Visible = true;
                timer2.Enabled = true;
                timer2.Start();
            }
            else
            {
                tryparse = Int32.TryParse(txt_userid.Text, out parseresault);
                if (tryparse && parseresault >= 274 && parseresault <= 290)
                {
                    UserID = parseresault;
                    string Fname, Mname, Lname;
                    string fullname = $"select FirstName, MiddleName, LastName as FullName from person.Person where BusinessEntityID = {UserID}";
                    SqlConnection conn = new SqlConnection(Classes.SQLConnection.connectionString);
                    SqlCommand command = new SqlCommand(fullname, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Fname = reader.GetValue(0).ToString();
                        Mname = reader.GetValue(1).ToString();
                        Lname = reader.GetValue(2).ToString();
                        UserName = $"{Fname} {Mname} {Lname}";
                    }
                    reader.Close();
                    conn.Close();
                    timer.Enabled = true;
                    timer.Start();
                    pb1.Visible = true;
                }
                else
                {
                    lbl_3.Visible = true;
                    timer2.Enabled = true;
                    timer2.Start();
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckUser();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pb1.Increment(30);
            pb1.Value = pb1.Value - 1;
            if (pb1.Value == pb1.Maximum - 1)
            {
                timer.Stop();
                timer.Enabled = false;
                pb1.Visible = false;
                pb1.Value = 0;
                Main main = new Main();
                main.TopLevel = true;
                main.TopMost = false;
                this.Hide();
                main.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == 8)
            {
                timer2.Stop();
                timer2.Enabled = false;
                lbl_3.Visible = false;
                txt_userid.Text = "";
                counter = 0;
            }
        }
    }
}
