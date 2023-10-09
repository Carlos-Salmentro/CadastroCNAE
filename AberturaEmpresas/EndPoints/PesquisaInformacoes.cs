using AberturaEmpresas.DBService;
using AberturaEmpresas.EndPoints.Requests;
using AberturaEmpresas.EndPoints.Responses;
using AberturaEmpresas.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AberturaEmpresas.EndPoints
{
    [Route("[Controller]")]
    public class PesquisaController : Controller
    {
        private readonly AppDBContext _context;

        public PesquisaController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IResult GetAll()
        {
            List<CNAE> cNAEs = new List<CNAE>(_context.CNAEs);
            List<Municipio> municipios = new List<Municipio>(_context.Municipios);

            return Results.Ok();
        }

        [HttpGet("CNAE/{idCnae}/Municipio/{idMunicipio}")]
        public IResult GetRelacao([FromRoute] string cnaeId, [FromRoute] string municipioNome)
        {
            CNAE cnae = _context.CNAEs.FirstOrDefault(x => x.Codigo == cnaeId);
            if (cnae == null)
                return Results.BadRequest();

            Municipio municipio = _context.Municipios.FirstOrDefault(x => x.Nome == municipioNome);
            if (municipio == null)
                return Results.BadRequest();

            CadastroEmpresa cadastro = _context.CadastroEmpresas.FirstOrDefault(x => x.CNAEId == cnaeId && x.MunicipioNome == municipioNome);
            if (cadastro == null)
                return Results.BadRequest();

            string IdCnae = string.Concat(cnaeId, municipioNome);
            List<string> documentosId = new List<string>(_context.DocCad.Where(x => x.CadastroId == IdCnae).Select(x => x.DocumentoId));
            List<string> nomeDocumentos = new List<string>();

            foreach (string docId in documentosId)
            {
                Documento documento = _context.Documentos.First(x => x.ID.ToString() == docId);
                nomeDocumentos.Add(docId);
            }

            PesquisaResponse response = new PesquisaResponse(cnae.Codigo, municipioNome, nomeDocumentos, cadastro.Online, cadastro.Site);
            return Results.Ok(response);

        }
    }
}
