using SILF.Script.Elements.Functions;
using SILF.Script.Interfaces;
using SILF.Script.Objects;

namespace SILF.Framework.Elements;


internal class Framework
{

    /// <summary>
    /// Cargar métodos del framework.
    /// </summary>
    public static IEnumerable<IFunction> Load()
    {

        // Version.
        static FuncContext version(List<Script.Elements.ParameterValue> values)
        {
            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = "SILF Framework for .NET"
                }
            };
        }


        // Type.
        static FuncContext type(List<Script.Elements.ParameterValue> values)
        {

            var value = values.LastOrDefault(t => t.Name == "value")!;

            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = $"<{value?.Tipo.Description ?? "non type"}>",
                }
            };
        }



        // Lista.
        BridgeFunction[] functions =
        [
            new(version)
            {
                Name = "version",
                Type = new("string"),
                Parameters = []
            },
            new(type)
            {
                Name = "type",
                Type = new("string"),
                Parameters = 
                [
                    new("value", new("mutable"))
                ]
            },
        ];

        return functions;

    }


}