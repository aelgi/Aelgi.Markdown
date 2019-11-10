using Aelgi.Markdown.Models.Symbols.InlineSymbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Models.Symbols
{
    public class HeadingSymbol : Symbol
    {
        public int Depth { get; }
        public ICollection<InlineSymbol> Title { get; }

        public HeadingSymbol(int depth, ICollection<InlineSymbol> title)
        {
            Depth = depth;
            Title = title;
        }
    }
}
