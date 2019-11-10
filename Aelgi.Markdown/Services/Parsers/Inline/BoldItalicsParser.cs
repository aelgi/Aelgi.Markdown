using Aelgi.Markdown.Models.Symbols.InlineSymbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Services.Parsers.Inline
{
    public class BoldItalicsParser : InlineParser
    {
        protected InlineSymbol ProcessBold(Queue<char> content, char origChar)
        {
            var innerQueue = new Queue<char>();

            while (true)
            {
                if (content.Peek() == origChar)
                {
                    var first = content.Dequeue();
                    if (content.Peek() == origChar)
                    {
                        content.Dequeue();
                        return new BoldSymbol(Parser.ParseInlineContent(new string(innerQueue.ToArray())));
                    }
                    else
                        innerQueue.Enqueue(first);
                }
                else
                    innerQueue.Enqueue(content.Dequeue());
            }
        }

        protected InlineSymbol ProcessItalics(Queue<char> content, char origChar)
        {
            var innerQueue = new Queue<char>();

            while (content.Peek() != origChar)
                innerQueue.Enqueue(content.Dequeue());

            content.Dequeue();
            return new ItalicsSymbol(Parser.ParseInlineContent(new string(innerQueue.ToArray())));
        }

        public override InlineSymbol Process(Queue<char> content)
        {
            var first = content.Peek();
            if (first == '*' || first == '_')
            {
                content.Dequeue();
                var second = content.Peek();

                if (second == first)
                {
                    content.Dequeue();
                    return ProcessBold(content, first);
                }
                else return ProcessItalics(content, first);
            }

            return null;
        }
    }
}
