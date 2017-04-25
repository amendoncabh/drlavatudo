namespace app.drlavatudo.Areas.Pedidos.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class itens_agendamento
    {
        [Key]
        public int codigo { get; set; }

        public int agenda { get; set; }

        public int procedimento { get; set; }

        [Column(TypeName = "text")]
        public string complemento { get; set; }

        [Required]
        [StringLength(1)]
        public string situacao { get; set; }

        public virtual agendamentos agendamentos { get; set; }

        public virtual itens_pedido itens_pedido { get; set; }
    }
}
