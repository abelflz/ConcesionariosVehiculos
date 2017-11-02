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

        //Evento cargar del formulario, donde lleno el data grid view, y las listas de valores de chasis de vehículos y marcas.
        private void FrmAutomovil_Load(object sender, EventArgs e)
        {
            FillCarsChasis();
            FillCarsDGV();
            FillCarMarks();
        }

        //Llenar la lista de valores con las marcas de los vehículos del concesionario.
        private void FillCarMarks() {
            try {
                //Limpiar las listas de valores para evitar valores duplicados en casos de actualización.
                cbxMarca.Items.Clear();             
                cbxMarcaEditar.Items.Clear();

                //Creación de la conexión.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                //Definición de consulta a base de datos.
                string query = "SELECT MarcaDescripcion FROM Marcas";

                //Abrir Conexión para ejecutar consulta.
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader reader = cmd.ExecuteReader();

                //Mientras el objeto lee, ir llenando las listas de valores correspondientes.
                while (reader.Read())
                {
                    cbxMarca.Items.Add(reader["MarcaDescripcion"].ToString());
                    cbxMarcaEditar.Items.Add(reader["MarcaDescripcion"].ToString());
                }

                //Cierre de conexión.
                con.Close();
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
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

        //Filtrar valores del data grid view por criterios
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Condicional que define el llenado del criterio requerido
            if (!(string.IsNullOrEmpty(cbxFilter.Text)))
            {
                try
                {
                    //Desarrollo de Código para el botón buscar, ejecución de filtro, utilizando parámetros de búsqueda. 
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
                    //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
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
                //En caso de que no se haya llenado el criterio a buscar, mostrar mensaje informando que es requerido.
                MessageBox.Show("Campo criterio para filtrar es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Método utilizado para llenar la lista de chasis de vehículos en el concesionario.
        private void FillCarsChasis()
        {
            try
            {
                //Borrar los valores de las listas de valores para evitar valores duplicados en caso de actualización.
                cbxChasisBorrar.Items.Clear();
                cbxChasisEditar.Items.Clear();

                //Llenado de listas de valores a partir de una consulta a la base de datos.
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
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
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

        //Método para llenar el data grid view del formulario.
        public void FillCarsDGV() {
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
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
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

        //Método implementado para borrar un automóvil.
        private void btnBorrarAutomovil_Click(object sender, EventArgs e)
        {
            //Condición para definir la lista de valores de selección de chasis de vehículo a borrar como requerido.
            if (string.IsNullOrEmpty(cbxChasisBorrar.Text))
            {
                MessageBox.Show("Debe seleccionar un chasis para a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxChasisBorrar.Focus();
            }
            else
            {
                try
                {
                    //En caso de ser llenado correctamente, ejecutar sentencia para eliminar el registro requerido.
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "DELETE FROM Vehiculos WHERE Chasis IN (@chasis)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@chasis", cbxChasisBorrar.Text));
                    MessageBox.Show(cmd.ExecuteNonQuery()+" Automóvil Eliminado");
                    con.Close();

                    //Luego de realizarse el borrado, actualizar listas de valores y data grid view correspondientes.
                    FillCarsChasis();
                    FillCarsDGV();
                }
                catch (Exception)
                {
                    //En caso de que no se haya eliminado, informar que existen registros relacionados al mismo.
                    MessageBox.Show("Debe eliminar todas las transacciones que tienen dicho vehículo para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxChasisBorrar.SelectedIndex = -1;
                }
            }
        }

        //Método desarrollado para gestionar la creación de un nuevo vehículo
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                //Verificación de llenado de todos los campos, ya que los mismos son requeridos.
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
                    //En caso de cumplir con la condición de que todos los campos deben de ser llenados, proceder con la creación del vehículo.
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    con.Open();

                    //Verificamos que el chasis insertado sea nuevo en el concesionario.
                    string query = "SELECT COUNT(*) FROM VEHICULOS WHERE CHASIS IN(@chasis)";
                    SqlCommand validacmd = new SqlCommand(query, con);
                    validacmd.Parameters.Add(new SqlParameter("@chasis", txtChasis.Text));
                    var cantidad = validacmd.ExecuteScalar().ToString();

                    if (int.Parse(cantidad) == 0)
                    {
                        //En caso de ser nuevo, se procede a insertar el registro correspondiente en la base de datos.
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

                        //Se informa al usuario que el automóvil fue ingresado de manera satisfactoria.
                        MessageBox.Show(cmd.ExecuteNonQuery() + " automóvil agregado satisfactoriamente");

                        FillCarsDGV();

                        //Uso de método para limpiar valores guardados del nuevo vehículo.
                        ClearCreateValues();

                        con.Close();
                    }
                    else {
                        //En caso de haber un chasis igual, mostrar al usuario que existe un chasis con las mismas características.
                        MessageBox.Show("Chasis existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    con.Close();
                }
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
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

        //En caso de que se seleccione una marca, se procede a llenar la lista de valores del modelo (filtrado por marca) y a habilitar el componente correspondiente.
        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                //Se limpia los valores, para evitar incongruencia de datos en caso de que sea un evento de actualización
                cbxModelo.Items.Clear();

                //Se habilita el componente.
                cbxModelo.Enabled = true;

                //Se establece conexión a Base de Datos.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                //Se seleccionan los modelos correspondientes a la marca del vehículo
                string query = "SELECT ModeloDescripcion FROM Modelos JOIN Marcas ON Modelos.MarcaId = Marcas.MarcaId WHERE Marcas.MarcaDescripcion IN(@marca)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@marca", cbxMarca.Text));
                SqlDataReader reader = cmd.ExecuteReader();

                //Se agregan los valores al combobox de modelos de vehículos.
                while (reader.Read())
                {
                    cbxModelo.Items.Add(reader["ModeloDescripcion"].ToString());
                }
            }
            catch (Exception msg)
            {
                //En caso de Error, tomar datos y insertarlos en la entidad de Logs.
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

        //Métodos txtDescuento_TextChanged y txtPrecio_TextChanged para controlar el dato ingresado a únicamente valores numéricos.
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

        //Método creado para limpiar sección crear vehículo, luego de ser creado.
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

        //Evento selección de valores en combobox Chasis en sección editar.
        private void cbxChasisEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChasisEditar.SelectedIndex != -1)
            {
                //Hacer Nada.
            }
            else {
                //Inhabilitar todos los componentes.
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

        //Botón que se dirige al formulario de equipamientos.
        private void btnEquipamiento_Click(object sender, EventArgs e)
        {
            FrmAutoxEquipamiento auto = new FrmAutoxEquipamiento();
            auto.ShowDialog();
        }
    }
}