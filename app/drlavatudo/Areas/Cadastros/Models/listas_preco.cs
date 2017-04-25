namespace app.drlavatudo.Areas.Cadastros.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using app.drlavatudo.Areas.Parametros.Models;
    using app.drlavatudo.Areas.Pedidos.Models;

    public partial class listas_preco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public listas_preco()
        {
            pedidos = new HashSet<pedidos>();
            precos_produto = new HashSet<precos_produto>();
        }

        [Key]
        public int codigo { get; set; }

        [Required]
        [MaxLength(30)]
        public byte[] nome { get; set; }

        [Column(TypeName = "text")]
        public string descricao { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo { get; set; }

        public int categoria { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime validade_de { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime validade_ate { get; set; }

        [Column(TypeName = "text")]
        public string condicao { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual categorias categorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidos> pedidos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<precos_produto> precos_produto { get; set; }
    }
}
