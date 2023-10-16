using ApiCentralPark.Database.Contexto;
using ApiCentralPark.Database.Repositorio.Helpers;
using ApiCentralPark.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCentralPark.Database.Repositorio
{
    public class VeiculoRepositorio
    {
        public Veiculo EntradaDeVeiculo( string placa)
        {
            using (var banco = new CentalParkContext())
            {
                Veiculo veiculo = new Veiculo();
                veiculo.Placa = Helper.RemoverCaracteres(placa);
                veiculo.Placa = Helper.FormatarPlaca(placa);
                veiculo.HoraEntrada = DateTime.Now;
                veiculo.HoraSaida = default;
                banco.VeiculosDatabase.Add(veiculo);
                banco.SaveChanges();
                return veiculo;
            }
        }
        public Veiculo SaidaDeVeiculo(Veiculo veiculo)
        {
            using (var banco = new CentalParkContext())
            {
                veiculo.Placa = Helper.FormatarPlaca(veiculo.Placa);
                banco.VeiculosDatabase.Update(veiculo);
                banco.SaveChanges();


            }
            return veiculo;
        }

        public List<Veiculo> ObterTodosVeiculos()
        {
            using (var banco = new CentalParkContext())
            {

                var listaveiculos = banco.VeiculosDatabase.ToList();

                return listaveiculos;
            }

        }
        public Veiculo ObterPorPlaca(string placa)
        {
            using (var banco = new CentalParkContext())
            {
                var veiculo = banco.VeiculosDatabase.Where(x => x.Placa.ToUpper() == placa.ToUpper()).FirstOrDefault();

                return veiculo;
            }

        }
        public List<Veiculo> ObterTodosQueNaoSairam()
        {
            using (var banco = new CentalParkContext())
            {

                var listaveiculos = banco.VeiculosDatabase.Where(x => x.HoraSaida == null).ToList();

                return listaveiculos;
            }
        }
        public List<Veiculo> ObterTodosQuejaSairam()
        {
            using (var banco = new CentalParkContext())
            {

                var listaveiculos = banco.VeiculosDatabase.Where(x => x.HoraSaida != null).ToList();

                return listaveiculos;
            }
        }
        public Veiculo ObterPorId(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var veiculo = banco.VeiculosDatabase.Where(x => x.Id == id).FirstOrDefault();

                return veiculo;
            }

        }
        public void Exluir(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var veiculo = banco.VeiculosDatabase.Where(x => x.Id == id).FirstOrDefault();
                if (veiculo != null)
                {
                    banco.Remove(veiculo);
                    banco.SaveChanges();
                }
            }
        }
    }
}
