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
    public partial class FrmVendedores : Form
    {
        public FrmVendedores()
        {
            InitializeComponent();
        }

        //Conexion a la Base de datos
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        private void FrmVendedores_Load_1(object sender, EventArgs e)
        {
            FillVendedorCedula();
            FillVendedoresDVG();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            try
            {
                //desarrollo de Codigo para el boton buscar, utilizando parametros de busqueda 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string Filter = cbxFilter.Text;
                string Value = txtValueFilter.Text;

                string query = "SELECT * FROM Concesionarios.dbo.vw_Vendedores WHERE " + Filter + " LIKE ('%" + Value + "%') ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                dgvVendedores.DataSource = data;
                dgvVendedores.AutoResizeColumns();

                dgvVendedores.Refresh();
                dgvVendedores.Update();

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


        private void FillVendedorCedula()
        {
            try
            {
                cbxCedulaBorrar.Items.Clear();
                cbxCedulaBorrar.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Cedula FROM vw_Vendedores";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxCedulaBorrar.Items.Add(reader["Cedula"].ToString());
                    //cbxCedulaBorrar.Items.Add(reader["Cedula"].ToString());
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


        private void FillVendedoresDVG()
        {
            try
            {
                //Ejecucucion de Query para mostrar los datos de la Vista de Automoviles en el DataGrid
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT * FROM vw_Vendedores";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                dgvVendedores.DataSource = data;
                dgvVendedores.AutoResizeColumns();

                dgvVendedores.Refresh();
                dgvVendedores.Update();

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


        private void btnBorrarVendedor_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxCedulaBorrar.Text))
            {
                MessageBox.Show("Debe insertar una cédula para a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxCedulaBorrar.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "DELETE FROM vendedores WHERE cedula = @cedula";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@cedula", cbxCedulaBorrar.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se ha eliminado un Vendedor.");
                    con.Close();

                    FillVendedorCedula();
                    FillVendedoresDVG();
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe eliminar todas las transacciones que tienen dicho vendedor para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxCedulaBorrar.SelectedIndex = -1;
                }
            }
        }

    
    }
}
