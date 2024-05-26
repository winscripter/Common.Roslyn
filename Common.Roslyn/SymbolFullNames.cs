using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Common.Roslyn
{
    internal static class SymbolFullNames
    {
        public static string? GetFullClassName(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel)
        {
            var symbol = semanticModel.GetDeclaredSymbol(classDeclaration);

            if (symbol == null)
            {
                return null;
            }

            var namespaceName = symbol.ContainingNamespace.ToDisplayString();
            var className = symbol.Name;

            return $"{namespaceName}.{className}";
        }
    }
}
