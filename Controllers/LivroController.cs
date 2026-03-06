using GerenciamentoLivros.AcessoBanco;
using GerenciamentoLivros.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;



namespace GerenciamentoLivros.Controllers
{ 
    public class LivroController:Controller
    {
        private readonly ProdutoDAO produtoDAO = new ProdutoDAO();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            produtoDAO.Cadastrar(livro);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult Listar()
        {
            List<Livro> lista=produtoDAO.ListarTodos();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Excluir(int codigo)
        {
            produtoDAO.Excluir(codigo);
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Alterar(int codigo)
        {
            Livro livro = produtoDAO.ObterPorCodigo(codigo);
            return View("Index", livro);
        }

        [HttpPost]
        public IActionResult Alterar(Livro livro)
        {
            produtoDAO.Alterar(livro);
            return RedirectToAction("Listar");
        }

    }
}

