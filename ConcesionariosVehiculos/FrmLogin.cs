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

namespace ConcesionariosVehiculos
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void validacion() {
            string user = txtUsername.Text;
            string password = txtPassword.Text;
            var x = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = x;
            con.Open();

            string query = "SELECT COUNT(*) FROM Concesionario WHERE Usuario IN(@User) AND Clave IN(@Password)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.Add(new SqlParameter("@User", user));
            cmd.Parameters.Add(new SqlParameter("@Password", password));

            var CompareValue = cmd.ExecuteScalar();

            string compare = CompareValue.ToString();

            con.Close();

            if (compare.Equals("1"))
            {
                MessageBox.Show("Bien, pasó");
            }
            else
            {
                MessageBox.Show("Contraseña/Usuario digitado de forma errónea, o cuenta no existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            validacion();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validacion();
            }
        }
    }
}
