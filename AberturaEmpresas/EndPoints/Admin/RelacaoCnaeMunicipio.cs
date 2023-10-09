using AberturaEmpresas.DBService;
using AberturaEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AberturaEmpresas.EndPoints.Admin
{
    [Route("/admin/[Controller]")]
    public class RelacaoCnaeMunicipioController : Controller
    {
        private readonly AppDBContext context;
        public RelacaoCnaeMunicipioController(AppDBContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IResult GetAll()
        {
            List<Municipio> municipios = context.Municipios.ToList();
            List<CNAE> cnaes = context.CNAEs.ToList();

            return Results.Ok();
        }

        //obtendo os documentos da relacao CNAE/Municipio em questao
        [HttpGet("CNAE/{idCnae}/Municipio/{nomeMunicipio}")]
        public IResult GetRelacao([FromRoute] string idCnae, [FromRoute] string nomeMunicipio)
        {
            CNAE cnae = context.CNAEs.First(x => x.Codigo == idCnae);
            CadastroEmpresa cadastro = context.CadastroEmpresas.First(x => x.CNAEId == idCnae && x.MunicipioNome == nomeMunicipio);
            string[] doc = new string[] { context.DocCad.Where(x => x.CadastroId == cadastro.ID.ToString()).Select(x => x.DocumentoId).ToString() };

            List<Documento> documentos = new List<Documento>();

            foreach (string x in doc)
            {
                documentos.Add(context.Documentos.First(d => d.ID.ToString() == x));
            }

            return Results.Ok(documentos);
        }

        //adicionando documento ao cadastro
        [HttpPost("CNAE/{id}/Municipio/{nome}")]
        public async Task<IActionResult> AddDocumento([FromRoute] string id, [FromRoute] string nome, [FromBody] List<Documento> documentosAdd)
        {
            CadastroEmpresa cadastro = context.CadastroEmpresas.FirstOrDefault(x => x.CNAEId == id && x.MunicipioNome == nome);
            List<Documento> listaDocumentos = new List<Documento>(context.Documentos.ToList());
            List<Documento> docAdicionado = new List<Documento>();
            List<Documento> docJaExistente = new List<Documento>();
            StringBuilder sb = new StringBuilder();

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

            if (docAdicionado.Count > 0)
            {
                sb.AppendLine("Documentos adicionados:");
                foreach (Documento documento in docAdicionado)
                {
                    sb.AppendLine(documento.Nome);
                }

                sb.AppendLine();
            }

            if (docJaExistente.Count > 0)
            {
                sb.AppendLine("Documentos já existentes que não foram adicionados:");
                foreach (Documento documento in docJaExistente)
                {
                    sb.AppendLine(documento.Nome);
                }
            }

            return Ok(sb.ToString());

        }



    }
}



