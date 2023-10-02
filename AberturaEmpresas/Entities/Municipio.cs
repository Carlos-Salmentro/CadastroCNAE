using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AberturaEmpresas.Entities
{
    [Table("Municipios")]
    public class Municipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        [Column("Nome")]
        [Required]
        public string Nome { get; private set; }
        [Column("EstadoId")]
        [ForeignKey("EstadoId")]
        [Required]
        public int EstadoId { get; private set; }

        public Municipio(string nome, int estadoId)
        {
            Nome = nome;
            EstadoId = estadoId;
        }
    }
}
