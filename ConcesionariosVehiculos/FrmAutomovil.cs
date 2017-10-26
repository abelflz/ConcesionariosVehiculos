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

        private string x = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        private void FrmAutomovil_Load(object sender, EventArgs e)
        {
            try {

            }
            catch (Exception msg) {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = x;

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
