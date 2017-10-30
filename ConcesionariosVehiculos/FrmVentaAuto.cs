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
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        private void FrmVentaAuto_Load(object sender, EventArgs e)
        {
            FillVentAuto();
        }

        private void FillVentAuto()
        {
            try
            {
                cbxVendedores.Items.Clear();
                cbxChasis.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Nombres, Chasis FROM vw_VentAuto";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxChasis.Items.Add(reader["Chasis"].ToString());
                    cbxVendedores.Items.Add(reader["Nombres"].ToString());
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

