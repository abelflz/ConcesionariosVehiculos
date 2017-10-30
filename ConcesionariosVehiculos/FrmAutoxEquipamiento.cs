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
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public FrmAutoxEquipamiento()
        {
            InitializeComponent();
        }

        private void FillCarsChasis()
        {
            try
            {
                cbxChasis.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Chasis FROM Vehiculos";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxChasis.Items.Add(reader["Chasis"].ToString());
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

        private void FrmAutoxEquipamiento_Load(object sender, EventArgs e)
        {
            FillCarsChasis();
        }

        private void cbxChasis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChasis.SelectedIndex != -1)
            {
                txtEquipamientos.ReadOnly = false;
                txtTotalPrecio.ReadOnly = false;

                try {
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

                    string query2 = "SELECT PrecioTotalEquipamientos FROM Vehiculos WHERE Chasis IN(@chasis)";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.Add(new SqlParameter("@chasis", cbxChasis.Text));
                    string precio = cmd2.ExecuteScalar().ToString();
                    txtTotalPrecio.Text = precio;
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
            else {
                txtEquipamientos.ReadOnly = true;
                txtTotalPrecio.ReadOnly = true;
            }
        }

        private void txtTotalPrecio_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTotalPrecio.Text, @"[0-9]+(\.[0-9][0-9]?)?"))
            {
                txtTotalPrecio.Text = "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtEquipamientos.Text) || string.IsNullOrEmpty(txtTotalPrecio.Text))) { 
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

                    this.Hide();
                    FrmMenu menu = new FrmMenu();
                    menu.Closed += (s, args) => this.Close();
                    menu.Show();

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Todos los campos son requeridos");
                    txtEquipamientos.Text = "";
                    txtTotalPrecio.Text = "";
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
