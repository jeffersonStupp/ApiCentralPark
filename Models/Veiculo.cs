namespace ApiCentralPark.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSaida { get; set; }
        public decimal? valor { get; set; }
        public bool Finalizado { get; set; }
    }
}
