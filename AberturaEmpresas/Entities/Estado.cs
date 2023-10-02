using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AberturaEmpresas.Entities
{
    [Table("Estados")]
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        [Column("Nome")]
        [Required]
        public string Nome { get; private set; }
        [Column("Sigla")]
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
