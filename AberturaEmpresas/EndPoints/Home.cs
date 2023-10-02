using AberturaEmpresas.DBService;
using Microsoft.AspNetCore.Mvc;

namespace AberturaEmpresas.EndPoints
{
    [Route("/home")]
    [ApiController]
    public class Home : Controller
    {
        //public static string Template => "/home";
        //public static string[] Methods => new string[] { HttpMethod.Post.ToString(), HttpMethod.Get.ToString(), HttpMethod.Delete.ToString(), HttpMethod.Put.ToString() };
        //public static Delegate Handler => Action;

        [HttpGet]
        public static IResult Action(AppDBContext context)
        {
            string mensagem = "Bem Vindo! Se você quer maior facilidade para abrir uma empresa está no lugar certo!";

            return Results.Ok(mensagem);
        }
    }
}