using Aelgi.Markdown.Models.Symbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Services.Parsers.Block
{
    public class NewLineParser : BlockParser
    {
        public override Symbol Process(Queue<string> content)
        {
            if (content.Peek().Length == 0)
            {
                content.Dequeue();
                return new NewLineSymbol();
            }
            return null;
        }
    }
}
