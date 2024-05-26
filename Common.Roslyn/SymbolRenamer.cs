using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Common.Roslyn
{
    public static class SymbolRenamer
    {
        public static SyntaxNode RenameClasses(SyntaxTree node, string initialName, string newName)
        {
            var root = node.GetRoot();

            var classDeclaration = root.DescendantNodes().OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(c => c.Identifier.ValueText == initialName);

            if (classDeclaration != null)
            {
                var modifiedClassDeclaration = classDeclaration.WithIdentifier(SyntaxFactory.Identifier(newName));

                modifiedClassDeclaration = modifiedClassDeclaration
                    .WithLeadingTrivia(classDeclaration.GetLeadingTrivia())
                    .WithTrailingTrivia(classDeclaration.GetTrailingTrivia())
                    .WithIdentifier(SyntaxFactory.Identifier(newName + " "));

                var updatedRoot = root.ReplaceNode(classDeclaration, modifiedClassDeclaration);

                updatedRoot = updatedRoot.ReplaceNodes(
                    updatedRoot.DescendantNodes().OfType<IdentifierNameSyntax>()
                        .Where(id => id.Identifier.ValueText == initialName),
                    (_, _) => SyntaxFactory.IdentifierName(newName + " "));

                string modifiedCode = updatedRoot.ToFullString();
                return CSharpSyntaxTree.ParseText(modifiedCode).GetRoot();
            }
            else
            {
                throw new SyntaxException(SR.CannotRenameSymbol);
            }
        }

        public static SyntaxNode RenameMethods(SyntaxTree node, string initialName, string newName)
        {
            var root = node.GetRoot();

            var classDeclaration = root.DescendantNodes().OfType<MethodDeclarationSyntax>()
                .FirstOrDefault(c => c.Identifier.ValueText == initialName);

            if (classDeclaration != null)
            {
                var modifiedClassDeclaration = classDeclaration.WithIdentifier(SyntaxFactory.Identifier(newName));

                modifiedClassDeclaration = modifiedClassDeclaration
                    .WithLeadingTrivia(classDeclaration.GetLeadingTrivia())
                    .WithTrailingTrivia(classDeclaration.GetTrailingTrivia())
                    .WithIdentifier(SyntaxFactory.Identifier(newName + " "));

                var updatedRoot = root.ReplaceNode(classDeclaration, modifiedClassDeclaration);

                updatedRoot = updatedRoot.ReplaceNodes(
                    updatedRoot.DescendantNodes().OfType<IdentifierNameSyntax>()
                        .Where(id => id.Identifier.ValueText == initialName),
                    (_, _) => SyntaxFactory.IdentifierName(newName + " "));

                string modifiedCode = updatedRoot.ToFullString();
                return CSharpSyntaxTree.ParseText(modifiedCode).GetRoot();
            }
            else
            {
                throw new SyntaxException(SR.CannotRenameSymbol);
            }
        }
    }
}
