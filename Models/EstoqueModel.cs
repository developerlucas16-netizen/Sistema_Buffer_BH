using System.ComponentModel.DataAnnotations;

namespace Sistema_Buffer_BH.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Preço")]
        public double Preco {  get; set; }
        [Required(ErrorMessage = "Digite a Quantidade")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Digite o código")]
        public string Codigo { get; set; }
        public int Fornecedor_Id { get; set; }
        public FornecedorModel? Fornecedor { get; set; }
    }
}
