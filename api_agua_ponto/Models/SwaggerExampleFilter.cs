﻿using Microsoft.OpenApi.Any;
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
                    ["dataNascimento"] = new OpenApiDateTime(DateTime.Now),
                    ["peso"] = new OpenApiDouble(0),
                    ["idade"] = new OpenApiInteger(0),
                    ["rotinaAcorda"] = new OpenApiDateTime(DateTime.Now),
                    ["rotinaDorme"] = new OpenApiDateTime(DateTime.Now),
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
