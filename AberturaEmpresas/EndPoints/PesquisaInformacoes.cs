using AberturaEmpresas.DBService;
using AberturaEmpresas.EndPoints.Requests;
using AberturaEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AberturaEmpresas.EndPoints
{
    public class PesquisaInformacoes
    {
        public static string Template => "/InfoAbertura/Cnae{cnaeId}/Municipio{municipioNome}";
        public static string[] Methods = new string[] { HttpMethod.Get.ToString(), HttpMethod.Post.ToString(), HttpMethod.Delete.ToString(), HttpMethod.Put.ToString() };
        //public static Delegate Handler = Action;

        [HttpGet]
        public static IResult Action([FromRoute] string cnaeId, [FromRoute] string municipioNome, [FromServices] AppDBContext context)
        {
            

            return Results.Ok();

        }

        [HttpPost]
        public static IResult Action([FromBody] )
    }
}
