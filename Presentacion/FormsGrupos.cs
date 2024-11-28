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
    public partial class FormsGrupos : Form
    {
        private GruposNegocio gruposNegocio = new GruposNegocio();

        public FormsGrupos()
        {
            InitializeComponent();
            CargarGrupos();
            CargarMaestros();
            CargarMaterias();
        }

        private void FormsGrupos_Load(object sender, EventArgs e)
        {

        }
        private void CargarGrupos()
        {
            dgvGrupos.DataSource = gruposNegocio.ObtenerGrupos();
        }

        private void CargarMaestros()
        {
            var maestrosNegocio = new MaestrosNegocio();
            cmbMaestro.DataSource = maestrosNegocio.ObtenerMaestros();
            cmbMaestro.DisplayMember = "Nombre";
            cmbMaestro.ValueMember = "Id";
        }

        private void CargarMaterias()
        {
            var materiasNegocio = new MateriasNegocio();
            cmbMateria.DataSource = materiasNegocio.ObtenerMaterias();
            cmbMateria.DisplayMember = "Nombre";
            cmbMateria.ValueMember = "Id";
        }
        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombreGrupo.Text = string.Empty;
            cmbMaestro.SelectedIndex = -1;
            cmbMateria.SelectedIndex = -1;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombreGrupo.Text) || cmbMaestro.SelectedIndex == -1 || cmbMateria.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                gruposNegocio.AgregarGrupo(txtNombreGrupo.Text, (int)cmbMaestro.SelectedValue, (int)cmbMateria.SelectedValue);

                MessageBox.Show("Grupo agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrupos();
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
                    MessageBox.Show("Por favor, selecciona un grupo para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                gruposNegocio.ActualizarGrupo(int.Parse(txtId.Text), txtNombreGrupo.Text, (int)cmbMaestro.SelectedValue, (int)cmbMateria.SelectedValue);

                MessageBox.Show("Grupo actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrupos();
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
                    MessageBox.Show("Por favor, selecciona un grupo para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este grupo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    gruposNegocio.EliminarGrupo(int.Parse(txtId.Text));

                    MessageBox.Show("Grupo eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrupos();
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
            CargarGrupos();
        }

        private void dgvGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvGrupos.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombreGrupo.Text = dgvGrupos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                cmbMaestro.SelectedValue = dgvGrupos.Rows[e.RowIndex].Cells["MaestroId"].Value;
                cmbMateria.SelectedValue = dgvGrupos.Rows[e.RowIndex].Cells["MateriaId"].Value;
            }
        }
    }
}
