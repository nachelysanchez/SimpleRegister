using SimpleRegister.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRegister
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuarios rusuarios = new rUsuarios();
            rusuarios.Show();
        }

        private void suplidoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rSuplidores rsuplidores = new rSuplidores();
            rsuplidores.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
        }
    }
}
