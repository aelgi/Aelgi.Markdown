﻿using Aelgi.Markdown.Models.Symbols;

namespace Aelgi.Markdown.IServices
{
    public interface IRenderer<T>
    {
        T Render(DocumentSymbol symbol);
    }
}
