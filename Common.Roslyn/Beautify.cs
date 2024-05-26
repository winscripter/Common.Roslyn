using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Common.Roslyn
{
    public static class Beautify
    {
        public static string IndentCSharpCode(this string text)
        {
            return CSharpSyntaxTree.ParseText(text).GetRoot().NormalizeWhitespace().ToFullString();
        }

        public static bool NeedsIndent(this string text) => IndentCSharpCode(text).Trim() != text.Trim();
    }
}
