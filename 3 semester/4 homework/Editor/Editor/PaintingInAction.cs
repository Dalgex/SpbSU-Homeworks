using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    /// <summary>
    /// Отвечает за рисование на графическом окне в процессе
    /// </summary>
    public class PaintingInAction
    {
        private History history;
        private List<Shape> shapes;
        private ShapeBuilder shapeBuilder;

        private int beginX; // координата начала линии по X
        private int beginY; // координата начала линии по Y
        private int endX; // координата конца линии по X
        private int endY; // координата конца линии по Y

        private Color colorOfMovedLine; // представляет цвет линии, которую перемещаем
        private int widthOfMovedLine; // представляет толщину линии, которую перемещаем
        
        private bool isPressed; // была ли нажата кнопка
        private bool wasMouseMove; // было ли перемещение мышки по элементу управления
        private bool isLineDrawn; // рисуется ли линия

        private Button buttonForMoving;
        private Button buttonForRemoving;

        public PaintingInAction(Button buttonForMoving, Button buttonForRemoving, History history, List<Shape> shapes)
        {
            this.buttonForMoving = buttonForMoving;
            this.buttonForRemoving = buttonForRemoving;
            this.history = history;
            this.shapes = shapes;
        }

        /// <summary>
        /// Обновляет ссылку, чтобы поле класса PaintingInAction продолжало ссылаться на соответствующее поле класса Editor
        /// </summary>
        public void Update(List<Shape> shapes)
        {
            this.shapes = shapes;
        }

        /// <summary>
        /// Определяет, какая кнопка была нажата и вызывает соответствующие методы. 
        /// Если никакая не нажата, то подготоваливает линию к построению
        /// </summary>
        public void DefineActionAndCallAppropriateMethods(MouseEventArgs e, PictureBox pictureBox, Color color, int width)
        {
            isPressed = true;
            wasMouseMove = false;
            beginX = e.X;
            beginY = e.Y;

            if (!buttonForRemoving.Enabled)
            {
                foreach (Line line in shapes)
                {
                    if (GeometricCalculations.IsPointOnLine(line.FirstPoint, line.SecondPoint, beginX, beginY))
                    {
                        line.RemoveLine(shapes, history);
                        pictureBox.Invalidate();
                        break;
                    }
                }
            }
            else if (!buttonForMoving.Enabled)
            {
                foreach (Line line in shapes)
                {
                    if (GeometricCalculations.IsPointInPoint(line.FirstPoint, beginX, beginY) || GeometricCalculations.IsPointInPoint(line.SecondPoint, beginX, beginY))
                    {
                        line.PrepareLineToMove(shapes, history, ref beginX, ref beginY);
                        colorOfMovedLine = line.Pen.Color; // запоминаем цвет перемещаемой линии
                        widthOfMovedLine = (int)line.Pen.Width; // запоминаем толщину перемещаемой линии
                        shapeBuilder = new ShapeBuilder(colorOfMovedLine, widthOfMovedLine);
                        break;
                    }
                }
            }
            else
            {
                shapeBuilder = new ShapeBuilder(color, width);
            }
        }

        /// <summary>
        /// Вызывает метод для построения линии
        /// </summary>
        public void CallLineBuilding(MouseEventArgs e, PictureBox pictureBox)
        {
            if (isPressed) // если была нажата кнопка мыши, значит мы рисуем линию, поэтому запоминаем ее последние координаты
            {
                endX = e.X;
                endY = e.Y;
                isLineDrawn = true;
                pictureBox.Invalidate();
            }

            wasMouseMove = true;
        }

        /// <summary>
        /// Добавляет линию, которая до опускания мыши рисовалась, в историю. Если линия не рисовалась, то ничего не делает
        /// </summary>
        public void AddLineInHistory()
        {
            isPressed = false;

            if (wasMouseMove) // если линия не является точкой
            {
                if (!buttonForMoving.Enabled) // если линия была изменена, то добавляем линию с теми же параметрами, которые у нее были изначально
                {
                    shapes.Add(new Line(new Point(beginX, beginY), new Point(endX, endY), new Pen(colorOfMovedLine, widthOfMovedLine)));
                }
                else
                {
                    Color color = shapeBuilder.Color;
                    int width = shapeBuilder.Width;
                    shapes.Add(new Line(new Point(beginX, beginY), new Point(endX, endY), new Pen(color, width)));
                }

                history.AddHistory(new CommandShape(shapes[shapes.Count - 1], "Добавление"), true);
            }
        }

        /// <summary>
        /// Перерисовывает элемент управления
        /// </summary>
        public void RepaintAll(PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(e);
            }

            if (isLineDrawn)
            {
                shapeBuilder.BuildLine(new Point(beginX, beginY), new Point(endX, endY), e);
                isLineDrawn = false;
            }
        }
    }
}
