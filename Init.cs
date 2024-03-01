namespace SILF.Framework;


public static class Init
{

    /// <summary>
    /// Cargar el framework SILF interoperable con .NET.
    /// </summary>
    /// <param name="app">App.</param>
    public static void LoadFramework(this SILF.Script.App app)
    {
        // Tipos de string.
        app.Library.Load("string", Elements.String.Load().ToList());

        // Tipos de numero.
        app.Library.Load("number", Elements.Number.Load().ToList());

        // Framework.
        app.AddDefaultFunctions(Elements.Framework.Load());


    }


}