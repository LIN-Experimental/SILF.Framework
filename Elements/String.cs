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

            var cadena = values.LastOrDefault(t => t.Name == "value")?.Objeto.GetValue();
            var final = cadena?.ToString()?.Trim() ?? "";

            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = final
                }
            };
        }

        // Upper.
        static FuncContext upper(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value")?.Objeto.GetValue();
            var final = cadena?.ToString()?.ToUpper() ?? "";

            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = final
                }
            };
        }

        // Trim.
        static FuncContext lower(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value")?.Objeto.GetValue();
            var final = cadena?.ToString()?.ToLower() ?? "";

            return new FuncContext()
            {
                WaitType = new("string"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("string"),
                    Value = final
                }
            };
        }

        // Números.
        static FuncContext toNumber(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value");

            _ = decimal.TryParse(cadena?.Objeto.Value?.ToString(), out var value);

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



    /// <summary>
    /// Cargar propiedades de string.
    /// </summary>
    public static IEnumerable<IProperty> LoadProperties()
    {

        // Count.
        static FuncContext count(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.FirstOrDefault(t=>t.Name == "parent");
            int count = cadena?.Objeto?.Value?.ToString()?.Length ?? 0;

            return new FuncContext()
            {
                WaitType = new("number"),
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = new("number"),
                    Value = count
                }
            };
        }

        // Lista.
        BridgeProperty[] functions =
        [
            new BridgeProperty("count", new("number"))
            {
                Get = new BridgeFunction(count)
            }
        ];

        return functions;

    }


}