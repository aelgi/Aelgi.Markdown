using Aelgi.Markdown.Models.Symbols.InlineSymbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Services.Parsers.Inline
{
    public class PlainTextParser : InlineParser
    {
        public override InlineSymbol Process(Queue<char> content)
        {
            var res = new Queue<char>();
            while (content.Count > 0)
                res.Enqueue(content.Dequeue());

            return new PlainTextSymbol(new string(res.ToArray()));
        }
    }
}
