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
    public partial class FrmMenu : Form
    {
        //Conexión a la base de datos, consultando en el App Config.
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public FrmMenu()
        {
            InitializeComponent();
        }

        //Método desarrollado para abrir el formulario automóvil.
        private void button1_Click(object sender, EventArgs e)
        {
            FrmAutomovil movil = new FrmAutomovil();
            movil.ShowDialog();
        }

        //Método desarrollado para abrir el formulario de servicio generales.
        private void btnServOfic_Click(object sender, EventArgs e)
        {
            FrmServiciosOficiales SO = new FrmServiciosOficiales();
            SO.ShowDialog();
        }

        //Método desarrollado para abrir el formulario de Vendedores.
        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FrmVendedores Vendedores = new FrmVendedores();
            Vendedores.ShowDialog();
        }

        //Método desarrollado para abrir el formulario de ventas de automóviles.
        private void btnVentAuto_Click(object sender, EventArgs e)
        {
            FrmVentaAuto VA = new FrmVentaAuto();
            VA.ShowDialog();
        }

        //Método que representa las acciones a realizar en el formulario al cargar.
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            //Métodos utilizados para llenar data grids views de vehículos vendidos y no vendidos.
            FillDGVSold();
            FillDGVNotSold();
        }

        //Método desarrollado para llenar el data grid view de vehículos vendidos.
        public void FillDGVSold()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                String query = "SELECT * FROM vw_CarSold"; ;
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                dgvAutosVendidos.DataSource = data;
                dgvAutosVendidos.Refresh();
                dgvAutosVendidos.Update();

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

        //Método desarrollado para llenar el data grid view de vehículos no vendidos.
        public void FillDGVNotSold()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                String query = "SELECT * FROM vw_CarNotSold"; ;
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                dgvAutosNoVendidos.DataSource = data;
                dgvAutosNoVendidos.Refresh();
                dgvAutosNoVendidos.Update();

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
    }
}
