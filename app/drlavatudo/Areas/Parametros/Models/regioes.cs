namespace app.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class regioes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public regioes()
        {
            colaboradoresXregioes = new HashSet<colaboradoresXregioes>();
        }

        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(30)]
        public string nome { get; set; }

        [Required]
        [StringLength(10)]
        public string codigo_postal_de { get; set; }

        [Required]
        [StringLength(10)]
        public string codigo_postal_ate { get; set; }

        [Required]
        [StringLength(60)]
        public string municipio { get; set; }

        [Required]
        [StringLength(2)]
        public string unidade_federativa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<colaboradoresXregioes> colaboradoresXregioes { get; set; }
    }
}
