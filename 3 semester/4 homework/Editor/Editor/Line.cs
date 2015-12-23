using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Представляет линию с указанными координатами, цветом и толщиной
    /// </summary>
    public class Line : Shape
    {
        public override Pen Pen { get; set; }

        /// <summary>
        /// Получает или задает координаты начальной точки линии
        /// </summary>
        public Point FirstPoint { get; set; }

        /// <summary>
        /// Получает или задает координаты конечной точки линии
        /// </summary>
        public Point SecondPoint { get; set; }

        public Line(Point firstPoint, Point secondPoint, Pen pen) : base(pen)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }

        public override void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pen, FirstPoint, SecondPoint);
        }

        /// <summary>
        /// Запоминает координаты одного из концов линии, другой конец которой будет перемещаться и удаляет линию
        /// </summary>
        public void PrepareLineToMove(List<Shape> shapes, History history, ref int beginX, ref int beginY)
        {
            if (GeometricCalculations.IsPointInPoint(FirstPoint, beginX, beginY))
            {
                beginX = SecondPoint.X;
                beginY = SecondPoint.Y;
            }
            else
            {
                beginX = FirstPoint.X;
                beginY = FirstPoint.Y;
            }

            shapes.Remove(this);
            history.AddHistory(new CommandShape(this, "Удаление"), false);
        }

        /// <summary>
        /// Удаляет данную линию из списка линий и добавляет в историю изменений удаление
        /// </summary>
        public void RemoveLine(List<Shape> shapes, History history)
        {
            shapes.Remove(this);
            history.AddHistory(new CommandShape(this, "Удаление"), true);
        }
    }
}
