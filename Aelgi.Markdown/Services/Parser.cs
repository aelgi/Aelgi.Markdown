using Aelgi.Markdown.IServices;
using Aelgi.Markdown.Models.Symbols;
using Aelgi.Markdown.Models.Symbols.InlineSymbols;
using Aelgi.Markdown.Services.Parsers.Block;
using Aelgi.Markdown.Services.Parsers.Inline;
using System.Collections.Generic;
using System.Linq;

namespace Aelgi.Markdown.Services
{
    public class Parser : IParser
    {
        protected List<BlockParser> _blockParsers;
        protected List<InlineParser> _inlineParsers;

        protected void RegisterParsers()
        {
            _blockParsers = new List<BlockParser>()
            {
                new NewLineParser(),
                new HeadingParser(),

                new ParagraphParser()
            };

            _inlineParsers = new List<InlineParser>()
            {
                new BoldItalicsParser()
            };

            foreach (var parser in _blockParsers)
                parser.AssignParser(this);
            foreach (var parser in _inlineParsers)
                parser.AssignParser(this);
        }

        protected Symbol ProcessLine(Queue<string> lines)
        {
            foreach (var parser in _blockParsers)
            {
                var res = parser.Process(lines);
                if (res != null)
                    return res;
            }

            lines.Dequeue();
            return null;
        }

        protected ICollection<Symbol> ProcessLines(Queue<string> lines)
        {
            var symbols = new List<Symbol>();

            while (lines.Count > 0)
                symbols.Add(ProcessLine(lines));

            return symbols;
        }

        protected ICollection<InlineSymbol> ProcessInline(Queue<char> line, Queue<char> unmatchedQueue)
        {
            foreach (var parser in _inlineParsers)
            {
                var res = parser.Process(line);
                if (res != null)
                {
                    var rt = new List<InlineSymbol>();

                    if (unmatchedQueue.Count > 0)
                    {
                        var s = "";
                        while (unmatchedQueue.Count > 0)
                            s += unmatchedQueue.Dequeue();
                        rt.Add(new PlainTextSymbol(s));
                    }

                    rt.Add(res);
                    return rt;
                }
            }

            unmatchedQueue.Enqueue(line.Dequeue());
            return null;
        }

        public ICollection<InlineSymbol> ParseInlineContent(string line)
        {
            var symbols = new List<InlineSymbol>();
            var breakdown = new Queue<char>(line);
            var unmatched = new Queue<char>();

            while (breakdown.Count > 0)
            {
                var res = ProcessInline(breakdown, unmatched);
                if (res != null)
                    symbols.AddRange(res);
            }

            if (unmatched.Count > 0)
                symbols.Add(new PlainTextSymbol(new string(unmatched.ToArray())));

            return symbols.Where(x => x != null).ToList();
        }

        public DocumentSymbol Parse(string content)
        {
            var splitContent = content.Split('\n').Select(x => x.TrimEnd());
            var lines = new Queue<string>(splitContent);

            RegisterParsers();
            var symbols = ProcessLines(lines);

            var doc = new DocumentSymbol(symbols);

            return doc;
        }
    }
}
