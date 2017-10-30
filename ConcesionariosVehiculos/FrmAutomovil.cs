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

                string query = "SELECT * FROM vw_VEHICULOS2";

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

                    string query = "DELETE FROM Vehiculos WHERE Chasis IN (@chasis)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@chasis", cbxChasisBorrar.Text));
                    MessageBox.Show(cmd.ExecuteNonQuery()+" Automóvil Eliminado");
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

                    string query = "SELECT COUNT(*) FROM VEHICULOS WHERE CHASIS IN(@chasis)";
                    SqlCommand validacmd = new SqlCommand(query, con);
                    validacmd.Parameters.Add(new SqlParameter("@chasis", txtChasis.Text));
                    var cantidad = validacmd.ExecuteScalar().ToString();

                    if (int.Parse(cantidad) == 0)
                    {
                        int Estado;
                        float descuento;

                        descuento = float.Parse(txtDescuento.Text) / 100;

                        string query2 = "INSERT INTO VEHICULOS VALUES((SELECT ModeloId FROM Modelos WHERE ModeloDescripcion IN(@Modelo)),@Color, @Descuento, @Precio, @Cilindrada, @PotenciaMaxima, @Puertas, @Combustible,@Ano, @VehiculoTipo, @Estado, @Chasis, @Traccion, @Pasajeros)";
                        SqlCommand cmd = new SqlCommand(query2, con);
                        cmd.Parameters.Add(new SqlParameter("@Modelo", cbxModelo.Text));
                        cmd.Parameters.Add(new SqlParameter("@Color", cbxColor.Text));
                        cmd.Parameters.Add(new SqlParameter("@Descuento", descuento));
                        cmd.Parameters.Add(new SqlParameter("@Precio", txtPrecio.Text));
                        cmd.Parameters.Add(new SqlParameter("@Cilindrada", cbxCilindrada.Text));
                        cmd.Parameters.Add(new SqlParameter("@PotenciaMaxima", cbxPotMax.Text));
                        cmd.Parameters.Add(new SqlParameter("@Puertas", cbxPuertas.Text));
                        cmd.Parameters.Add(new SqlParameter("@Combustible", cbxCombustible.Text));
                        cmd.Parameters.Add(new SqlParameter("@Ano", cbxAño.Text));
                        cmd.Parameters.Add(new SqlParameter("@VehiculoTipo", cbxTipo.Text));

                        if (cbxEstado.Text == "Sí")
                        {
                            Estado = 1;
                        }
                        else
                        {
                            Estado = 0;
                        }

                        cmd.Parameters.Add(new SqlParameter("@Estado", Estado));
                        cmd.Parameters.Add(new SqlParameter("@Chasis", txtChasis.Text));
                        cmd.Parameters.Add(new SqlParameter("@Traccion", cbxTraccion.Text));
                        cmd.Parameters.Add(new SqlParameter("@Pasajeros", cbxPasajeros.Text));

                        MessageBox.Show(cmd.ExecuteNonQuery() + " automóvil agregado satisfactoriamente");

                        FillCarsDGV();
                        ClearCreateValues();

                        con.Close();
                    }
                    else {
                        MessageBox.Show("Chasis existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

                string query = "SELECT ModeloDescripcion FROM Modelos JOIN Marcas ON Modelos.MarcaId = Marcas.MarcaId WHERE Marcas.MarcaDescripcion IN(@marca)";

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

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtDescuento.Text,@"(^([0-9]*|\d*\d{1}?\d*)$)"))
            {
                txtDescuento.Text = string.Empty;
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtPrecio.Text, @"(^([0-9]*|\d*\d{1}?\d*)$)"))
            {
                txtPrecio.Text = string.Empty;
            }
        }

        private void ClearCreateValues() {
            txtChasis.Text = "";
            cbxCombustible.SelectedIndex = -1;
            cbxMarca.SelectedIndex = -1;
            cbxModelo.SelectedIndex = -1;
            cbxCilindrada.SelectedIndex = -1;
            cbxPotMax.SelectedIndex = -1;
            cbxAño.SelectedIndex = -1;
            cbxColor.SelectedIndex = -1;
            cbxPasajeros.SelectedIndex = -1;
            cbxPuertas.SelectedIndex = -1;
            cbxTipo.SelectedIndex = -1;
            cbxTraccion.SelectedIndex = -1;
            cbxEstado.SelectedIndex = -1;
            txtPrecio.Text = "";
            txtDescuento.Text = "";
        }

        private void cbxChasisEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChasisEditar.SelectedIndex != -1)
            {

            }
            else {
                cbxCombustibleEditar.Enabled = false;
                cbxMarcaEditar.Enabled = false;
                cbxCilindradaEditar.Enabled = false;
                cbxPotMaxEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;

                txtPrecioEditar.ReadOnly = true;
                txtDescuentoEditar.ReadOnly = true;
            }
        }
    }
}