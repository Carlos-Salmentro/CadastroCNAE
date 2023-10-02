using AberturaEmpresas.DBService;
using AberturaEmpresas.EndPoints.Requests;
using AberturaEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AberturaEmpresas.EndPoints.Admin
{
    [Route("/admin/CNAEs")]
    public class CNAEs : Controller
    {
        //public static string Template => "/admin/CNAEs";
        public static string[] Methods = new string[] { HttpMethod.Get.ToString(), HttpMethod.Post.ToString(), HttpMethod.Delete.ToString(), HttpMethod.Put.ToString() };
        //public static Delegate Handler => Action;

        [HttpGet]
        public IResult Action([FromServices]AppDBContext context)
        {
            List<CNAE> cnaes = context.CNAEs.OrderBy(x => x.Codigo).ToList();
            return Results.Ok(cnaes);
        }

        [HttpPost]
        public async Task<IResult> Action([FromBody] CnaeAddRequest cnaeAddRequest, [FromServices]AppDBContext context)
        {
            if (context.CNAEs.FirstOrDefault(x => x.Codigo == cnaeAddRequest.codigo) != null)
            {
                return Results.BadRequest("Já existe um CNAE com esse código cadastrado. Não é possível haver duplicatas.");
            }

            await context.CNAEs.AddAsync(new CNAE(cnaeAddRequest.codigo, cnaeAddRequest.descricao));
            await context.SaveChangesAsync();

            return Results.Ok("Codigo CNAE adicionado ao sistema."); //Alterar para Created posteriormente
        }

        [HttpDelete]
        public IResult Action([FromBody]string codigo, [FromServices]AppDBContext context)
        {
            CNAE cnae = context.CNAEs.FirstOrDefault(x => x.Codigo == codigo);
            
            if(cnae == null)
            {
                return Results.BadRequest("Nenhum CNAE encontrado com o código " + codigo);
            }

            //Alertar que o CNE será deletado
            //Se a resposta for sim

            context.CNAEs.Remove(cnae);
            return Results.Ok("O CNAE de código " + codigo + " foi removido permanentemente do sistema.");
        }
    }
}
