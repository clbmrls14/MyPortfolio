using Microsoft.AspNetCore.Routing;

namespace MyPortfolio.Shared
{
    public class SlugParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            return value?.ToString().ToSlug();
        }
    }
}
