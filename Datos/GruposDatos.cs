using System;
using System.Data;
using System.Data.SqlClient;

namespace ControlEscolar.Datos
{
    public class GruposDatos
    {
        public DataTable ObtenerGrupos()
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = @"
                    SELECT Grupos.Id, Grupos.Nombre, Maestros.Nombre AS Maestro, Materias.Nombre AS Materia
                    FROM Grupos
                    INNER JOIN Maestros ON Grupos.MaestroId = Maestros.Id
                    INNER JOIN Materias ON Grupos.MateriaId = Materias.Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void AgregarGrupo(string nombre, int maestroId, int materiaId)
        {

            if (!VerificarExistencia("Maestros", maestroId) || !VerificarExistencia("Materias", materiaId))
            {
                throw new ArgumentException("El maestro o la materia no existen.");
            }

            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Grupos (Nombre, MaestroId, MateriaId) VALUES (@Nombre, @MaestroId, @MateriaId)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@MaestroId", maestroId);
                    cmd.Parameters.AddWithValue("@MateriaId", materiaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarGrupo(int id, string nombre, int maestroId, int materiaId)
        {

            if (!VerificarExistencia("Maestros", maestroId) || !VerificarExistencia("Materias", materiaId))
            {
                throw new ArgumentException("El maestro o la materia no existen.");
            }

            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "UPDATE Grupos SET Nombre = @Nombre, MaestroId = @MaestroId, MateriaId = @MateriaId WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@MaestroId", maestroId);
                    cmd.Parameters.AddWithValue("@MateriaId", materiaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarGrupo(int id)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Grupos WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool VerificarExistencia(string tabla, int id)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = $"SELECT COUNT(1) FROM {tabla} WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
