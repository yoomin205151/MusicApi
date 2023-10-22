namespace aleApi.Conexion
{
    public class ConexionBD
    {
        private string conexionString = string.Empty;
        public ConexionBD()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile
                ("appsettings.json").Build();

            conexionString = builder.GetConnectionString("masterConexion");
        }

        public string stringSQL()
        {
            return conexionString;
        }
    }
}
