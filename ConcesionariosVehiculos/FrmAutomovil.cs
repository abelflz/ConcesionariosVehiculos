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
    public partial class FrmAutomovil : Form
    {
        public FrmAutomovil()
        {
            InitializeComponent();
        }

        //Conexion a la Base de datos
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        private void FrmAutomovil_Load(object sender, EventArgs e)
        {
            FillCarsChasis();
            FillCarsDGV();
            FillCarMarks();
        }

        private void FillCarMarks() {
            try {
                cbxMarca.Items.Clear();
                cbxMarcaEditar.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                string query = "SELECT MarcaDescripcion FROM Marcas";

                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxMarca.Items.Add(reader["MarcaDescripcion"].ToString());
                    cbxMarcaEditar.Items.Add(reader["MarcaDescripcion"].ToString());
                }
                con.Close();
            } catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //desarrollo de Codigo para el boton buscar, utilizando parametros de busqueda 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string Filter = cbxFilter.Text;
                string Value = txtValueFilter.Text;

                string query = "SELECT * FROM vw_VEHICULOS WHERE " + Filter + " LIKE ('%" + Value + "%') ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                dgvAutomovil.DataSource = data;
                dgvAutomovil.AutoResizeColumns();

                dgvAutomovil.Refresh();
                dgvAutomovil.Update();

                con.Close();
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos
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
        private void FillCarsChasis()
        {
            try
            {
                cbxChasisBorrar.Items.Clear();
                cbxChasisEditar.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Chasis FROM Vehiculos";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    cbxChasisEditar.Items.Add(reader["Chasis"].ToString());
                    cbxChasisBorrar.Items.Add(reader["Chasis"].ToString());
                }
            }
            catch (Exception msg)
            { 
                //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos
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
        private void FillCarsDGV() {
            try
            {
                //Ejecucucion de Query para mostrar los datos de la Vista de Automoviles en el DataGrid
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT *, Precio * (1 + Descuento) [Precio Calculado] FROM vw_VEHICULOS";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                dgvAutomovil.DataSource = data;
                dgvAutomovil.AutoResizeColumns();

                dgvAutomovil.Refresh();
                dgvAutomovil.Update();

                con.Close();
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos
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

        private void btnBorrarAutomovil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxChasisBorrar.Text))
            {
                MessageBox.Show("Debe seleccionar un chasis para a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxChasisBorrar.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "DELETE FROM Automovil WHERE Matricula = @matricula";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@matricula", cbxChasisBorrar.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("1 Automóvil Eliminado");
                    con.Close();

                    FillCarsChasis();
                    FillCarsDGV();
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe eliminar todas las transacciones que tienen dicho vehículo para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxChasisBorrar.SelectedIndex = -1;
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(txtChasis.Text) || string.IsNullOrEmpty(cbxCombustible.Text) ||
                    string.IsNullOrEmpty(cbxMarca.Text) || string.IsNullOrEmpty(cbxModelo.Text) ||
                    string.IsNullOrEmpty(cbxCilindrada.Text) || string.IsNullOrEmpty(cbxPotMax.Text) ||
                    string.IsNullOrEmpty(cbxAño.Text) || string.IsNullOrEmpty(cbxColor.Text) ||
                    string.IsNullOrEmpty(cbxPasajeros.Text) || string.IsNullOrEmpty(cbxPuertas.Text) ||
                    string.IsNullOrEmpty(cbxTipo.Text) || string.IsNullOrEmpty(cbxTraccion.Text) ||
                    string.IsNullOrEmpty(cbxEstado.Text) || string.IsNullOrEmpty(txtPrecio.Text) ||
                    string.IsNullOrEmpty(txtDescuento.Text)
                    )
                {
                    MessageBox.Show("Todos los campos deben de ser llenados");
                }
                else {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    con.Open();

                    int EstadoNum;

                    string query = "INSERT INTO VEHICULOS VALUES((SELECT ModeloId FROM Modelos WHERE ModeloDescripcion IN(@Modelo)),@Color, @Descuento, @Precio, @Cilindrada, @PotenciaMaxima, @Puertas, @Combustible,@Ano, @VehiculoTipo, @Estado, @Chasis, @Traccion, @Pasajeros)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Modelo", cbxModelo.Text));
                    cmd.Parameters.Add(new SqlParameter("@Color", cbxColor.Text));
                    cmd.Parameters.Add(new SqlParameter("@Descuento", txtDescuento.Text));
                    cmd.Parameters.Add(new SqlParameter("@Precio", txtPrecio.Text));
                    cmd.Parameters.Add(new SqlParameter("@Cilindrada", cbxCilindrada.Text));
                    cmd.Parameters.Add(new SqlParameter("@PotenciaMaxima", cbxPotMax.Text));
                    cmd.Parameters.Add(new SqlParameter("@Puertas", cbxPuertas.Text));
                    cmd.Parameters.Add(new SqlParameter("@Combustible", cbxCombustible.Text));
                    cmd.Parameters.Add(new SqlParameter("@Ano", cbxAño.Text));
                    cmd.Parameters.Add(new SqlParameter("@VehiculoTipo",cbxTipo.Text));

                    if(cbxEstado.Text == "Sí")
                    {
                        EstadoNum = 1;
                    }
                    else
                    {
                        EstadoNum = 0;
                    }

                    cmd.Parameters.Add(new SqlParameter("@Estado", EstadoNum));
                    cmd.Parameters.Add(new SqlParameter("@Chasis", txtChasis.Text));
                    cmd.Parameters.Add(new SqlParameter("@Traccion", cbxTraccion.Text));
                    cmd.Parameters.Add(new SqlParameter("@Pasajeros", cbxPasajeros.Text));

                    MessageBox.Show(cmd.ExecuteNonQuery() + " automóvil agregado satisfactoriamente");
                    con.Close();
                }
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos
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

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                cbxModelo.Items.Clear();
                cbxModelo.Enabled = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT * FROM Modelos JOIN Marcas ON Modelos.MarcaId = Marcas.MarcaId WHERE Marcas.MarcaDescripcion IN(@marca)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@marca", cbxMarca.Text));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxModelo.Items.Add(reader["ModeloDescripcion"].ToString());
                }
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos
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
