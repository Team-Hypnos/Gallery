namespace TownSystem.Services
{
    using System.Reflection;
    using System.Web;
    using System.Web.Http;
    using Common.Constants;
    using Newtonsoft.Json;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
