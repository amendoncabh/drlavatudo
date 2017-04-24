namespace app.drlavatudo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class colaboradoresXregioes
    {
        [Key]
        public int codigo { get; set; }

        public int colaborador { get; set; }

        public int regiao { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual colaboradores colaboradores { get; set; }

        public virtual regioes regioes { get; set; }
    }
}
