using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api_agua_ponto.Models
{
    public class SwaggerExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (context.Type == typeof(Usuario))
            {
                model.Example = new OpenApiObject
                {

                    ["email"] = new OpenApiString("string"),
                    ["senha"] = new OpenApiString("string"),
                    ["nome"] = new OpenApiString("string"),
                    ["sobrenome"] = new OpenApiString("string"),
                    ["dataNascimento"] = new OpenApiString("string"),
                    ["peso"] = new OpenApiDouble(0),
                    ["idade"] = new OpenApiInteger(0),
                    ["altura"] = new OpenApiDouble(0),
                    ["rotinaAcorda"] = new OpenApiString("string"),
                    ["rotinaDorme"] = new OpenApiString("string"),
                    ["mediaAgua"] = new OpenApiInteger(0),

                };
            }
            else if (context.Type == typeof(Rotina))
            {
                model.Example = new OpenApiObject
                {

                    ["mlIngerido"] = new OpenApiInteger(0),
                    ["usuarioId"] = new OpenApiInteger(0)

                };
            }
        }

    }
}
