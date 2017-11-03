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

        //Conexion a la Base de datos.
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        //Método para cargar formulario.
        private void FrmAutomovil_Load(object sender, EventArgs e)
        {
            FillCarsChasis();
            FillCarsDGV();
            FillCarMarks();
        }

        //Método para llenar comboboxes de marcas de carros.
        private void FillCarMarks() {
            try {
                //Limpiar combo boxes.
                cbxMarca.Items.Clear();
                cbxMarcaEditar.Items.Clear();

                //Defino consulta a realizar y conexión.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                string query = "SELECT MarcaDescripcion FROM Marcas";

                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader reader = cmd.ExecuteReader();

                //Mientras se trae la data se va agregando en los combo boxes correspondientes.
                while (reader.Read())
                {
                    cbxMarca.Items.Add(reader["MarcaDescripcion"].ToString());
                    cbxMarcaEditar.Items.Add(reader["MarcaDescripcion"].ToString());
                }
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

        //Método utilizado para buscar y filtrar grid.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(cbxFilter.Text)))
            {
                try
                {
                    //Desarrollo de Código para el boton buscar, utilizando parámetros de búsqueda 
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    //Apertura de conexión.
                    con.Open();

                    //Definición de variables de filtro.
                    string Filter = cbxFilter.Text;
                    string Value = txtValueFilter.Text;

                    //Definición y ejecución de consulta.
                    string query = "SELECT * FROM vw_VEHICULOS2 WHERE " + Filter + " LIKE ('%" + Value + "%') ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable data = new DataTable();
                    da.Fill(data);

                    //Llenar el data grid view.
                    dgvAutomovil.DataSource = data;
                    dgvAutomovil.AutoResizeColumns();

                    dgvAutomovil.Refresh();
                    dgvAutomovil.Update();

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
                MessageBox.Show("Criterio para filtrar es requerido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Método utilizado para llenar/actualizar comboboxes de Chasis de carros.
        private void FillCarsChasis()
        {
            try
            {
                //Limpiar combo boxes.
                cbxChasisBorrar.Items.Clear();
                cbxChasisEditar.Items.Clear();

                //Definición de consulta y ejecución.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                //Apertura de conexión.
                con.Open();

                string query = "SELECT Chasis FROM Vehiculos";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                //Llenado de combo boxes.
                while (reader.Read()) {
                    cbxChasisEditar.Items.Add(reader["Chasis"].ToString());
                    cbxChasisBorrar.Items.Add(reader["Chasis"].ToString());
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

        //Método utilizado para llenar/actualizar el data grid view de carros.
        public void FillCarsDGV() {
            try
            {
                //Ejecución de Query para mostrar los datos de la Vista de Automoviles en el DataGrid.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                //Ejecución de consulta.
                con.Open();
                string query = "SELECT * FROM vw_VEHICULOS2";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                da.Fill(data);

                //Llenado de datagridview.
                dgvAutomovil.DataSource = data;
                dgvAutomovil.AutoResizeColumns();

                dgvAutomovil.Refresh();
                dgvAutomovil.Update();

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

        //Método utilizado para borrar un automóvil.
        private void btnBorrarAutomovil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxChasisBorrar.Text))
            {
                MessageBox.Show("Debe seleccionar un chasis para a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxChasisBorrar.Focus();
            }
            else
            {
                try
                {
                    //Apertura de conexión y ejecución de consulta, para eliminación de vehículos.
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "DELETE FROM Vehiculos WHERE Chasis IN (@chasis)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@chasis", cbxChasisBorrar.Text));
                    MessageBox.Show(cmd.ExecuteNonQuery()+" Automóvil Eliminado");
                    con.Close();

                    FillCarsChasis();
                    FillCarsDGV();
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe eliminar todas las transacciones que tienen dicho vehículo para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxChasisBorrar.SelectedIndex = -1;
                }
            }
        }

        //Método utilizado para agregar un automóvil.
        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
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
                    //Creación de conexión.
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    //Apertura de conexión.
                    con.Open();

                    //Validar que no existe chasis igual.
                    string query = "SELECT COUNT(*) FROM VEHICULOS WHERE CHASIS IN(@chasis)";
                    SqlCommand validacmd = new SqlCommand(query, con);
                    validacmd.Parameters.Add(new SqlParameter("@chasis", txtChasis.Text));
                    var cantidad = validacmd.ExecuteScalar().ToString();

                    if (int.Parse(cantidad) == 0)
                    {
                        //En caso de ser nuevo, proceder al guardado del nuevo vehículo.
                        int Estado;
                        float descuento;

                        descuento = float.Parse(txtDescuento.Text) / 100;

                        string query2 = "INSERT INTO VEHICULOS VALUES((SELECT ModeloId FROM Modelos WHERE ModeloDescripcion IN(@Modelo)),@Color, @Descuento, @Precio, @Cilindrada, @PotenciaMaxima, @Puertas, @Combustible,@Ano, @VehiculoTipo, @Estado, @Chasis, @Traccion, @Pasajeros, '', 0)";
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

                        MessageBox.Show(cmd.ExecuteNonQuery() + " automóvil agregado satisfactoriamente");

                        //Actualización de DataGridsViews y Combo Boxes.
                        FillCarsDGV();
                        ClearCreateValues();
                        FillCarsChasis();

                        con.Close();
                    }
                    else {
                        //Informar al usuario en caso de que el chasis ingresado ya existe.
                        MessageBox.Show("Chasis existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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

        //Método creado para buscar los modelos a partir de una marca.
        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                cbxModelo.Items.Clear();
                cbxModelo.Enabled = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT ModeloDescripcion FROM Modelos JOIN Marcas ON Modelos.MarcaId = Marcas.MarcaId WHERE Marcas.MarcaDescripcion IN(@marca)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@marca", cbxMarca.Text));

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbxModelo.Items.Add(reader["ModeloDescripcion"].ToString());
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

        //Métodos que validan si el valor ingresado es un número, o si es inválido.
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

        //Método que ejecuta las sentencias para el llenado de información de un carro a partir de su chasis (para editar la información del mismo).
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

        //Método creado para borrar componentes del formulario luego de añadir un vehículo de forma satisfactoria.
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

        //Método creado para definir los queries para llenar los campos de un vehículo a editar a partir de su chasis.
        private void cbxChasisEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChasisEditar.SelectedIndex != -1)
            {
                cbxCombustibleEditar.Enabled = true;
                cbxMarcaEditar.Enabled = true;
                cbxCilindradaEditar.Enabled = true;
                cbxPotMaxEditar.Enabled = true;
                cbxAñoEditar.Enabled = true;
                cbxColorEditar.Enabled = true;
                cbxPasajerosEditar.Enabled = true;
                cbxPuertasEditar.Enabled = true;
                cbxTipoEditar.Enabled = true;
                cbxTraccionEditar.Enabled = true;
                cbxEstadoEditar.Enabled = true;
                txtPrecioEditar.ReadOnly = false;
                txtDescuentoEditar.ReadOnly = false;

                try
                {
                    string query = "SELECT Combustible FROM Vehiculos WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxCombustibleEditar.Text = AutoEdit(query);

                    query = "SELECT Marcas.MarcaDescripcion FROM VEHICULOS JOIN Modelos ON Modelos.ModeloId = Vehiculos.ModeloId JOIN Marcas ON Marcas.MarcaId = Modelos.MarcaId WHERE Vehiculos.Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxMarcaEditar.Text = AutoEdit(query);

                    query = "SELECT Modelos.ModeloDescripcion FROM VEHICULOS JOIN Modelos ON Modelos.ModeloId = Vehiculos.ModeloId WHERE Vehiculos.Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxModeloEditar.Text = AutoEdit(query);

                    query = "SELECT Cilindrada FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxCilindradaEditar.Text = AutoEdit(query);

                    query = "SELECT PotenciaMaxima FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxPotMaxEditar.Text = AutoEdit(query);

                    query = "SELECT Ano FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxAñoEditar.Text = AutoEdit(query);

                    query = "SELECT Color FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxColorEditar.Text = AutoEdit(query);

                    query = "SELECT Pasajeros FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxPasajerosEditar.Text = AutoEdit(query);

                    query = "SELECT Puertas FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxPuertasEditar.Text = AutoEdit(query);

                    query = "SELECT VehiculoTipo FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxTipoEditar.Text = AutoEdit(query);

                    query = "SELECT Traccion FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxTraccionEditar.Text = AutoEdit(query);

                    query = "SELECT IIF(Estado = 1,'Si','No') FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    cbxEstadoEditar.Text = AutoEdit(query);

                    query = "SELECT Precio FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    txtPrecioEditar.Text = AutoEdit(query);

                    query = "SELECT Descuento*100 FROM VEHICULOS WHERE Chasis = '" + cbxChasisEditar.Text + "'";
                    txtDescuentoEditar.Text = AutoEdit(query);
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
                cbxCombustibleEditar.Enabled = false;
                cbxMarcaEditar.Enabled = false;
                cbxModeloEditar.Enabled = false;
                cbxCilindradaEditar.Enabled = false;
                cbxPotMaxEditar.Enabled = false;
                cbxAñoEditar.Enabled = false;
                cbxColorEditar.Enabled = false;
                cbxPasajerosEditar.Enabled = false;
                cbxPuertasEditar.Enabled = false;
                cbxTipoEditar.Enabled = false;
                cbxTraccionEditar.Enabled = false;
                cbxEstadoEditar.Enabled = false;
                txtPrecioEditar.ReadOnly = true;
                txtDescuentoEditar.ReadOnly = true;
            }
        }

        //Método utilizado para abrir formulario de equipamientos de vehículos.
        private void btnEquipamiento_Click(object sender, EventArgs e)
        {
            FrmAutoxEquipamiento auto = new FrmAutoxEquipamiento();
            auto.ShowDialog();
        }

        //Método utilizado para llenar los modelos al seleccionar una marca de un vehículo a editar.
        private void cbxMarcaEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMarcaEditar.SelectedIndex != 1)
            {
                cbxModeloEditar.Enabled = true;
                try
                {
                    cbxModeloEditar.Items.Clear();
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "SELECT Modelos.ModeloDescripcion modelo FROM Modelos FULL JOIN Marcas ON Modelos.MarcaId = Marcas.MarcaId WHERE Marcas.MarcaDescripcion IN(@marca)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@marca", cbxMarcaEditar.Text));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cbxModeloEditar.Items.Add(reader["modelo"].ToString());
                    }
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
                cbxModeloEditar.Enabled = false;
            }
        }

        private void txtPrecioEditar_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtPrecioEditar.Text, @"[0-9]+(\.[0-9][0-9]?)?"))
            {
                txtPrecioEditar.Text = string.Empty;
            }
        }

        //Método utilizado para validar que el dato ingresado a este componente sea únicamente números.
        private void txtDescuentoEditar_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtDescuentoEditar.Text, @"[09]+(\.[09][09]?)?"))
            {
                txtDescuentoEditar.Text = string.Empty;
            }
        }

        //Método utilizado para actualizar información en la base de datos (modificar vehículos).
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;

                int Estado;
                con.Open();

                string query = "UPDATE Vehiculos SET ModeloId = (SELECT m.ModeloId FROM Vehiculos v JOIN Modelos m ON m.ModeloId = v.ModeloId WHERE m.ModeloDescripcion IN(@Modelo)), " +
                " Color = @Color, Descuento = @Descuento, Precio = @Precio, Cilindrada = @Cilindrada, " +
                " PotenciaMaxima = @PotMax, Puertas = @Puertas, Combustible = @Combustible, Ano = @Ano, VehiculoTipo = @Tipo, Estado = @Estado, Traccion = @Traccion, " +
                " Pasajeros = @Pasajeros WHERE Chasis = @Chasis ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@Modelo", cbxModeloEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Color", cbxColorEditar.Text));

                double Descuento = double.Parse(txtDescuentoEditar.Text) / 100;

                cmd.Parameters.Add(new SqlParameter("@Descuento", Descuento));
                cmd.Parameters.Add(new SqlParameter("@Precio", txtPrecioEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Cilindrada", cbxCilindradaEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@PotMax", cbxPotMaxEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Puertas", cbxPuertasEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Combustible", cbxCombustibleEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Ano", cbxAñoEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Tipo", cbxTipoEditar.Text));

                if (cbxEstadoEditar.Text == "Si")
                {
                    Estado = 1;
                }
                else
                {
                    Estado = 0;
                }

                cmd.Parameters.Add(new SqlParameter("@Estado", Estado));
                cmd.Parameters.Add(new SqlParameter("@Traccion", cbxTraccionEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Pasajeros", cbxPasajerosEditar.Text));
                cmd.Parameters.Add(new SqlParameter("@Chasis", cbxChasisEditar.Text));

                MessageBox.Show(cmd.ExecuteNonQuery() + " Artículo Actualizado Satisfactoriamente");

                FillCarsDGV();

                cbxChasisEditar.SelectedIndex = -1;
                cbxCombustibleEditar.SelectedIndex = -1;
                cbxMarcaEditar.SelectedIndex = -1;
                cbxModeloEditar.SelectedIndex = -1;
                cbxCilindradaEditar.SelectedIndex = -1;
                cbxPotMaxEditar.SelectedIndex = -1;
                cbxAñoEditar.SelectedIndex = -1;
                cbxColorEditar.SelectedIndex = -1;
                cbxPasajerosEditar.SelectedIndex = -1;
                cbxPuertasEditar.SelectedIndex = -1;
                cbxTipoEditar.SelectedIndex = -1;
                cbxTraccionEditar.SelectedIndex = -1;
                cbxEstadoEditar.SelectedIndex = -1;
                txtPrecioEditar.Text = "";
                txtDescuentoEditar.Text = "";

                cbxCombustibleEditar.Enabled = false;
                cbxMarcaEditar.Enabled = false;
                cbxModeloEditar.Enabled = false;
                cbxCilindradaEditar.Enabled = false;
                cbxPotMaxEditar.Enabled = false;
                cbxAñoEditar.Enabled = false;
                cbxColorEditar.Enabled = false;
                cbxPasajerosEditar.Enabled = false;
                cbxPuertasEditar.Enabled = false;
                cbxTipoEditar.Enabled = false;
                cbxTraccionEditar.Enabled = false;
                cbxEstadoEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                cbxCombustibleEditar.Enabled = false;
                txtPrecioEditar.ReadOnly = true;
                txtDescuentoEditar.ReadOnly = true;

                FillCarsChasis();

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