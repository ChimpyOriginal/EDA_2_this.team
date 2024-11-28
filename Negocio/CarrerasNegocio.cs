using ControlEscolar.Datos;
using System;
using System.Data;

namespace ControlEscolar.Negocio
{
    public class CarrerasNegocio
    {
        private CarrerasDatos carrerasDatos = new CarrerasDatos();

        public DataTable ObtenerCarreras()
        {
            return carrerasDatos.ObtenerCarreras();
        }

        public void AgregarCarrera(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre de la carrera es obligatorio.");
            }

            carrerasDatos.AgregarCarrera(nombre);
        }

        public void ActualizarCarrera(int id, string nombre)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            carrerasDatos.ActualizarCarrera(id, nombre);
        }

        public void EliminarCarrera(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            carrerasDatos.EliminarCarrera(id);
        }
    }
}
