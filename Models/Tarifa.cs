namespace ApiCentralPark.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }
        public decimal ValorTarifa { get; set; }
        public decimal ValorAdicional { get; set; }
        public int QuantidadeDeVagas { get; set; }
    }
}
