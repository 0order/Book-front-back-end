namespace GerenciamentoLivros.Models
{
    public class Livro
    {
        public int Codigo { get; set; }
        public string NomeLivro { get; set; }
        public string NomeAutor { get; set; }
        public string Genero { get; set; }
        public int QtPaginas { get; set; }
        public string Editora { get; set; }
        public int AnoPublicacao { get; set; }


        public Livro() { }


        public Livro(int codigo,string nomeLivro,string nomeAutor, string genero, int qtPaginas, string editora, int anoPublicacao)
        {
            Codigo = codigo;
            NomeLivro = nomeLivro;
            NomeAutor = nomeAutor;
            Genero = genero;
            QtPaginas = qtPaginas;
            Editora = editora;
            AnoPublicacao = anoPublicacao;
        }
    }
}
