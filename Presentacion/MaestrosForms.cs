using ControlEscolar.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDA2.Presentacion
{
    public partial class MaestrosForms : Form
    {
        private MaestrosNegocio maestrosNegocio = new MaestrosNegocio();

        public MaestrosForms()
        {
            InitializeComponent();
            CargarMaestros();
        }

        private void MaestrosForms_Load(object sender, EventArgs e)
        {

        }
        private void CargarMaestros()
        {
            dgvMaestros.DataSource = maestrosNegocio.ObtenerMaestros();  // Llamada a la capa de negocio
        }
        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTelefono.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                maestrosNegocio.AgregarMaestro(txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text);

                MessageBox.Show("Maestro agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMaestros();  // Refrescar la lista de maestros
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Por favor, selecciona un maestro para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                maestrosNegocio.ActualizarMaestro(int.Parse(txtId.Text), txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text);

                MessageBox.Show("Maestro actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMaestros();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBox.Show("Por favor, selecciona un maestro para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este maestro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    maestrosNegocio.EliminarMaestro(int.Parse(txtId.Text));

                    MessageBox.Show("Maestro eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMaestros();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            CargarMaestros();
        }
        private void dgvMaestros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvMaestros.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvMaestros.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvMaestros.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtEmail.Text = dgvMaestros.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtTelefono.Text = dgvMaestros.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            }
        }
    }
}
