using SILF.Script.Elements.Functions;
using SILF.Script.Interfaces;
using SILF.Script.Objects;

namespace SILF.Framework.Elements;


internal class Number
{

    /// <summary>
    /// Cargar métodos de Number.
    /// </summary>
    public static IEnumerable<IFunction> Load()
    {

        // Trim.
        static FuncContext toString(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value");

           var final = cadena?.Objeto.Value.ToString()?.Trim() ?? "";

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


        // Lista.
        BridgeFunction[] functions =
        [
            new(toString)
            {
                Name = "toString",
                Type = new("string"),
                Parameters =
                [
                    new("value", new("number"))
                ]
            }
        ];

        return functions;

    }


}