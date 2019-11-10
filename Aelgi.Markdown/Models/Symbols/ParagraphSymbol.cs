using Aelgi.Markdown.Models.Symbols.InlineSymbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Models.Symbols
{
    public class ParagraphSymbol : Symbol
    {
        public ICollection<InlineSymbol> Content { get; }

        public ParagraphSymbol(ICollection<InlineSymbol> content)
        {
            Content = content;
        }
    }
}
