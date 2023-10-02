using AberturaEmpresas.Entities;
using Microsoft.EntityFrameworkCore;


namespace AberturaEmpresas.DBService
{
    public class AppDBContext : DbContext
    {
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet <CNAE> CNAEs { get; set; }
        public DbSet<CadastroEmpresa> CadastroEmpresas { get; set; }
        public DbSet<TabelaRelacaoDocCad> DocCad { get; set; }

    }
}
