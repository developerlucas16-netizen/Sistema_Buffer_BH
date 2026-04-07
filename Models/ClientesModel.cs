using System.ComponentModel.DataAnnotations;

namespace Sistema_Buffer_BH.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Telefone")]
        public string Telefone  { get; set; }
        [Required(ErrorMessage = "Digite o CPF")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite o Email")]
        public string Email  { get; set; }

    }
}
