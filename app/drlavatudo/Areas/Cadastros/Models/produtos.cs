namespace app.drlavatudo.Areas.Cadastros.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using app.drlavatudo.Areas.Parametros.Models;
    using app.drlavatudo.Areas.Pedidos.Models;

    public partial class produtos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public produtos()
        {
            itens_pedido = new HashSet<itens_pedido>();
            precos_produto = new HashSet<precos_produto>();
        }

        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(60)]
        public string nome { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descricao { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo { get; set; }

        public int categoria { get; set; }

        public int unidade_medida { get; set; }

        [Column(TypeName = "numeric")]
        public decimal quantidade { get; set; }

        [Column(TypeName = "money")]
        public decimal preco { get; set; }

        public decimal comissao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itens_pedido> itens_pedido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<precos_produto> precos_produto { get; set; }

        public virtual unidades_medida unidades_medida { get; set; }
    }
}
