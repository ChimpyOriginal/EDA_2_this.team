using System;
using System.Data;
using System.Data.SqlClient;

namespace ControlEscolar.Datos
{
    public class CarrerasDatos
    {
        public DataTable ObtenerCarreras()
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Carreras";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public void AgregarCarrera(string nombre)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "INSERT INTO Carreras (Nombre) VALUES (@Nombre)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarCarrera(int id, string nombre)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "UPDATE Carreras SET Nombre = @Nombre WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCarrera(int id)
        {
            using (SqlConnection con = ConexionDB.GetConnection())
            {
                con.Open();
                string query = "DELETE FROM Carreras WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
