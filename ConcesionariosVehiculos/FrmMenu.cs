using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcesionariosVehiculos
{
    public partial class FrmMenu : Form
    {
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
    }
}
