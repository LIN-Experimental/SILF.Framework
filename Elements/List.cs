using SILF.Script.Elements.Functions;
using SILF.Script.Interfaces;
using SILF.Script.Objects;

namespace SILF.Framework.Elements;


internal class List
{

    /// <summary>
    /// Cargar métodos de string.
    /// </summary>
    public static IEnumerable<IFunction> Load()
    {

        // Get.
        static FuncContext get(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value");
            int.TryParse(values.LastOrDefault(t => t.Name == "id")!.Objeto.Value?.ToString() , out int id);

            SILFObjectBase? @base = null;
            if (cadena?.Objeto.GetValue() is IEnumerable<SILFObjectBase> lista)
            {
               @base =  lista.ElementAt(id);
            }

            return new FuncContext()
            {
                WaitType = @base?.Tipo,
                IsReturning = true,
                Value = new SILFStringObject()
                {
                    Tipo = @base?.Tipo ?? new("mutable"),
                    Value = @base?.GetValue()
                }
            };
        }

        // Get.
        static FuncContext add(List<Script.Elements.ParameterValue> values)
        {

            var cadena = values.LastOrDefault(t => t.Name == "value");
            var value = values.LastOrDefault(t => t.Name == "object");

            SILFObjectBase? @base = null;
            if (cadena.Objeto.GetValue() is List<SILFObjectBase> lista && value.Objeto is SILFObjectBase vl)
            {
                lista.Add(vl);
            }

            return new FuncContext()
            {
                IsReturning = true
            };
        }


        // Lista.
        BridgeFunction[] functions =
        [
            new BridgeFunction(get)
            {
                Name = "get",
                Parameters =
                [
                    new("value", new("array")),
                    new("id", new("number")),
                ]
            },

            new BridgeFunction(add)
            {
                Name = "add",
                Parameters =
                [
                    new("value", new("array")),
                    new("object", new("mutable")),
                ]
            },
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

            var cadena = values.FirstOrDefault(t => t.Name == "parent");

            int count = 0;
            if (cadena?.Objeto.GetValue() is List<SILFObjectBase> lista)
            {
                count = lista.Count;
            }

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