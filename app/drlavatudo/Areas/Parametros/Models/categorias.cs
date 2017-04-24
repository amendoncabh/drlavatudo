namespace ns.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class categorias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categorias()
        {
            categorias1 = new HashSet<categorias>();
            clientes = new HashSet<clientes>();
            colaboradores = new HashSet<colaboradores>();
            listas_preco = new HashSet<listas_preco>();
        }

        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo { get; set; }

        [Required]
        [StringLength(30)]
        public string nome { get; set; }

        public int? codigo_pai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<categorias> categorias1 { get; set; }

        public virtual categorias categorias2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clientes> clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<colaboradores> colaboradores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<listas_preco> listas_preco { get; set; }
    }
}
