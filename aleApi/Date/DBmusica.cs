using aleApi.Conexion;
using aleApi.Model;
using System.Data;
using System.Data.SqlClient;

namespace aleApi.Date
    
{
    public class DBmusica
    {
        ConexionBD cb= new ConexionBD();
        public async Task <List<Musica>> ShowMusic()
        {
            var list = new List<Musica>();
            using (var sql = new SqlConnection(cb.stringSQL()))
            {
                using(var cmd = new SqlCommand("mostrarMusica",sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var musica = new Musica();
                            musica.id = (int)item["id"];
                            musica.titulo = (string)item["titulo"];
                            musica.descripcion = (string)item["descripcion"];
                            list.Add(musica);
                        }
                    }
                }               
            }
            return list;
        }

        public async Task InsertMusic(Musica parametros)
        {
            using(var sql = new SqlConnection(cb.stringSQL()))
            {
                using(var cmd = new SqlCommand("insertarMusica",sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@titulo", parametros.titulo);
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);                    
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditMusic(Musica parametros)
        {
            using (var sql = new SqlConnection(cb.stringSQL()))
            {
                using (var cmd = new SqlCommand("editarMusica", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task RemoveMusic(Musica parametros)
        {
            using (var sql = new SqlConnection(cb.stringSQL()))
            {
                using (var cmd = new SqlCommand("eliminarMusica", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
