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
            //Metodos para rellanr los Combobox
            FillVendedorCedula();
            FillVendedoresDVG();
            FillServiciosOficiales();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbxFilter.Text))
            {
                try
                {
                    //Desarrollo de Codigo para el boton buscar, utilizando parametros de busqueda 
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string Filter = cbxFilter.Text;
                    string Value = txtValueFilter.Text;

                    string query = "SELECT DISTINCT * FROM Concesionarios.dbo.vw_Vendedores WHERE " + Filter + " LIKE ('%" + Value + "%') ";
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
            else
            {
                MessageBox.Show("Debe de seleccionar un critero para filtrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }

        //Metodo para llenar el combobox de cedula 
        private void FillVendedorCedula()
        {
            try
            {
                cbxCedulaBorrar.Items.Clear();
                cbxCedulaBorrar.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT DISTINCT Cedula FROM vw_Vendedores";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxCedulaBorrar.Items.Add(reader["Cedula"].ToString());
                    cbCedula.Items.AddRange(cbxCedulaBorrar.Items.Cast<string>().ToArray());
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

                string query = "SELECT DISTINCT *, (select count(*) from [Concesionarios].[dbo].[Ventas] as t2 where t2.[VendedorId] = t.VendedorId) as [Ventas Realizadas] FROM vw_Vendedores as t";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                dgvVendedores.DataSource = data;
                dgvVendedores.AutoResizeColumns();

                dgvVendedores.Refresh();
                dgvVendedores.Update();

                cbCedula.Items.Clear();

                for (var x = 0; x < dgvVendedores.RowCount; x++)
                    cbCedula.Items.Add(dgvVendedores.Rows[x].Cells["Cedula"].Value);

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

        //Metodo para llenar el combobox de Servicios 
        private void FillServiciosOficiales()
        {
            try
            {
                cbxServicioOficial.Items.Clear();
                cbxServOficEditar.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Nombre FROM ServiciosOficiales";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxServicioOficial.Items.Add(reader["Nombre"].ToString());
                    cbxServOficEditar.Items.Add(reader["Nombre"].ToString());
                }
                cbxServOficEditar.Items.AddRange(cbxServicioOficial.Items.Cast<string>().ToArray());
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

        //Desarrollo del boton borrar, con validacion de campos vacios
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

                    cbxCedulaBorrar.SelectedIndex = -1;
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe eliminar todas las transacciones que tienen dicho vendedor para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxCedulaBorrar.SelectedIndex = -1;
                }
            }
        }

        //Desarrollo del boton Crear, con validacion de campos vacios, Caracteres incorrectos y Adicion de los campos a la base de datos
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(cbxServicioOficial.Text))
                {
                    MessageBox.Show("Todos los campos deben de ser llenados");
                    return;
                }

                else if (System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"\d"))
                {
                    MessageBox.Show("Nombre incorrecto");
                    return;
                }

                else if (System.Text.RegularExpressions.Regex.IsMatch(txtApellido.Text, @"\d"))
                {
                    MessageBox.Show("Apellido incorrecto");
                    return;
                }

                else if (!validaCedula(txtCedula.Text))
                {
                    MessageBox.Show("Cédula incorrecta");
                    return;
                }

                for (var x = 0; x < dgvVendedores.RowCount; x++)
                    if (dgvVendedores.Rows[x].Cells[3].Value.ToString() == txtCedula.Text)
                    {
                        MessageBox.Show("La cédula ya existe");
                        return;
                    }

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                con.Open();

                string query = "SELECT COUNT(*) FROM concesionarios.dbo.Vendedores WHERE Cedula IN(@Cedula)";
                SqlCommand validacmd = new SqlCommand(query, con);
                validacmd.Parameters.Add(new SqlParameter("@cedula", txtCedula.Text));
                var cantidad = validacmd.ExecuteScalar().ToString();

                if (int.Parse(cantidad) == 0)
                {
                    string query2 = "INSERT INTO VENDEDORES([Nombres], [Apellidos], [ServOficialId], [Cedula]) VALUES(@Nombres, @Apellidos, (SELECT ServOficialId FROM ServiciosOficiales WHERE Nombre IN(@ServicioOficial)), @Cedula)";
                    SqlCommand cmd = new SqlCommand(query2, con);
                    cmd.Parameters.Add(new SqlParameter("@Nombres", txtNombre.Text));
                    cmd.Parameters.Add(new SqlParameter("@Apellidos", txtApellido.Text));
                    cmd.Parameters.Add(new SqlParameter("@ServicioOficial", cbxServicioOficial.Text));
                    cmd.Parameters.Add(new SqlParameter("@Cedula", txtCedula.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(" Se ha agregado un vendedor satisfactoriamente");

                    FillVendedoresDVG();
                    FillVendedorCedula();

                    con.Close();

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtCedula.Text = "";
                    cbxServicioOficial.Text = "";
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

        //Metodo para validacion de Cedula, donde se recore el string de la cedula y se validan los numeros uno a uno
        public static bool validaCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11 || vcCedula == "00000000000")
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }

        //Metodo para habilitar y llenar los campos del area de modificar, a partir de la cedula
        private void cbCedula_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (var x = 0; x < dgvVendedores.RowCount; x++)
                if (dgvVendedores.Rows[x].Cells["Cedula"].Value.ToString() == cbCedula.Items[cbCedula.SelectedIndex].ToString())
                {
                    txtNombreModificar.Text = dgvVendedores.Rows[x].Cells["Nombres"].Value.ToString();
                    txtApellidoModificar.Text = dgvVendedores.Rows[x].Cells["Apellidos"].Value.ToString();
                    cbxServOficEditar.SelectedIndex = cbxServOficEditar.Items.IndexOf(dgvVendedores.Rows[x].Cells["ServicioOficial"].Value.ToString());

                    txtNombreModificar.ReadOnly =
                    txtApellidoModificar.ReadOnly =
                    false;

                    cbxServOficEditar.Enabled = true;

                    break;
                }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtNombreModificar.Text, @"\d"))
                {
                    MessageBox.Show("Nombre incorrecto");
                    return;
                }

                else if (System.Text.RegularExpressions.Regex.IsMatch(txtApellidoModificar.Text, @"\d"))
                {
                    MessageBox.Show("Apellido incorrecto");
                    return;
                }

                var con = new SqlConnection();
                
                con.ConnectionString = CS;
                
                var script = $"update vendedores set [Nombres] = '{txtNombreModificar.Text}', [Apellidos] = '{txtApellidoModificar.Text}', [ServOficialId] = {cbxServOficEditar.SelectedIndex + 1} where [Cedula] = '{cbCedula.Text}'";

                con.Open();

                SqlCommand cmd = new SqlCommand(script, con);

                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Se ha modificado un vendedor satisfactoriamente");

                txtNombreModificar.Text = txtApellidoModificar.Text = cbCedula.Text =  "";
                cbxServOficEditar.SelectedIndex = -1;

                txtApellidoModificar.ReadOnly = txtNombreModificar.ReadOnly = true;

                cbxServOficEditar.Enabled = false;

                FillVendedoresDVG();
            }
            catch(Exception msg)
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