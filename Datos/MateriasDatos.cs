using System;
using System.Data;
using System.Data.SqlClient;

namespace ControlEscolar.Datos
{
    public class MateriasDatos
    {
        public DataTable ObtenerMaterias()
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Materias";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void AgregarMateria(string nombre, int creditos)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Materias (Nombre, Creditos) VALUES (@Nombre, @Creditos)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Creditos", creditos);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarMateria(int id, string nombre, int creditos)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "UPDATE Materias SET Nombre = @Nombre, Creditos = @Creditos WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Creditos", creditos);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarMateria(int id)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Materias WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}