using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Interfaces
{
    public interface IGraphicEditor
    {
        IShape Shape { get; }
        string DrawShape(IShape shape);
    }
}
