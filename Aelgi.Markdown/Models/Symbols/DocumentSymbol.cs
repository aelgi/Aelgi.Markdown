using System.Collections.Generic;

namespace Aelgi.Markdown.Models.Symbols
{
    public class DocumentSymbol : Symbol
    {
        public ICollection<Symbol> Content { get; }

        public DocumentSymbol(ICollection<Symbol> content)
        {
            Content = content;
        }
    }
}
