using AberturaEmpresas.DBService;
using AberturaEmpresas.EndPoints.Requests;
using AberturaEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AberturaEmpresas.EndPoints.Admin
{
    //[Produces("application/json")]
    [Route("/admin/cadastro-cnae-municipio")]
    public class CadastroRelacaoCnaeMunicipio : Controller
    {
        //private readonly AppDBContext _context;
        //public static string[] Methods = new string[] { HttpMethod.Get.ToString(), HttpMethod.Post.ToString(), HttpMethod.Delete.ToString(), HttpMethod.Put.ToString() };

        [HttpGet]
        public IResult Action([FromServices] AppDBContext context)
        {
            List<CadastroEmpresa> cadastros = context.CadastroEmpresas.ToList();
            return Results.Ok(cadastros);
        }

        [HttpPost]
        public async Task<IResult> Action([FromBody] NovoCadastroEmpresaRequest novoCadastro, [FromServices] AppDBContext context)
        {
            Municipio municipio = context.Municipios.FirstOrDefault(x => x.Nome == novoCadastro.nomeMunicipio);
            if (municipio == null)
            {
                return Results.NotFound(novoCadastro.nomeMunicipio.ToString());
            }

            CNAE cnae = context.CNAEs.FirstOrDefault(x => x.Codigo == novoCadastro.codigoCnae);
            if (cnae == null)
            {
                return Results.NotFound(novoCadastro.codigoCnae.ToString());
            }

            CadastroEmpresa cadastroEmpresa = context.CadastroEmpresas.FirstOrDefault(x => x.CNAEId == cnae.Codigo && x.MunicipioNome == municipio.ID.ToString());
            if (cadastroEmpresa != null)
            {
                return Results.BadRequest("Já há um cadastro referente ao CNAE " + cadastroEmpresa.CNAEId + " atrelado ao município " + municipio.Nome + ". Não pode haver duplicatas.");
            }

            CadastroEmpresa novoCadastroEmpresa = new CadastroEmpresa(novoCadastro.codigoCnae, municipio.ID.ToString(), novoCadastro.online, novoCadastro.site);
            await context.CadastroEmpresas.AddAsync(novoCadastroEmpresa);
            await context.SaveChangesAsync();

            return Results.RedirectToRoute();
        }
    }
}
