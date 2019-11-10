using Aelgi.Markdown.IServices;
using Aelgi.Markdown.Models.Symbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Services.Parsers.Block
{
    public abstract class BlockParser
    {
        protected IParser Parser;

        public void AssignParser(IParser parser)
        {
            Parser = parser;
        }

        public abstract Symbol Process(Queue<string> content);
    }
}
