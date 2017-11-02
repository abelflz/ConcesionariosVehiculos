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
        //Conexion a la Base de datos
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAutomovil movil = new FrmAutomovil();
            movil.ShowDialog();
        }

        private void btnServOfic_Click(object sender, EventArgs e)
        {
            FrmServiciosOficiales SO = new FrmServiciosOficiales();
            SO.ShowDialog();
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            FrmVendedores Vendedores = new FrmVendedores();
            Vendedores.ShowDialog();
        }

        private void btnVentAuto_Click(object sender, EventArgs e)
        {
            FrmVentaAuto VA = new FrmVentaAuto();
            VA.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            FillDGVSold();
            FillDGVNotSold();
        }

        public void FillDGVSold()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CS;
            con.Open();

            String query = "SELECT * FROM vw_CarSold";;
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            da.Fill(data);

            dgvAutosVendidos.DataSource = data;
            dgvAutosVendidos.Refresh();
            dgvAutosVendidos.Update();

            con.Close();
        }

        public void FillDGVNotSold()
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
    }
}
