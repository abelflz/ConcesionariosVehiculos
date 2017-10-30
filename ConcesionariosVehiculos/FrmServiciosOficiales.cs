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
using System.Text.RegularExpressions;

namespace ConcesionariosVehiculos
{
    public partial class FrmServiciosOficiales : Form
    {
        public FrmServiciosOficiales()
        {
            InitializeComponent();
        }
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        private void FrmServiciosOficiales_Load(object sender, EventArgs e)
        {
            FillServOfic();
            FillServOficNIF();
            ClearValues();

        }

        private void FillServOfic(){
            try { 

            //Ejecucucion de Query para mostrar los datos de la Vista de Servicios Oficiales en el DataGrid
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CS;
            con.Open();

            string query = "SELECT * FROM vw_ServOfic";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            da.Fill(data);

            dgvServOfic.DataSource = data;
            dgvServOfic.AutoResizeColumns();

            dgvServOfic.Refresh();
            dgvServOfic.Update();

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
        private void FillServOficNIF()
        {
            try
            {
                cbxNIFBorrar.Items.Clear();
                cbxNIFModificar.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT NIF FROM vw_ServOfic";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxNIFBorrar.Items.Add(reader["NIF"].ToString());
                    cbxNIFModificar.Items.Add(reader["NIF"].ToString());
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

        private void ClearValues()
        {
            txtNIF.Text = "";
            txtNombre.Text = "";
            txtDomicilio.Text = "";

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

                    string query = "SELECT * FROM vw_ServOfic WHERE " + Filter + " LIKE ('%" + Value + "%') ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable data = new DataTable();
                    da.Fill(data);

                    dgvServOfic.DataSource = data;
                    dgvServOfic.AutoResizeColumns();

                    dgvServOfic.Refresh();
                    dgvServOfic.Update();

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

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(txtNIF.Text) ||
                    string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(txtDomicilio.Text)
                    ) {
                    MessageBox.Show("Todos los campos deben ser llenados");
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    con.Open();

                    string query = "INSERT INTO ServiciosOficiales values(@Nombre, @Direccion, @NIF)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombre.Text));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", txtDomicilio.Text));
                    cmd.Parameters.Add(new SqlParameter("@NIF", txtNIF.Text));

                    MessageBox.Show(cmd.ExecuteNonQuery() + " Servicio Oficial Agregado");
                    FillServOfic();
                    ClearValues();


                    con.Close();


                }
            }catch(Exception msg)
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxNIFBorrar.Text))
            {
                MessageBox.Show("Debe Seleccionar un NIF para poder eliminar el Registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxNIFBorrar.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "DELETE FROM ServiciosOFiciales WHERE NIF = @NIF";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@NIF", cbxNIFBorrar.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Servicio Oficial Eliminado");
                    con.Close();

                    FillServOfic();
                              
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe eliminar los registros anidados a este Servicio oficial para Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxNIFBorrar.SelectedIndex = -1;
                }
            }
        }

        private void txtNIF_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtNIF.Text, @"(^([0-9]*|\d*\d{1}?\d*)$)"))
            {
                txtNIF.Text = string.Empty;
            }
        }
    }
}
