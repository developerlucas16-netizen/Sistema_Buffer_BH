using System.ComponentModel.DataAnnotations;

namespace Sistema_Buffer_BH.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }
    }
}
