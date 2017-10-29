﻿using System;
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

        //Conexion a la Base de datos
        private string CS = System.Configuration.ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        private void FrmAutomovil_Load(object sender, EventArgs e)
        {
            FillCarsMat();
            FillCarsDGV();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //desarrollo de Codigo para el boton buscar, utilizando parametros de busqueda 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string Filter = cbxFilter.Text;
                string Value = txtValueFilter.Text;

                string query = "SELECT * FROM vw_Automovil WHERE " + Filter + " LIKE ('%" + Value + "%') ";
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
        private void FillCarsMat()
        {
            try
            {
                cbxMatriculaBorrar.Items.Clear();
                cbxMatriculaEditar.Items.Clear();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT Matricula FROM Automovil";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    cbxMatriculaEditar.Items.Add(reader["Matricula"].ToString());
                    cbxMatriculaBorrar.Items.Add(reader["Matricula"].ToString());
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
        private void FillCarsDGV() {
            try
            {
                //Ejecucucion de Query para mostrar los datos de la Vista de Automoviles en el DataGrid
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CS;
                con.Open();

                string query = "SELECT * FROM vw_Automovil";

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

        private void btnBorrarAutomovil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbxMatriculaBorrar.Text))
            {
                MessageBox.Show("Debe insertar una matrícula para a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbxMatriculaBorrar.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;
                    con.Open();

                    string query = "DELETE FROM Automovil WHERE Matricula = @matricula";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@matricula", cbxMatriculaBorrar.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("1 Automóvil Eliminado");
                    con.Close();

                    FillCarsMat();
                    FillCarsDGV();
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe eliminar todas las transacciones que tienen dicho vehículo para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxMatriculaBorrar.SelectedIndex = -1;
                }
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text) ||
                    string.IsNullOrEmpty(txtDescuento.Text) || string.IsNullOrEmpty(txtPrecio.Text) ||
                    string.IsNullOrEmpty(cbxMotor.Text) || string.IsNullOrEmpty(txtColor.Text) ||
                    string.IsNullOrEmpty(cbxCombustible.Text) || string.IsNullOrEmpty(cbxTipo.Text) ||
                    string.IsNullOrEmpty(cbxPuertas.Text) || string.IsNullOrEmpty(cbxPasajeros.Text) ||
                    string.IsNullOrEmpty(cbxTraccion.Text) || string.IsNullOrEmpty(txtMatricula.Text)
                    ) {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CS;

                    con.Open();

                    string query = "INSERT INTO Automovil VALUES(@marca,@modelo,@descuento,@precio,@motor,@color,@combustible,@tipo,@puertas,@pasajeros,@traccion,@matricula)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@marca", txtMarca.Text));
                    cmd.Parameters.Add(new SqlParameter("@modelo", txtModelo.Text));
                    cmd.Parameters.Add(new SqlParameter("@descuento", txtDescuento.Text));
                    cmd.Parameters.Add(new SqlParameter("@precio", txtPrecio.Text));
                    cmd.Parameters.Add(new SqlParameter("@motor", cbxMotor.Text));
                    cmd.Parameters.Add(new SqlParameter("@color", txtColor.Text));
                    cmd.Parameters.Add(new SqlParameter("@combustible", cbxCombustible.Text));
                    cmd.Parameters.Add(new SqlParameter("@tipo", cbxTipo.Text));
                    cmd.Parameters.Add(new SqlParameter("@puertas", cbxPuertas.Text));
                    cmd.Parameters.Add(new SqlParameter("@pasajeros", cbxPasajeros.Text));
                    cmd.Parameters.Add(new SqlParameter("@traccion", cbxTraccion.Text));
                    cmd.Parameters.Add(new SqlParameter("@matricula", txtMatricula.Text));

                    MessageBox.Show(cmd.ExecuteNonQuery() + " automóvil agregado satisfactoriamente");
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
