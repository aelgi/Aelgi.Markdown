using Aelgi.Markdown.IServices;
using Aelgi.Markdown.Models.Symbols.InlineSymbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Services.Parsers.Inline
{
    public abstract class InlineParser
    {
        protected IParser Parser;

        public void AssignParser(IParser parser)
        {
            Parser = parser;
        }

        public abstract InlineSymbol Process(Queue<char> content);
    }
}
