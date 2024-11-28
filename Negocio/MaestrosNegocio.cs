using ControlEscolar.Datos;
using System;
using System.Data;

namespace ControlEscolar.Negocio
{
    public class MaestrosNegocio
    {
        private MaestrosDatos maestrosDatos = new MaestrosDatos();

        public DataTable ObtenerMaestros()
        {
            return maestrosDatos.ObtenerMaestros();
        }

        public void AgregarMaestro(string nombre, string apellido, string email, string telefono)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                throw new ArgumentException("El nombre y el apellido son obligatorios.");
            }

            if (!email.Contains("@"))
            {
                throw new ArgumentException("Email inválido.");
            }

            maestrosDatos.AgregarMaestro(nombre, apellido, email, telefono);
        }

        public void ActualizarMaestro(int id, string nombre, string apellido, string email, string telefono)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            maestrosDatos.ActualizarMaestro(id, nombre, apellido, email, telefono);
        }

        public void EliminarMaestro(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            maestrosDatos.EliminarMaestro(id);
        }
    }
}
