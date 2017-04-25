namespace app.drlavatudo.Areas.Pedidos.Models
{
    using System.ComponentModel.DataAnnotations;
    using app.drlavatudo.Areas.Parametros.Models;

    public partial class pagamentos_pedido
    {
        [Key]
        public int codigo { get; set; }

        public int pedido { get; set; }

        public int metodo { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual metodos_pagamento metodos_pagamento { get; set; }

        public virtual pedidos pedidos { get; set; }
    }
}
