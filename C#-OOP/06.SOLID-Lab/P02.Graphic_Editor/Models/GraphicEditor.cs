using System;
using System.Collections.Generic;
using System.Text;
using P02.Graphic_Editor.Interfaces;

namespace P02.Graphic_Editor.Models
{
    public class GraphicEditor : IGraphicEditor
    {
        public GraphicEditor(IShape shape)
        {
            Shape = shape;
        }

        public IShape Shape {get; private set;}
  
        public string DrawShape(IShape shape)
        {
            return $"I'm {shape.GetType().Name} ";
        }
    }
}
