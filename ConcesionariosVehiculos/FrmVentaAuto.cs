using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcesionariosVehiculos
{
    public partial class FrmVentaAuto : Form
    {
        public FrmVentaAuto()
        {
            InitializeComponent();
        }

        //Cadena de conexión a Base de Datos, obtenida desde el App.config.
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        //Método desarrollado para llenar comboboxes al cargar el formulario (llamando otros métodos).
        private void FrmVentaAuto_Load(object sender, EventArgs e)
        {
            FillVendedores();
            FillChasis();
        }

        //Método utilizado para llenar el combobox de vendedores.
        private void FillVendedores()
        {
            try
            {
                //Borrar items del combobox para evitar datos duplicados en caso de actualización.
                cbxVendedores.Items.Clear();

                //Conexión, y ejecución de sentencia SQL para buscar datos de la base de datos.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Nombres FROM Vendedores";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                //Llenado de Items al combobox.
                while (reader.Read())
                {
                    cbxVendedores.Items.Add(reader["Nombres"].ToString());
                }
                con.Close();
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                string eMessage = msg.ToString();
                con.Open();

                string query = "INSERT INTO LOGS VALUES(@logInfo, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@logInfo", eMessage));
                MessageBox.Show("No se pudo completar solicitud, favor contactar al proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Método desarrollado para llenar el combobox de chasis de vehículos.
        private void FillChasis()
        {
            try
            {
                //Limpiar el combobox para evitar datos duplicados en momento de actualizar el combobox.
                cbxChasis.Items.Clear();

                //Conexión, y ejecución de sentencia SQL para buscar datos de la base de datos.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Chasis FROM vw_CarNotSold";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                //Llenado de Items al combobox.
                while (reader.Read())
                {
                    cbxChasis.Items.Add(reader["Chasis"].ToString());
                }
                con.Close();
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                string eMessage = msg.ToString();
                con.Open();

                string query = "INSERT INTO LOGS VALUES(@logInfo, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@logInfo", eMessage));
                MessageBox.Show("No se pudo completar solicitud, favor contactar al proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Método para buscar el precio calculado de un vehículo al ser seleccionado.
        private void cbxChasis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT [Precio Calculado] FROM vw_VEHICULOS2 WHERE Chasis IN (@chasis)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@chasis", cbxChasis.Text));

                string Precio = cmd.ExecuteScalar().ToString();
                txtMontoTotal.Text = Precio;
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                string eMessage = msg.ToString();
                con.Open();

                string query = "INSERT INTO LOGS VALUES(@logInfo, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@logInfo", eMessage));
                MessageBox.Show("No se pudo completar solicitud, favor contactar al proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        //Método utilizado para Guardar los nuevos registros.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar que todos los campos estén llenos.
            if(
                string.IsNullOrEmpty(cbxChasis.Text) || string.IsNullOrEmpty(cbxVendedores.Text) || string.IsNullOrEmpty(dtpFechaVenta.Text) || 
                string.IsNullOrEmpty(cbxModoPago.Text) || string.IsNullOrEmpty(txtMontoTotal.Text))
            {
                MessageBox.Show("Todos los campos son requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //En caso de que estén llenos llevar a cabo el proceso de guardar información a la base de Datos.
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "INSERT INTO Ventas VALUES(@fecha,(SELECT VendedorId FROM Vendedores WHERE Nombres IN(@nombreVendedor)),"+
                        " @tipopago, (SELECT VehiculoId FROM Vehiculos WHERE Chasis IN(@chasis)), @totalmonto)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@fecha",Convert.ToDateTime(dtpFechaVenta.Text)));
                    cmd.Parameters.Add(new SqlParameter("@nombreVendedor",cbxVendedores.Text));
                    cmd.Parameters.Add(new SqlParameter("@tipopago",cbxModoPago.Text));
                    cmd.Parameters.Add(new SqlParameter("@chasis",cbxChasis.Text));
                    cmd.Parameters.Add(new SqlParameter("@totalmonto",txtMontoTotal.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Venta Realizada de forma satisfactoria");

                    con.Close();

                    //Al concluir, nos dirigimos al formulario menú, actualizando los grids.
                    FrmMenu menu = (FrmMenu)Application.OpenForms["FrmMenu"];
                    menu.Show();
                    menu.FillDGVSold();
                    menu.FillDGVNotSold();
                    menu.Refresh();
                    this.Close();
                }
                catch (Exception msg)
                {
                    //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    string eMessage = msg.ToString();
                    con.Open();

                    string query = "INSERT INTO LOGS VALUES(@logInfo, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@logInfo", eMessage));
                    MessageBox.Show("No se pudo completar solicitud, favor contactar al proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }
    }
}

