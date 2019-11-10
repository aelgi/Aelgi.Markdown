using Aelgi.Markdown.Models.Symbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Services.Parsers.Block
{
    public class ParagraphParser : BlockParser
    {
        public override Symbol Process(Queue<string> content)
        {
            return new ParagraphSymbol(Parser.ParseInlineContent(content.Dequeue()));
        }
    }
}
