using AberturaEmpresas.DBService;
using AberturaEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AberturaEmpresas.EndPoints.Admin
{
    [Route("/admin/cnae{id}/municipio{nome}")]
    public class RelacaoCnaeMunicipio : Controller
    {
        //public static string Template => "/admin/cnae{id}/municipio{nome}";
        public static string[] Methods = new string[] { HttpMethod.Get.ToString(), HttpMethod.Post.ToString(), HttpMethod.Delete.ToString(), HttpMethod.Put.ToString() };

        //obtendo os documentos da relacao CNAE/Municipio em questao
        [HttpGet]
        public IResult Action([FromRoute] string id, [FromRoute] string nome, [FromServices] AppDBContext context)
        {
            CNAE cnae = context.CNAEs.First(x => x.Codigo == id);
            CadastroEmpresa cadastro = context.CadastroEmpresas.First(x => x.CNAEId.Equals(id) && x.MunicipioNome.Equals(nome));
            string[] doc = new string[] { context.DocCad.Where(x => x.CadastroId == cadastro.ID.ToString()).Select(x => x.DocumentoId).ToString() };

            List<Documento> documentos = new List<Documento>();

            foreach (string x in doc)
            {
                documentos.Add(context.Documentos.First(d => d.ID.ToString().Equals(x)));
            }

            return Results.Ok();
        }

        //adicionando documento ao cadastro
        [HttpPost]
        public async Task<IResult> Action([FromRoute] string id, [FromRoute] string nome, [FromBody] List<Documento> documentosAdd, [FromServices] AppDBContext context)
        {
            CadastroEmpresa cadastro = context.CadastroEmpresas.FirstOrDefault(x => x.CNAEId.Equals(id) && x.MunicipioNome.Equals(nome));
            List<Documento> listaDocumentos = new List<Documento>(context.Documentos.ToList());
            List<Documento> docJaExistente = new List<Documento>();
            List<Documento> docAdicionado = new List<Documento>();

            foreach (Documento doc in documentosAdd)
            {
                if (context.DocCad.FirstOrDefault(x => x.CadastroId.Equals(cadastro.ID) && x.DocumentoId.Equals(doc.ID)) == null)
                {
                    TabelaRelacaoDocCad aux = new TabelaRelacaoDocCad(cadastro.ID, doc.ID.ToString());
                    await context.DocCad.AddAsync(aux);

                    await context.SaveChangesAsync();
                    docAdicionado.Add(doc);
                }
                else
                {
                    docJaExistente.Add(doc);
                }
            }

            return Results.Ok();
        }



    }
}



