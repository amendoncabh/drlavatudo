namespace app.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class metodos_pagamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public metodos_pagamento()
        {
            pagamentos_pedido = new HashSet<pagamentos_pedido>();
        }

        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(30)]
        public string nome { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo { get; set; }

        [StringLength(3)]
        public string prefixo { get; set; }

        [StringLength(3)]
        public string sufixo { get; set; }

        public int? termo { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pagamentos_pedido> pagamentos_pedido { get; set; }
    }
}
