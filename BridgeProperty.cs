using SILF.Script;
using SILF.Script.Elements;
using SILF.Script.Elements.Functions;
using SILF.Script.Interfaces;
using SILF.Script.Objects;

namespace SILF.Framework;




internal class BridgeProperty : IProperty
{

    public string Name { get; set; }

    public Tipo? Tipo { get; set; }

    public SILFObjectBase Value { get; set; }

    public SILFObjectBase Parent { get; set; }

    public IFunction Get { get; set; }
    public IFunction Set { get; set; }



    public BridgeProperty(string name, Tipo? tipo)
    {
        this.Name = name;
        this.Tipo = tipo;

        Get = new BridgeFunction((e) =>
        {
            return new FuncContext()
            {
                IsReturning = true,
                Value = Value,
                WaitType = Tipo,
            };
        })
        {
            Name = "get",
            Parameters =
            [
               new Parameter("value", Tipo.Value)
            ]
        };


        Set = new BridgeFunction((e) =>
        {

            var value = e.LastOrDefault(t => t.Name == "value");


            if (value.Objeto is SILFObjectBase obj)
                Value = obj;

            return new FuncContext()
            {
                IsReturning = true,
                WaitType = new(),
            };
        })
        {
            Name = "set",
            Parameters =
            [
               new Parameter("value", Tipo.Value)
            ]
        };







    }





    public SILFObjectBase GetValue(Instance instance)
    {
        var result = Get.Run(instance,
            [ 
            new ParameterValue("context", Value),
            new ParameterValue("parent", Parent)
            ], SILF.Script.Runtime.ObjectContext.GenerateContext(Parent));

        return result.Value;
    }


    public void SetValue(Instance instance, SILFObjectBase @base)
    {
        Set.Run(instance, [
            new ParameterValue("value", @base),
            new ParameterValue("parent", Parent)
            ], SILF.Script.Runtime.ObjectContext.GenerateContext(Parent));
    }

    public IProperty Clone()
    {
        return new BridgeProperty(Name, Tipo);
    }

    public void Establish(SILFObjectBase obj)
    {
    }
}
