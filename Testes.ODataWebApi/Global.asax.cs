using System.Web.Http;
using AutoMapper;
using Testes.ODataWebApi.Models;

namespace Testes.ODataWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (var ctx = new Contexto())
            {
                if (!ctx.Database.Exists())
                {
                    ctx.Database.Initialize(true);
                    for (int i = 0; i < 100; i++)
                    {
                        ctx.Pessoas.Add(new Pessoa() { Nome = $"Pessoa {i}" });
                    }
                    ctx.SaveChanges();
                }
            }

            Mapper.Initialize(c => c.AddProfile<PessoaProfile>());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }

    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>()
                .ForMember(r => r.Identidade, de => de.MapFrom(e => e.Id))
                .ForMember(r => r.NomeCompleto, de => de.MapFrom(e => e.Nome));
        }
    }

    public class PessoaViewModel
    {
        public int Identidade { get; set; }
        public string NomeCompleto { get; set; }
    }
}
