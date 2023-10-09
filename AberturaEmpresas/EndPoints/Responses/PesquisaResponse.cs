namespace AberturaEmpresas.EndPoints.Responses
{
    public record PesquisaResponse(string cnaeCodigo, string municipioNome, List<string> documentoNome, bool online, string? site);
    
}
