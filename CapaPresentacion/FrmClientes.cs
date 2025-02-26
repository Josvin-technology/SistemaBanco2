using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        /*    
        public void MtdMostrarClientes()
        {
            CD_Clientes cd_clientes = new CD_Clientes();
            DataTable dtClientes = cd_clientes.MtMostrarClientes();
            dgvClientes.DataSource = dtClientes;
        }
        */

        public void MtdMostrarClientes()
        {
            CD_Clientes cd_clientes = new CD_Clientes();
            DataTable dtMostrarClientes = cd_clientes.MtMostrarClientes();
            dgvClientes.DataSource = dtMostrarClientes;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MtdMostrarClientes();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            CD_Clientes cliente = new CD_Clientes();

            try
            {
                cliente.mtdAgregarClientes(txtCodigoCliente.Text, txtNombres.Text, txtPais.Text, txtDireccion.Text, cboxCategoria.Text, cboxEstado.Text);

                MessageBox.Show("El cliente se agregó con éxito", "Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.StackTrace, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCliente.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtNombres.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtPais.Text = dgvClientes.SelectedCells[2].Value.ToString();
            txtDepartamento.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtDireccion.Text = dgvClientes.SelectedCells[4].Value.ToString();
            cboxCategoria.Text = dgvClientes.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvClientes.SelectedCells[6].Value.ToString();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            CD_Clientes cliente = new CD_Clientes();

            try 
            {
                cliente.MtdActualizarCliente(
                           int.Parse(txtCodigoCliente.Text),
                           txtNombres.Text,
                           txtDireccion.Text,
                           txtDepartamento.Text,
                           txtPais.Text,
                           cboxCategoria.Text,
                           cboxEstado.Text
                       ); MessageBox.Show("El cliente se actualizo con éxito", "Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
