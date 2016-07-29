using System.Data.Entity;

namespace Testes.ODataWebApi.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Contexto : DbContext
    {
        public Contexto()
            :base(@"Data source=.\sqlexpress;Initial Catalog=OdataSample;Integrated Security=true")
        {
            
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}