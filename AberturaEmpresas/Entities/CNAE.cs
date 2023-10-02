using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AberturaEmpresas.Entities
{
    [Table("CNAEs")]
    public class CNAE
    {
        [Key]
        [Column("ID")]
        public string Codigo { get; private set; }
        [Column("Descricao")]
        public string Descricao { get; private set; }

        public CNAE(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }

}
