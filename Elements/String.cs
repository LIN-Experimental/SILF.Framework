using SILF.Script.Elements.Functions;
using SILF.Script.Interfaces;
using SILF.Script.Objects;

namespace SILF.Framework.Elements;


internal class String
{

    /// <summary>
    /// Cargar métodos de string.
    /// </summary>
    public static IEnumerable<IFunction> Load()
    {

        // Trim.
        static FuncContext trim(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value")!.Value ?? "";
            cadena = cadena?.ToString()?.Trim() ?? "";

            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = cadena
                }
            };
        }

        // Upper.
        static FuncContext upper(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value")!.Value ?? "";
            cadena = cadena?.ToString()?.ToUpper() ?? "";

            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = cadena
                }
            };
        }

        // Trim.
        static FuncContext lower(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value")!.Value ?? "";
            cadena = cadena?.ToString()?.ToLower() ?? "";

            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = cadena
                }
            };
        }

        // Números.
        static FuncContext toNumber(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value")!.Value ?? "";

            _ = decimal.TryParse(cadena?.ToString(), out var value);

            return new FuncContext()
            {
                WaitType = new("number"),
                IsReturning = true,
                Value = new SILFNumberObject()
                {
                    Tipo = new("number"),
                    Value = value
                }
            };
        }


        // Lista.
        BridgeFunction[] functions =
        [
            new(trim)
            {
                Name = "trim",
                Type = new("string"),
                Parameters =
                [
                    new("value", new("string"))
                ]
            },
            new(upper)
            {
                Name = "upper",
                Type = new("string"),
                Parameters =
                [
                    new("value", new("string"))
                ]
            },
            new(lower)
            {
                Name = "lower",
                Type = new("string"),
                Parameters =
                [
                    new("value", new("string"))
                ]
            },
            new(toNumber)
            {
                Name = "toNumber",
                Type = new("number"),
                Parameters =
                [
                    new("value", new("string"))
                ]
            }
        ];

        return functions;

    }


}