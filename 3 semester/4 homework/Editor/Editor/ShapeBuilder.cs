using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Строит фигуру в момент ее рисования
    /// </summary>
    public class ShapeBuilder
    {
        /// <summary>
        /// Определяет цвет, ширину и стиль фигуры
        /// </summary>
        public System.Drawing.Pen Pen { get; private set; }

        public System.Drawing.Color Color { get; private set; }
        public int Width { get; private set; }

        public ShapeBuilder(System.Drawing.Color color, int width)
        {
            this.Color = color;
            this.Width = width;
        }

        public void BuildLine(System.Drawing.Point startPoint, System.Drawing.Point currentPoint, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new System.Drawing.Pen(Color, Width), startPoint, currentPoint);
        }
    }
}
