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

        //Conexión a base de datos.
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        //Métodos a utilizar en la cargar del formulario.
        private void FrmServiciosOficiales_Load(object sender, EventArgs e)
        {
            FillServOfic();
            FillServOficNIF();
            ClearValues();
            ClearValuesModificar();
            BlockValuesModificar();

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

        //Método utilizado para el llenar los combo box con los datos de la BD.
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
                //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos.
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

        //Metodo para Limpiar los campo en el lado de Creación.
        private void ClearValues()
        {
            txtNIF.Text = "";
            txtNombre.Text = "";
            txtDomicilio.Text = "";

        }

        // Método para Limpiar los campo en el lado de modificación. 
        private void ClearValuesModificar()
        {
            txtNombreModificar.Text = "";
            txtDomilicioModificar.Text = "";
            cbxNIFModificar.SelectedIndex = -1;

        }

        //Método para bloqueo de campos para editar.
        private void BlockValuesModificar()
        {
            txtNombreModificar.ReadOnly = true;
            txtDomilicioModificar.ReadOnly = true;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cbxFilter.Text))
            {
                try
                {
                    //desarrollo de Código para el boton buscar, utilizando parámetros de búsqueda.
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
                    //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos.
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
                MessageBox.Show("Debe seleccionar un criterio a filtrar", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Desarrollo de botón crear, con validación de de campos no vacíos
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(txtNIF.Text) ||
                    string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(txtDomicilio.Text)
                    )
                {
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
                    FillServOficNIF();

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

        //Este Botón se utiliza para borrar los registros a partir del NIF (Número de Indentificación Fiscal)
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Validación de que no se encuentre vacío el Combobox
            if (string.IsNullOrEmpty(cbxNIFBorrar.Text))
            {
                MessageBox.Show("Debe Seleccionar un NIF para poder eliminar el Registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxNIFBorrar.Focus();
            }
            else
            {
                try
                {
                    //Conexión a la base de datos 
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    //Ejecucion de query a partir del parametro tomado del combobox
                    string query = "DELETE FROM ServiciosOFiciales WHERE NIF = @NIF";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@NIF", cbxNIFBorrar.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Servicio Oficial Eliminado");
                    con.Close();

                    FillServOfic();
                    FillServOficNIF();
                }
                catch (Exception)
                {
                    //En caso de error se presenta lo siguiente y reinicia el combobox a su valor por defecto
                    MessageBox.Show("Debe eliminar los registros anidados a este Servicio oficial para Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxNIFBorrar.SelectedIndex = -1;
                }
            }
        }

        //Validación de campo para introducir solo número
        private void txtNIF_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtNIF.Text, @"(^([0-9]*|\d*\d{1}?\d*)$)"))
            {
                txtNIF.Text = string.Empty;
            }
        }
        private string AutoEdit(string query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CS;
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            string Valor = cmd.ExecuteScalar().ToString();

            con.Close();

            return Valor;
        }

        //Método para el autollenado de campos para el caso de edicion de Servicios Oficiales
        private void cbxNIFModificar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxNIFModificar.SelectedIndex != -1)
            {

                txtDomilicioModificar.ReadOnly = false;
                txtNombreModificar.ReadOnly = false;

                try
                {
                    string query = "SELECT Nombre FROM ServiciosOficiales WHERE NIF = '" + cbxNIFModificar.Text + "'";
                    txtNombreModificar.Text = AutoEdit(query);
                    
                    query = "SELECT Direccion FROM ServiciosOficiales WHERE NIF = '" + cbxNIFModificar.Text + "'";
                    txtDomilicioModificar.Text = AutoEdit(query);
                }
                catch(Exception msgex)
                {
                    //En caso de Error, tomar datos y insertarlos en la entidad que corresponde a estos
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    string eMessage = msgex.ToString();
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
                BlockValuesModificar();
            }
        }

        //Desarrollo del boton Modificar con validacion de Cambios vacios, donde se sobreescriben los campo modificados
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDomilicioModificar.Text) || string.IsNullOrEmpty(txtNombreModificar.Text))
                {
                    MessageBox.Show("Todos los campos deben ser llenados");
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    con.Open();

                    string query = "UPDATE ServiciosOficiales SET Nombre = @nombre, Direccion = @Direccion WHERE NIF = @NIF";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombreModificar.Text));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", txtDomilicioModificar.Text));
                    cmd.Parameters.Add(new SqlParameter("@NIF", cbxNIFModificar.Text));
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Servicio Oficial Modificado");
                    FillServOfic();
                    ClearValuesModificar();
                    BlockValuesModificar();
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
    }
}
