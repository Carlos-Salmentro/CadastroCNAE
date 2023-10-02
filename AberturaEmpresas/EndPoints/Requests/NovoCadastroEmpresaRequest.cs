namespace AberturaEmpresas.EndPoints.Requests
{
    public record NovoCadastroEmpresaRequest(string codigoCnae, string nomeMunicipio, bool online, string? site);
}
