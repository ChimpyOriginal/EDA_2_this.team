using EDA2.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormsAlumnos formAlumnos = new FormsAlumnos();
            formAlumnos.Show();  // Mostrar el formulario de Alumnos
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MaestrosForms formMaestros = new MaestrosForms();
            formMaestros.Show();  // Mostrar el formulario de Maestros
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormsMaterias formMaterias = new FormsMaterias();
            formMaterias.Show();  // Mostrar el formulario de Materias
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormsGrupos formGrupos = new FormsGrupos();
            formGrupos.Show();  // Mostrar el formulario de Grupos
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormsCarreras formCarreras = new FormsCarreras();
            formCarreras.Show();  // Mostrar el formulario de Carreras
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Confirmación para salir del programa
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
                Application.Exit();
            }
        }
    }
}
