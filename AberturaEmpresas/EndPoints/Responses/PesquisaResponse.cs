namespace AberturaEmpresas.EndPoints.Responses
{
    public record PesquisaResponse(string cnaeId, string municipioNome, List<string> documentoId, bool online, string site);
    
}
