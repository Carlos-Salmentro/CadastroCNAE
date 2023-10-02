using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AberturaEmpresas.Entities
{
    [Table("CNAEs")]
    public class CNAE
    {
        [Key]
        [Column("ID", Order = 0)]
        public string Codigo { get; private set; }
        [Column("Descricao", Order = 1)]
        public string Descricao { get; private set; }

        public CNAE(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }

}
