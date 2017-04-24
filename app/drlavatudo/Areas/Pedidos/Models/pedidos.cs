namespace ns.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pedidos()
        {
            agendamentos = new HashSet<agendamentos>();
            itens_pedido = new HashSet<itens_pedido>();
            pagamentos_pedido = new HashSet<pagamentos_pedido>();
        }

        [Key]
        public int codigo { get; set; }

        public int cliente { get; set; }

        public int vendedor { get; set; }

        public int lista_preco { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime registrado_em { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime valido_ate { get; set; }

        public decimal comissao { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agendamentos> agendamentos { get; set; }

        public virtual clientes clientes { get; set; }

        public virtual colaboradores colaboradores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itens_pedido> itens_pedido { get; set; }

        public virtual listas_preco listas_preco { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pagamentos_pedido> pagamentos_pedido { get; set; }
    }
}
