using System.ComponentModel.DataAnnotations;

namespace Sistema_Buffer_BH.Models
{
    public class CaixaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a forma de pagamento")]
        public string Forma { get; set; }
        [Required(ErrorMessage = "Digite o valor")]
        public double Valor { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
