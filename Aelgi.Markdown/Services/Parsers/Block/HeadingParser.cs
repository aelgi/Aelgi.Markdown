using Aelgi.Markdown.Models.Symbols;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Aelgi.Markdown.Services.Parsers.Block
{
    public class HeadingParser : BlockParser
    {
        protected Regex headingMatch = new Regex(@"^(#{1,6})\ ?(.*)$", RegexOptions.Compiled);

        public override Symbol Process(Queue<string> content)
        {
            var line = content.Peek();

            if (headingMatch.IsMatch(line))
            {
                var groups = headingMatch.Match(line).Groups;
                var depth = groups[1].Value.Length;
                var title = groups[2].Value;

                content.Dequeue();
                return new HeadingSymbol(depth, Parser.ParseInlineContent(title));
            }

            return null;
        }
    }
}
