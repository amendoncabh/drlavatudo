namespace app.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            pedidos = new HashSet<pedidos>();
        }

        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo { get; set; }

        public int categoria { get; set; }

        [Required]
        [StringLength(1)]
        public string eh_empresa { get; set; }

        [Required]
        [StringLength(14)]
        public string cpf_cnpj { get; set; }

        [StringLength(120)]
        public string logradouro { get; set; }

        [StringLength(30)]
        public string bairro { get; set; }

        [StringLength(60)]
        public string municipio { get; set; }

        [StringLength(10)]
        public string codigo_postal { get; set; }

        [StringLength(2)]
        public string unidade_federativa { get; set; }

        [StringLength(30)]
        public string pais { get; set; }

        [StringLength(240)]
        public string email { get; set; }

        [StringLength(15)]
        public string telefone_fixo { get; set; }

        [StringLength(15)]
        public string telefone_movel { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual categorias categorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedidos> pedidos { get; set; }
    }
}
