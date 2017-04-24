namespace app.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class itens_pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public itens_pedido()
        {
            itens_agendamento = new HashSet<itens_agendamento>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codigo { get; set; }

        public int pedido { get; set; }

        public int produto { get; set; }

        [Column(TypeName = "numeric")]
        public decimal quantidade { get; set; }

        [Column(TypeName = "money")]
        public decimal preco { get; set; }

        [Column(TypeName = "money")]
        public decimal valor { get; set; }

        public decimal comissao { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itens_agendamento> itens_agendamento { get; set; }

        public virtual pedidos pedidos { get; set; }

        public virtual produtos produtos { get; set; }
    }
}
