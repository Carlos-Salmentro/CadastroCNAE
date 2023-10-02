using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AberturaEmpresas.Entities
{
    [Table("CadastrosEmpresa")]
    public class CadastroEmpresa
    {
        //Definido pelo CnaeId + MunicipioNome
        [Key]
        [Column(Order = 0, TypeName = "ID")]
        public string ID { get; set; }

        [ForeignKey("CNAEId")]
        [Column(Order = 1, TypeName = "CNAEId")]
        [Required]
        public string CNAEId { get; private set; }

        [ForeignKey("MunicipioNome")]
        [Column(Order = 2, TypeName = "MunicipioId")]
        [Required]
        public string MunicipioNome { get; private set; }

        [Column(Order = 3, TypeName = "Online")]
        [Required]
        public bool Online { get; private set; }

        [Column(Order = 4, TypeName = "Site")]
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
