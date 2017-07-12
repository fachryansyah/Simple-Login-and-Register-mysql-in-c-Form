using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace SimpleAuth
{
    public partial class Form2 : MaterialForm
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=simpleauth");

        public Form2()
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

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (register())
            {
                MessageBox.Show("Regfister berhasil");
            }
            
        }

        private Boolean register(){
            try
            {
                string sql = "INSERT INTO account (id,username,email,status,password) VALUES (Null,'" + txtUsername.Text + "','" + txtEmail.Text + "','" + txtStatus.Text + "','" + txtPassword.Text + "')";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    return true;
                }

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }


            con.Close();
            return false;
        }
    }
}
