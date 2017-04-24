namespace app.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class agendamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agendamentos()
        {
            itens_agendamento = new HashSet<itens_agendamento>();
        }

        [Key]
        public int codigo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime quando { get; set; }

        [Column(TypeName = "numeric")]
        public decimal duracao { get; set; }

        public int pedido { get; set; }

        [Column(TypeName = "text")]
        public string complemento { get; set; }

        public int atendente { get; set; }

        public int responsavel { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual colaboradores colaboradores { get; set; }

        public virtual pedidos pedidos { get; set; }

        public virtual colaboradores colaboradores1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itens_agendamento> itens_agendamento { get; set; }
    }
}
