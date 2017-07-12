using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using MaterialSkin;
using MaterialSkin.Controls;
namespace SimpleAuth
{
    public partial class Form1 : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=simpleauth");

        public Form1()
        {
            InitializeComponent();
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
        }

        private Boolean login() 
        {
            String sql = "SELECT * FROM account WHERE username='" + txtUsername.Text + "' AND password='" + txtPassword.Text + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return true;
                con.Close();
            }
            con.Close();

            return false;
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (login())
            {
                MessageBox.Show("Login Berhasil");
            }else{
                MessageBox.Show("Login Gagal");
            }
        }

        
    }
}
