using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebAppBase.Shared.Results;

namespace WebAppBase.Shared.Swagger;

public class EnvelopFailResultExampleSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if(context.Type != typeof(EnvelopFailResult))return;
            
        schema.Example = new OpenApiObject
        {
            [ "errors" ] = new OpenApiArray
            {
                new OpenApiString("Some error")
            },
            [ "success" ] = new OpenApiBoolean(false)
        };
    }
}