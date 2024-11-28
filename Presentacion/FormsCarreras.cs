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
    public partial class FormsCarreras : Form
    {
        private CarrerasNegocio carrerasNegocio = new CarrerasNegocio();

        public FormsCarreras()
        {
            InitializeComponent();
            CargarCarreras();
        }
        private void CargarCarreras()
        {
            dgvCarreras.DataSource = carrerasNegocio.ObtenerCarreras();
        }
        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombreCarrera.Text = string.Empty;
        }
        private void FormsCarreras_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombreCarrera.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                carrerasNegocio.AgregarCarrera(txtNombreCarrera.Text);

                MessageBox.Show("Carrera agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCarreras();
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
                    MessageBox.Show("Por favor, selecciona una carrera para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                carrerasNegocio.ActualizarCarrera(int.Parse(txtId.Text), txtNombreCarrera.Text);

                MessageBox.Show("Carrera actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarCarreras();
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
                    MessageBox.Show("Por favor, selecciona una carrera para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta carrera?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    carrerasNegocio.EliminarCarrera(int.Parse(txtId.Text));

                    MessageBox.Show("Carrera eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCarreras();
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
            CargarCarreras();
        }

        private void dgvCarreras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvCarreras.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombreCarrera.Text = dgvCarreras.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            }
        }
    }
}
