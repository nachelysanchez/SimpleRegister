using SimpleRegister.UI;
using SimpleRegister.UI.Consultas;
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

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos productos = new rProductos();
            productos.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.Show();

        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuarios user = new cUsuarios();
            user.Show();
        }

        private void suplidoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cSuplidores supl = new cSuplidores();
            supl.Show();
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProductos pro = new cProductos();
            pro.Show();
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realizado por Nachely Victoria Sánchez Burgos. \n Matricula: 100046842");
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("¿Estás seguro que desea cerrar sesión?", "Ventana principal", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                new Login().Show();
                this.Close();
            }
        }
    }
}
