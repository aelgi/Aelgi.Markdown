using Aelgi.Markdown.Models.Symbols;
using Aelgi.Markdown.Models.Symbols.InlineSymbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.IServices
{
    public interface IParser
    {
        ICollection<InlineSymbol> ParseInlineContent(string line);
        DocumentSymbol Parse(string content);
    }
}
