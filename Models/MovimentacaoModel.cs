namespace Sistema_Buffer_BH.Models
{
    public class MovimentacaoModel
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public CaixaModel Caixa { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; } // "Entrada" ou "Saída"
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
