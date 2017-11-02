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

        //Connection String obtenido desde el APP Config.
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        //Método utilizado para validar si los datos ingresados por el usuario son coinciden, en caso de ser positivo, se brinda el acceso esperado.
        private void validacion() {
            //Tomar valores de componentes del formulario y guardarlo en variables.
            string user = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                //Abrir Conexión a base de datos.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                //Se brinda el query al objeto SQL COMMAND para ejecutar el mismo.
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Nombre IN(@User) AND Contrasena IN(@Password)";
                SqlCommand cmd = new SqlCommand(query, con);

                //Se le pasa parámetros al SQL COMMAND.
                cmd.Parameters.Add(new SqlParameter("@User", user));
                cmd.Parameters.Add(new SqlParameter("@Password", password));

                //Tomar el valor retornado de la base de datos.
                var CompareValue = cmd.ExecuteScalar();
                string compare = CompareValue.ToString();

                con.Close();

                //En caso de retornar 1 (que haya pasado los filtros de lugar) brindar acceso al sistema.
                if (compare.Equals("1"))
                {
                    this.Hide();
                    FrmMenu menu = new FrmMenu();
                    menu.ShowDialog();
                }
                else
                {
                    //En caso contrario, informar que la información digitada fue errónea.
                    MessageBox.Show("Contraseña/Usuario digitado de forma errónea, o cuenta no existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception msg) {
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                string eMessage = msg.ToString();
                con.Open();

                string query = "INSERT INTO LOGS VALUES(@logInfo, GETDATE())";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.Add(new SqlParameter("@logInfo", eMessage));
                MessageBox.Show("No se pudo completar solicitud, favor contactar al proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cmd.ExecuteNonQuery();

                con.Close();
            } 
        }

        //El mismo método ejecutado para cuando se le da click al botón acceder, o cuando se presiona enter en el campo contraseña.
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
