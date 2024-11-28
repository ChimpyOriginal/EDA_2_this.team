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
    public partial class FormsAlumnos : Form
    {
        private AlumnosNegocio alumnosNegocio = new AlumnosNegocio();

        public FormsAlumnos()
        {
            InitializeComponent();
            CargarCarreras(); 
            CargarAlumnos();   
        }

        private void FormsAlumnos_Load(object sender, EventArgs e)
        {

        }
        private void CargarCarreras()
        {
            var carrerasNegocio = new CarrerasNegocio();
            cmbCarrera.DataSource = carrerasNegocio.ObtenerCarreras();  
            cmbCarrera.DisplayMember = "Nombre"; 
            cmbCarrera.ValueMember = "Id";        
        }
        private void CargarAlumnos()
        {
            dgvAlumnos.DataSource = alumnosNegocio.ObtenerAlumnos();  
        }
        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            cmbCarrera.SelectedIndex = -1;  
            dtpFechaNacimiento.Value = DateTime.Today;  
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtMatricula.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alumnosNegocio.AgregarAlumno(txtNombre.Text, txtApellido.Text, txtMatricula.Text, (int)cmbCarrera.SelectedValue, dtpFechaNacimiento.Value);

                MessageBox.Show("Alumno agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAlumnos();  
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
                    MessageBox.Show("Por favor, selecciona un alumno para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                alumnosNegocio.ActualizarAlumno(int.Parse(txtId.Text), txtNombre.Text, txtApellido.Text, txtMatricula.Text, (int)cmbCarrera.SelectedValue, dtpFechaNacimiento.Value);

                MessageBox.Show("Alumno actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAlumnos();  
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
                    MessageBox.Show("Por favor, selecciona un alumno para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este alumno?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    
                    alumnosNegocio.EliminarAlumno(int.Parse(txtId.Text));

                    MessageBox.Show("Alumno eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAlumnos(); 
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
            CargarAlumnos(); 
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                
                txtId.Text = dgvAlumnos.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvAlumnos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvAlumnos.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtMatricula.Text = dgvAlumnos.Rows[e.RowIndex].Cells["Matricula"].Value.ToString();
                cmbCarrera.SelectedValue = dgvAlumnos.Rows[e.RowIndex].Cells["CarreraId"].Value;  
                dtpFechaNacimiento.Value = DateTime.Parse(dgvAlumnos.Rows[e.RowIndex].Cells["FechaNacimiento"].Value.ToString());
            }
        }
    }
}
