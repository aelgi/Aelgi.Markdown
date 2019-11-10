using Aelgi.Markdown.IServices;
using Aelgi.Markdown.Models.Symbols;
using System.Collections.Generic;

namespace Aelgi.Markdown.Services
{
    public abstract class BaseRenderer<T, U> : IRenderer<T>
    {
        protected ICollection<U> _nodes;

        protected abstract T CombineNodes();

        protected U ProcessLine(Symbol line)
        {
            return default;
        }

        public T Render(DocumentSymbol symbol)
        {
            _nodes = new List<U>();

            var lines = symbol.Content;
            foreach (var line in lines)
            {
                var rendered = ProcessLine(line);
                if (rendered != null)
                    _nodes.Add(rendered);
            }

            return CombineNodes();
        }
    }
}
