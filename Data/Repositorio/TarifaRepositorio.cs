using ApiCentralPark.Database.Contexto;
using ApiCentralPark.Models;

namespace ApiCentralPark.Data.Repositorio
{
    public class TarifaRepositorio
    {

        public Tarifa Editar(Tarifa tarifa)
        {
            using (var banco = new CentalParkContext())
            {
                tarifa.Id = 1;
                banco.TARIFAS.Update(tarifa);
                banco.SaveChanges();
                return tarifa;

            }
        }
        public Tarifa ObterValores()
        {
            using (var banco = new CentalParkContext())
            {
                var tarifa = banco.TARIFAS.Where(u => u.Id == 1).FirstOrDefault();
                return tarifa;
            }
        }


    }
}

