using ArticlesService.List;

using OpenRasta.Configuration;
using OpenRasta.Web;

namespace ArticlesService
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            new Bootstrapper();

            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType<HomeResource>()
                    .AtUri("/")
                    .HandledBy<HomeHandler>()
                    .AsJsonDataContract().ForMediaType(MediaType.Json);

                ResourceSpace.Has.ResourcesOfType<ArticlesListResource>()
                    .AtUri("/articles")
                    .HandledBy<ArticlesListHandler>()
                    .AsJsonDataContract().ForMediaType(MediaType.Json);
            }
        }
    }
}