using SILF.Script;
using SILF.Script.Elements;
using SILF.Script.Elements.Functions;
using SILF.Script.Interfaces;
using SILF.Script.Runtime;

namespace SILF.Framework;


internal class BridgeFunction : IFunction
{


    public Tipo? Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Parameter> Parameters { get; set; } = new();

    public Context Context { get ; set ; }

    Func<List<SILF.Script.Elements.ParameterValue>, FuncContext> Action;

    public BridgeFunction(Func<List<SILF.Script.Elements.ParameterValue>, FuncContext> action)
    {
        this.Action = action;
    }

    public FuncContext Run(Instance instance, List<SILF.Script.Elements.ParameterValue> values, ObjectContext @object)
    {
        return Action.Invoke(values);
    }

}
