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
    public class Line
    {
        /// <summary>
        /// Представляет координаты первой точки
        /// </summary>
        public Point FirstPoint { get; set; }

        /// <summary>
        /// Представляет координаты второй точки
        /// </summary>
        public Point SecondPoint { get; set; }

        /// <summary>
        /// Определяет цвет и толщину линии
        /// </summary>
        public Pen Pen { get; set; }

        /// <summary>
        /// Создает новую линию
        /// </summary>
        public Line(Point firstPoint, Point secondPoint, Pen pen)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            Pen = pen;
        }

        /// <summary>
        /// Удаляет линию, добавляет это действие в историю и изменяет определенным образом входные координаты, 
        /// которые необходимы для перемещения изначальной линии
        /// </summary>
        public void PrepareLineToMove(List<Line> lines, History history, ref int x, ref int y)
        {
            if (GeometricCalculations.IsPointInPoint(FirstPoint, x, y))
            {
                x = SecondPoint.X; // запоминаем координаты одного из концов линии, другой конец которой будем перемещать
                y = SecondPoint.Y;
            }
            else
            {
                x = FirstPoint.X;
                y = FirstPoint.Y;
            }

            lines.Remove(this);
            history.AddHistory(new Command(this, 2), true);
        }

        /// <summary>
        /// Удаляет данную линию из списка линий и добавляет в историю изменений удаление
        /// </summary>
        public void RemoveLine(List<Line> lines, History history)
        {
            lines.Remove(this);
            history.AddHistory(new Command(this, 2), false);
            history.ClearRedoHistory(); // при выполнении «свободной» операции стек Redo должен очищаться
        }
    }
}
