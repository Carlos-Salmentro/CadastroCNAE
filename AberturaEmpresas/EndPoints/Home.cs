using AberturaEmpresas.DBService;
using Microsoft.AspNetCore.Mvc;

namespace AberturaEmpresas.EndPoints
{
    [Route("/[Controller")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public static IResult Action()
        {
            string mensagem = "Bem Vindo! Se você quer maior facilidade para abrir uma empresa está no lugar certo!";

            return Results.Ok(mensagem);
        }
    }
}