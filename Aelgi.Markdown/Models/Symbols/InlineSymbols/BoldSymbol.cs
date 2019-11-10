using System.Collections.Generic;

namespace Aelgi.Markdown.Models.Symbols.InlineSymbols
{
    public class BoldSymbol : InlineSymbol
    {
        public ICollection<InlineSymbol> Content { get; }

        public BoldSymbol(ICollection<InlineSymbol> content)
        {
            Content = content;
        }
    }
}
