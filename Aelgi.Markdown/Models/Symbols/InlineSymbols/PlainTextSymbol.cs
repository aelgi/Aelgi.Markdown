namespace Aelgi.Markdown.Models.Symbols.InlineSymbols
{
    public class PlainTextSymbol : InlineSymbol
    {
        public string Content { get; }

        public PlainTextSymbol(string content)
        {
            Content = content;
        }
    }
}
