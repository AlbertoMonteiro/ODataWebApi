using System.Web.Http;
using System.Web.Routing;
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

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
