using ControlEscolar.Datos;
using System;
using System.Data;

namespace ControlEscolar.Negocio
{
    public class MateriasNegocio
    {
        private MateriasDatos materiasDatos = new MateriasDatos();

        public DataTable ObtenerMaterias()
        {
            return materiasDatos.ObtenerMaterias();
        }

        public void AgregarMateria(string nombre, int creditos)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre de la materia es obligatorio.");
            }

            if (creditos <= 0)
            {
                throw new ArgumentException("Los créditos deben ser mayores a 0.");
            }

            materiasDatos.AgregarMateria(nombre, creditos);
        }

        public void ActualizarMateria(int id, string nombre, int creditos)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            materiasDatos.ActualizarMateria(id, nombre, creditos);
        }

        public void EliminarMateria(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            materiasDatos.EliminarMateria(id);
        }
    }
}