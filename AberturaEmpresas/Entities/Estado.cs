using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AberturaEmpresas.Entities
{
    [Table("Estados")]
    public class Estado
    {
        [Key]
        [Column("ID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        
        [Column("Nome", Order = 1)]
        [Required]
        public string Nome { get; private set; }
        
        [Column("Sigla", Order = 2)]
        [Required]
        [MaxLength(2)]
        public string Sigla { get; private set; }

        public Estado(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
    }
}
