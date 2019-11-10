using System.Collections.Generic;

namespace Aelgi.Markdown.Models.Symbols.InlineSymbols
{
    public class ItalicsSymbol : InlineSymbol
    {
        public ICollection<InlineSymbol> Content { get; }

        public ItalicsSymbol(ICollection<InlineSymbol> content)
        {
            Content = content;
        }
    }
}
