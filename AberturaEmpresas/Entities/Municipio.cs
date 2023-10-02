using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AberturaEmpresas.Entities
{
    [Table("Municipios")]
    public class Municipio
    {
        [Key]
        [Column("ID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        
        [Column("Nome", Order = 1)]
        [Required]
        public string Nome { get; private set; }
        
        [Column("EstadoId", Order = 2)]
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
