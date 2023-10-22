using ApiCentralPark.Data.Repositorio.Formatadores;
using ApiCentralPark.Database.Contexto;
using ApiCentralPark.Models;

namespace ApiCentralPark.Data.Repositorio
{
    public class VeiculoRepositorio
    {
        /////////////////////////////////////////////////////entrada
        public Veiculo EntradaDeVeiculo(string placa)
        {
            using (var banco = new CentalParkContext())
            {
                Veiculo veiculo = new Veiculo();

                veiculo.Placa = Formatador.FormatarPlaca(placa);
                //veiculo.HoraEntrada = DateTime.Now;
                veiculo.HoraEntrada = DateTime.Parse("2023 - 10 - 21 12:12:47.7053047");

                veiculo.HoraSaida = default;
                banco.VEICULOS.Add(veiculo);
                banco.SaveChanges();
                return veiculo;
            }
        }
        /////////////////////////////////////////////////////saida
        public Veiculo SaidaDeVeiculo(string placa, decimal valorTarifa, decimal valorAdicional)
        {

            using (var banco = new CentalParkContext())
            {


                var veiculo = ObterPorPlaca(Formatador.FormatarPlaca(placa));
                veiculo.HoraSaida = DateTime.Now;
               


                TimeSpan timeSpan = (TimeSpan)(veiculo.HoraSaida - veiculo.HoraEntrada);
                int totalDeMinutosEstacionados = (int)(timeSpan.TotalMinutes);
                
                if (totalDeMinutosEstacionados <= 30)
                {
                    veiculo.valor = valorTarifa / 2;
                    banco.VEICULOS.Update(veiculo);
                    banco.SaveChanges();
                    return veiculo;
                }
                decimal valorFinal = valorTarifa;
                int totalDeHoras = totalDeMinutosEstacionados / 60;
                int totalDeMinutos = totalDeMinutosEstacionados % 60;
                //totalDeHoras = 0;
               // totalDeMinutos = 31;
               
                if(totalDeMinutos > 10)
                {
                    totalDeHoras++;
                   
                }
                valorFinal += (totalDeHoras-1) * valorAdicional;

                veiculo.valor = valorFinal;
                             

                banco.VEICULOS.Update(veiculo);
                banco.SaveChanges();
                return veiculo;




            }
        }
        /////////////////////////////////////////////////////obter por placa
        public Veiculo ObterPorPlaca(string placa)
        {
            using (var banco = new CentalParkContext())
            {
                var veiculo = banco.VEICULOS.Where(x => x.Placa.ToUpper() == placa.ToUpper()).FirstOrDefault();

                return veiculo;
            }

        }
        /////////////////////////////////////////////////////obter por id
        public Veiculo ObterPorId(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var veiculo = banco.VEICULOS.Where(x => x.Id == id).FirstOrDefault();

                return veiculo;
            }
        }
        /////////////////////////////////////////////////////obter todos
        public List<Veiculo> ObterTodosVeiculos()
        {
            using (var banco = new CentalParkContext())
            {

                var listaveiculos = banco.VEICULOS.ToList();

                return listaveiculos;
            }

        }
        /////////////////////////////////////////////////////não sairam
        public List<Veiculo> ObterTodosQueNaoSairam()
        {
            using (var banco = new CentalParkContext())
            {

                var listaveiculos = banco.VEICULOS.Where(x => x.HoraSaida == null).ToList();

                return listaveiculos;
            }
        }
        /////////////////////////////////////////////////////já sairam
        public List<Veiculo> ObterTodosQueSairam()
        {
            using (var banco = new CentalParkContext())
            {

                var listaveiculos = banco.VEICULOS.Where(x => x.HoraSaida != null).ToList();

                return listaveiculos;
            }
        }
        /////////////////////////////////////////////////////já sairam
        public void Exluir(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var veiculo = banco.VEICULOS.Where(x => x.Id == id).FirstOrDefault();
                if (veiculo != null)
                {
                    banco.Remove(veiculo);
                    banco.SaveChanges();
                }
            }
        }
        /////////////////////////////////////////////////////existe placa
        public bool ExistePlaca(string placa)
        {
            using (var banco = new CentalParkContext())
            {
                var veiculo = banco.VEICULOS.Where(x => x.Placa.ToUpper() == placa.ToUpper()).FirstOrDefault();
                return veiculo != null;
            }
        }

    }
}
