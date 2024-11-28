using ControlEscolar.Datos;
using System;
using System.Data;

namespace ControlEscolar.Negocio
{
    public class GruposNegocio
    {
        private GruposDatos gruposDatos = new GruposDatos();

        public DataTable ObtenerGrupos()
        {
            return gruposDatos.ObtenerGrupos();
        }

        public void AgregarGrupo(string nombre, int maestroId, int materiaId)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El nombre del grupo es obligatorio.");
            }

            if (maestroId <= 0 || materiaId <= 0)
            {
                throw new ArgumentException("El maestro y la materia deben ser válidos.");
            }

            gruposDatos.AgregarGrupo(nombre, maestroId, materiaId);
        }

        public void ActualizarGrupo(int id, string nombre, int maestroId, int materiaId)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            gruposDatos.ActualizarGrupo(id, nombre, maestroId, materiaId);
        }

        public void EliminarGrupo(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido.");
            }

            gruposDatos.EliminarGrupo(id);
        }
    }
}
