using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AberturaEmpresas.Entities
{
    [Table("CadastrosEmpresa")]
    public class CadastroEmpresa
    {
        //Definido pelo CnaeId + MunicipioNome
        [Key]
        [Column("ID" ,Order = 0)]
        public string ID { get; set; }

        [ForeignKey("CNAEId")]
        [Column("CnaeID", Order = 1)]
        [Required]
        public string CNAEId { get; private set; }

        [ForeignKey("MunicipioNome")]
        [Column("MunicipioNome", Order = 2)]
        [Required]
        public string MunicipioNome { get; private set; }

        [Column("Online", Order = 3)]
        [Required]
        public bool Online { get; private set; }

        [Column("Site", Order = 4)]
        public string Site { get; private set; }

        public CadastroEmpresa(string cnaeId, string municipioNome, bool online, string? site)
        {
            ID = string.Concat(cnaeId, municipioNome);
            CNAEId = cnaeId;
            MunicipioNome = municipioNome;
            Online = online;

            if (online = true)
            {
                Site = site;
            }
        }
    }
}
