namespace app.drlavatudo.Areas.Cadastros.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class precos_produto
    {
        [Key]
        public int codigo { get; set; }

        public int lista_preco { get; set; }

        public int produto { get; set; }

        [Required]
        [StringLength(1)]
        public string fator { get; set; }

        [Column(TypeName = "numeric")]
        public decimal valor { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual listas_preco listas_preco { get; set; }

        public virtual produtos produtos { get; set; }
    }
}
