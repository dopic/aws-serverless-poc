using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.AspNetCoreServer;
using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;

namespace api.Handlers
{
    public class ApiGatewayHandler : APIGatewayProxyFunction
    {
        protected override void Init(IWebHostBuilder builder) => builder.UseStartup<Startup>();

        protected override void PostMarshallRequestFeature(IHttpRequestFeature aspNetCoreRequestFeature, APIGatewayProxyRequest lambdaRequest, ILambdaContext lambdaContext)
        {
            lambdaContext.Logger.LogLine($"Path: {aspNetCoreRequestFeature.Path}, PathBase: {aspNetCoreRequestFeature.PathBase}");
        }
    }
}