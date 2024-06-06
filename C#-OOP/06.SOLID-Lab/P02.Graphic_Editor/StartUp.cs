using P02.Graphic_Editor.Models;
using System;

namespace P02.Graphic_Editor
{
    class StartUp
    {
        static void Main()
        {
            Circle circle = new Circle();
            GraphicEditor graphicEdit = new GraphicEditor(circle);
            Console.WriteLine(graphicEdit.DrawShape(circle));
        }
    }
}
