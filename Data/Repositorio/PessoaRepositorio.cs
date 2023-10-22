using ApiCentralPark.Data.Repositorio.Formatadores;
using ApiCentralPark.Database.Contexto;
using ApiCentralPark.Models;

namespace ApiCentralPark.Database.Repositorio
{
    public class PessoaRepositorio
    {
        public Pessoa Add(Pessoa pessoa)
        {
            using (var banco = new CentalParkContext())
            {
                pessoa.Nome = Formatador.RemoverCaracteres(pessoa.Nome);
                pessoa.Nome = Formatador.TitleCase(pessoa.Nome);
                banco.PESSOAS.Add(pessoa);
                banco.SaveChanges();
            }
            return pessoa;
        }

        public Pessoa Edit(Pessoa pessoa)
        {
            using (var banco = new CentalParkContext())
            {
                pessoa.Nome = Formatador.RemoverCaracteres(pessoa.Nome);
                pessoa.Nome = Formatador.TitleCase(pessoa.Nome);
                banco.PESSOAS.Update(pessoa);
                banco.SaveChanges();
            }
            return pessoa;
        }

        public void Del(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var pessoa = banco.PESSOAS.Where(pessoa => pessoa.Id == id).FirstOrDefault();
                if (pessoa != null)
                {
                    banco.Remove(pessoa);
                    banco.SaveChanges();
                }
            }
        }

        public List<Pessoa> ObterTodos()
        {
            using (var banco = new CentalParkContext())
            {
                {
                    var listaPessoas = banco.PESSOAS.ToList();
                    return listaPessoas;
                }
            }
        }

        public Pessoa ObterPorId(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var pessoa = banco.PESSOAS
                    .Where(pessoa => pessoa.Id == id)
                    .FirstOrDefault();

                return pessoa;
            }
        }
    }
}