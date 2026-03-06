using GerenciamentoLivros.AcessoBanco;
using MySql.Data.MySqlClient;
using GerenciamentoLivros.Models;


namespace GerenciamentoLivros.AcessoBanco
{
    public class ProdutoDAO
    {
        
        public void Cadastrar(Livro livro)
        {
            using (MySqlConnection conexao = Conexao.ObterConexao())
            {
                if (conexao != null)
                {
                    string sql = "INSERT INTO Livro(NomeLivro,NomeAutor,Genero,QtPaginas,Editora,AnoPublicacao) VALUES(@nomeLivro,@nomeAutor,@genero,@qtPaginas,@editora,@anoPublicacao)";
                    MySqlCommand cmd = new MySqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@nomelivro", livro.NomeLivro);
                    cmd.Parameters.AddWithValue("@nomeautor", livro.NomeAutor);
                    cmd.Parameters.AddWithValue("@genero", livro.Genero);
                    cmd.Parameters.AddWithValue("@qtpaginas", livro.QtPaginas);
                    cmd.Parameters.AddWithValue("@editora", livro.Editora);
                    cmd.Parameters.AddWithValue("@anopublicacao", livro.AnoPublicacao);
                    cmd.ExecuteNonQuery();

                }
            }

        }
        public List<Livro> ListarTodos()
        {
            List<Livro> lista = new List<Livro>();
            using (MySqlConnection conexao = Conexao.ObterConexao())
            {
                string sql = "SELECT * from Livro";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                using (var dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        lista.Add(new Livro
                        {
                            Codigo = dr.GetInt32("codigo"),
                            NomeLivro = dr.GetString("nomelivro"),
                            NomeAutor = dr.GetString("nomeautor"),
                            Genero = dr.GetString("genero"),
                            QtPaginas = dr.GetInt32("qtpaginas"),
                            Editora = dr.GetString("editora"),
                            AnoPublicacao = dr.GetInt32("anopublicacao")
                        });
                    }
                }
            }
            return lista;

        }
        public void Excluir(int codigo)
        {
            using (MySqlConnection conexao = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM Livro WHERE codigo = @codigo";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
            }
        }

        public Livro ObterPorCodigo(int codigo)
        {
            Livro livro = null;
            using (MySqlConnection conexao = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM Livro WHERE codigo = @codigo";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        livro = new Livro
                        {
                            Codigo = dr.GetInt32("codigo"),
                            NomeLivro = dr.GetString("nomelivro"),
                            NomeAutor = dr.GetString("nomeautor"),
                            Genero = dr.GetString("genero"),
                            QtPaginas = dr.GetInt32("qtpaginas"),
                            Editora = dr.GetString("editora"),
                            AnoPublicacao = dr.GetInt32("anopublicacao")
                        };
                    }
                }
            }
            return livro;
        }

        public void Alterar(Livro livro)
        {
            using (MySqlConnection conexao = Conexao.ObterConexao())
            {
                string sql = @"UPDATE Livro
                                SET nomelivro=@nomelivro,nomeautor=@nomeautor,genero=@genero,qtpaginas=@qtpaginas,editora=@editora,anopublicacao=@anopublicacao
                                WHERE codigo=@codigo";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@nomelivro", livro.NomeLivro);
                cmd.Parameters.AddWithValue("@nomeautor", livro.NomeAutor);
                cmd.Parameters.AddWithValue("@genero", livro.Genero);
                cmd.Parameters.AddWithValue("@qtpaginas", livro.QtPaginas);
                cmd.Parameters.AddWithValue("@editora", livro.Editora);
                cmd.Parameters.AddWithValue("@anopublicacao", livro.AnoPublicacao);
                cmd.Parameters.AddWithValue("@codigo", livro.Codigo);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
