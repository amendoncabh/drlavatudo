namespace app.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class unidades_medida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public unidades_medida()
        {
            produtos = new HashSet<produtos>();
        }

        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(21)]
        public string nome { get; set; }

        [Required]
        [StringLength(3)]
        public string grandeza { get; set; }

        [Required]
        [StringLength(6)]
        public string simbolo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal fator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<produtos> produtos { get; set; }
    }
}
