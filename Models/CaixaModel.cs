using System.ComponentModel.DataAnnotations;

namespace Sistema_Buffer_BH.Models
{
    public class CaixaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a forma de pagamento")]
        public DateTime Data { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal  ValorFinal { get; set; }
        public decimal TotalEntradas { get; set; }
        public decimal TotalSaidas { get; set; }
        public decimal Lucro { get; set; }
        public bool Status { get; set; }
        public  DateTime? DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public ICollection<MovimentacaoModel> Movimentacao { get; set; }
    }
}
