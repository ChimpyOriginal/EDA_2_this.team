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
    public partial class FormsMaterias : Form
    {
        private MateriasNegocio materiasNegocio = new MateriasNegocio();

        public FormsMaterias()
        {
            InitializeComponent();
            CargarMaterias();
        }

        private void FormsMaterias_Load(object sender, EventArgs e)
        {

        }
        private void CargarMaterias()
        {
            dgvMaterias.DataSource = materiasNegocio.ObtenerMaterias();
        }
        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombreMateria.Text = string.Empty;
            numCreditos.Value = 0;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombreMateria.Text) || numCreditos.Value <= 0)
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                materiasNegocio.AgregarMateria(txtNombreMateria.Text, (int)numCreditos.Value);

                MessageBox.Show("Materia agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMaterias();
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
                    MessageBox.Show("Por favor, selecciona una materia para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                materiasNegocio.ActualizarMateria(int.Parse(txtId.Text), txtNombreMateria.Text, (int)numCreditos.Value);

                MessageBox.Show("Materia actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMaterias();
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
                    MessageBox.Show("Por favor, selecciona una materia para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta materia?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    materiasNegocio.EliminarMateria(int.Parse(txtId.Text));

                    MessageBox.Show("Materia eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarMaterias();
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
            CargarMaterias();
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvMaterias.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombreMateria.Text = dgvMaterias.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                numCreditos.Value = Convert.ToDecimal(dgvMaterias.Rows[e.RowIndex].Cells["Creditos"].Value);
            }
        }
    }
}
