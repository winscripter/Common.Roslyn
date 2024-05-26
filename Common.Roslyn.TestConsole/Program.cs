using Common.Roslyn;
using Microsoft.CodeAnalysis.CSharp;

var source = @"public class MyClass {
}

public sealed class MyOtherClass {
    private readonly string MyClass;
    private readonly MyClass myClass;

    public static void Foo() {
        _ = typeof(MyClass);
    }
}";

Console.WriteLine(source);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

var renamedSymbols = SymbolRenamer.RenameClasses(CSharpSyntaxTree.ParseText(source), "MyClass", "CoolStuff");
Console.WriteLine(renamedSymbols.ToString());
