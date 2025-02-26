using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCuentas : Form
    {
        public FrmCuentas()
        {
            InitializeComponent();
        }

        public void MtdMostrarCuentas()
        {
            CD_Cuentas cd_cuentas = new CD_Cuentas();
            DataTable dtMostrar = cd_cuentas.MtMostrarCuentas();
            DtgvV1.DataSource = dtMostrar;
        }

        private void FrmCuentas_Load(object sender, EventArgs e)
        {
            MtdMostrarCuentas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Cuentas Cuen = new CD_Cuentas();

            int cod = Convert.ToInt32(txtCodigoClientes.Text);
            decimal saldo = Convert.ToDecimal(txtSaldo.Text);


            try
            {

                Cuen.MtAgregarCuentas
                    (
                    cod,
                    txtNumeroCuenta.Text,
                    cboxTipoCuenta.Text,
                    saldo,
                    DtFechaApertura.Value,
                    cboxEstado.Text
                    );


                MessageBox.Show("La Cuenta se agregó con éxito", "Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
