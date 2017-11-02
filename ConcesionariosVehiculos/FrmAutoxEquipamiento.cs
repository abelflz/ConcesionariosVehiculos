using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcesionariosVehiculos
{
    public partial class FrmAutoxEquipamiento : Form
    {
        //Connection String obtenido desde App.config
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public FrmAutoxEquipamiento()
        {
            InitializeComponent();
        }

        //Método creado para llenar el combobox de chasis de los vehículos del concesionario.
        private void FillCarsChasis()
        {
            try
            {
                //Limpiar valores del combobox para prevenir duplicación de valores en el mismo.
                cbxChasis.Items.Clear();

                //Creación de la conexión sql para ejecutar sentencia.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Chasis FROM Vehiculos";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                //Llenado de combobox con la información obtenida de la base de datos.
                while (reader.Read())
                {
                    cbxChasis.Items.Add(reader["Chasis"].ToString());
                }

                //Cierre de Conexión
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

        //Al cargar el formulario, se activa el método anterior para llenar de valores al combobox chasis.
        private void FrmAutoxEquipamiento_Load(object sender, EventArgs e)
        {
            FillCarsChasis();
        }

        //Método ejecutado al seleccionar un chasis de la lista de valores, para buscar sus equipamientos filtrando por el mismo chasis.
        private void cbxChasis_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Condición para verificar si el valor seleccionado no está vacío.
            if (cbxChasis.SelectedIndex != -1)
            {
                //Se habilitan los campos a llenar en caso de que se haya seleccionado un vehículo válido.
                txtEquipamientos.ReadOnly = false;
                txtTotalPrecio.ReadOnly = false;

                try {
                    //Se lleva a cabo la consulta a la base de datos para llenar los campos con los equipamientos extras del vehículo.
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    string query = "SELECT Equipamientos FROM Vehiculos WHERE Chasis IN(@chasis)";
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@chasis", cbxChasis.Text));
                    string equipamiento = cmd.ExecuteScalar().ToString();
                    txtEquipamientos.Text = equipamiento;

                    con.Close();
                    con.Open();
                    
                    //Se lleva a cabo la consulta para tomar el precio del equipamiento previamente consultado.
                    string query2 = "SELECT PrecioTotalEquipamientos FROM Vehiculos WHERE Chasis IN(@chasis)";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.Add(new SqlParameter("@chasis", cbxChasis.Text));
                    string precio = cmd2.ExecuteScalar().ToString();
                    txtTotalPrecio.Text = precio;
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
            else {
                //En caso de no cumplir con la condición planteada, se inhabilitan los componentes.
                txtEquipamientos.ReadOnly = true;
                txtTotalPrecio.ReadOnly = true;
            }
        }

        //Método utilizado para verificar que solo se ingresan valores numéricos al campo.
        private void txtTotalPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTotalPrecio.Text, @"[0-9]+(\.[0-9][0-9]?)?"))
            {
                txtTotalPrecio.Text = "";
            }
        }
        
        //Método desarrollado para guardar los equipamientos extras del vehículo.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificación de llenado de campos. El llenado de estos es requerido.
                if (!(string.IsNullOrEmpty(txtEquipamientos.Text) || string.IsNullOrEmpty(txtTotalPrecio.Text))) { 
                    //En caso de cumplir, se procede a actualizar (o crear) el registro.
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "UPDATE VEHICULOS SET Equipamientos = @equipamiento,PrecioTotalEquipamientos = @precio WHERE Chasis = @chasis";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Chasis", cbxChasis.Text));
                    cmd.Parameters.Add(new SqlParameter("@equipamiento", txtEquipamientos.Text));
                    cmd.Parameters.Add(new SqlParameter("@precio", txtTotalPrecio.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Equipamientos registrados satisfactoriamente.");
                    con.Close();

                    //Código utilizado para actualizar el data grid view del formulario de automóviles.
                    FrmAutomovil automovil = (FrmAutomovil)Application.OpenForms["FrmAutomovil"];
                    automovil.Show();
                    automovil.FillCarsDGV();
                    automovil.Refresh();
                    this.Close();                    
                }
                else
                {
                    //En caso de no cumplir, se procede a informar al usuario que todos los campos son requeridos.
                    MessageBox.Show("Todos los campos son requeridos");
                    txtEquipamientos.Text = "";
                    txtTotalPrecio.Text = "";
                }
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
