using MySql.Data.MySqlClient;

namespace GerenciamentoLivros.AcessoBanco
{
    public class Conexao
    {
        public static MySqlConnection ObterConexao()
        {
            string strCon = "server=localhost;database=livrobd;user=;password=";
            MySqlConnection con = new MySqlConnection(strCon);

            try
            {
                Console.WriteLine("Conectado com Sucesso!!!!");
                con.Open();
                return con;

            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao conectar ao banco de dados:" + ex.Message);    
            }
        }
    }
}
