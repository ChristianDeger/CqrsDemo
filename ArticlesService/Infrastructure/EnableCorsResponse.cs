using OpenRasta.Pipeline;
using OpenRasta.Web;

namespace ArticlesService.Infrastructure
{
    public class EnableCorsResponse : IPipelineContributor
    {
        public void Initialize(IPipeline pipelineRunner)
        {
            pipelineRunner.Notify(AddCorsResponseHeaders).Before<KnownStages.IResponseCoding>();
        }

        static PipelineContinuation AddCorsResponseHeaders(ICommunicationContext context)
        {
            context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, PUT, DELETE, OPTIONS";
            return PipelineContinuation.Continue;
        }
    }
}