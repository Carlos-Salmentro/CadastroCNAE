using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AberturaEmpresas.Entities
{
    [Table("Documentos")]
    public class Documento
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; private set; }
        
        [Column(Order = 1, TypeName = "Nome")]
        [Required]
        public string Nome { get; private set; }

        public Documento(string nome)
        {
            Nome = nome;
        }
    }
}
