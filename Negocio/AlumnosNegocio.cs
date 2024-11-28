using ControlEscolar.Datos;
using System;
using System.Data;

namespace ControlEscolar.Negocio
{
    public class AlumnosNegocio
    {
        private AlumnosDatos alumnosDatos = new AlumnosDatos();

        public DataTable ObtenerAlumnos()
        {
            return alumnosDatos.ObtenerAlumnos();
        }

        public void AgregarAlumno(string nombre, string apellido, string matricula, int carreraId, DateTime fechaNacimiento)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                throw new ArgumentException("El nombre y el apellido son obligatorios.");
            }

            alumnosDatos.AgregarAlumno(nombre, apellido, matricula, carreraId, fechaNacimiento);
        }

        public void ActualizarAlumno(int id, string nombre, string apellido, string matricula, int carreraId, DateTime fechaNacimiento)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            alumnosDatos.ActualizarAlumno(id, nombre, apellido, matricula, carreraId, fechaNacimiento);
        }

        public void EliminarAlumno(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            alumnosDatos.EliminarAlumno(id);
        }
    }
}