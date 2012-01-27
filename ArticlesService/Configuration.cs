using OpenRasta.Configuration;
using OpenRasta.Web;

namespace ArticlesService
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType<HomeResource>()
                    .AtUri("/")
                    .HandledBy<HomeHandler>()
                    .AsJsonDataContract().ForMediaType(MediaType.Json);
            }
        }
    }
}