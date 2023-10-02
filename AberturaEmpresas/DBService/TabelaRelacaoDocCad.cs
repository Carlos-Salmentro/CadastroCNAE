using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AberturaEmpresas.DBService
{

    //Tabela para relacao NxN de Cadastro e Documentos
    [Table("DocCad")]
    public class TabelaRelacaoDocCad
    {
        [Column(Order = 0, TypeName = "CadastroId")]
        public string CadastroId { get; private set; }

        [Column(Order = 1, TypeName = "DocumentoId")]
        public string DocumentoId { get; private set; }

        public TabelaRelacaoDocCad (string cadastroId, string documentoId)
        {
            CadastroId = cadastroId;
            DocumentoId = documentoId;
        }
    }
}
