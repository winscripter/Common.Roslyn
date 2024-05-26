namespace Common.Roslyn
{
    public class SyntaxException(string message) : Exception(message)
    {
        public SyntaxException() : this("Cannot parse C# code")
        {
        }
    }
}
