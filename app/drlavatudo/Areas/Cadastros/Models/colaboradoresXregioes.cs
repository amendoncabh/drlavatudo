namespace app.drlavatudo.Areas.Cadastros.Models
{
    using System.ComponentModel.DataAnnotations;
    using app.drlavatudo.Areas.Parametros.Models;

    public partial class colaboradoresXregioes
    {
        [Key]
        public int codigo { get; set; }

        public int colaborador { get; set; }

        public int regiao { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual colaboradores colaboradores { get; set; }

        public virtual regioes regioes { get; set; }
    }
}
