using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class Editor : Form
    {
        private List<Line> lines = new List<Line>(); // создаем список, в котором будем хранить нарисованные линии
        private History history = new History(); // создаем историю, где будем хранить операции (команды)
        private ActionsOnLines actions = new ActionsOnLines(); // создаем объект действия над линиями, который будет отвечать за удаление всех линий

        private Color currentColor = Color.Black; // задаем изначальный цвет линий
        private int width = 2; // задаем изначальную толщину линий

        private Color colorOfChangeLine; // представляет цвет линии, которую перемещаем
        private int widthOfChangeLine; // представляет толщину линии, которую перемещаем
        private bool wasChange; // была ли изменена линия, т.е. перемещена

        private bool isPressed; // была ли нажата кнопка мыши

        private int firstX; // первая координата по X
        private int firstY; // первая координата по Y

        private int lastX; // координата конца линии по X
        private int lastY; // координата конца линии по Y

        private int isSameLastX; // эти переменные нужны для того, чтобы не отображать точки, т.е. не считать клик мышки за новую линию
        private int isSameLastY;

        private bool isLastWasRedo; // последняя операция была Redo?
        private bool isLastWasUndo; // последняя операция была Undo?

        public Editor()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            firstX = e.X;
            firstY = e.Y;

            if (!buttonForRemoving.Enabled) // если была нажата конпка удаления
            {
                foreach (var line in lines)
                {
                    if (GeometricCalculations.IsPointOnLine(line.FirstPoint, line.SecondPoint, firstX, firstY))
                    {
                        line.RemoveLine(lines, history);
                        pictureBox.Invalidate();
                        break;
                    }
                }
            }
            else if (!buttonForMoving.Enabled) // если была нажата кнопка перемещения
            {
                foreach (var line in lines)
                {
                    if (GeometricCalculations.IsPointInPoint(line.FirstPoint, firstX, firstY) || GeometricCalculations.IsPointInPoint(line.SecondPoint, firstX, firstY))
                    {
                        line.PrepareLineToMove(lines, history, ref firstX, ref firstY);
                        colorOfChangeLine = line.Pen.Color; // запоминаем цвет перемещаемой линии
                        widthOfChangeLine = (int)line.Pen.Width; // запоминаем толщину перемещаемой линии
                        wasChange = true; // линия изменяется
                        break;
                    }
                }

                buttonForMoving.Enabled = true;
            }
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed) // если была нажата кнопка мыши, значит мы рисуем линию, поэтому запоминаем ее последние координаты
            {
                lastX = e.X;
                lastY = e.Y;
                pictureBox.Invalidate();
            }
            else
            {
                isSameLastX = lastX;
                isSameLastY = lastY;
            }
        }

        private void PictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;

            if (isSameLastX != lastX || isSameLastY != lastY) // если линия не является точкой
            {
                if (wasChange) // если линия была изменена, то добавляем линию с теми же параметрами, которые у нее были изначально
                {
                    lines.Add(new Line(new Point(firstX, firstY), new Point(lastX, lastY), new Pen(colorOfChangeLine, widthOfChangeLine)));
                    wasChange = false;
                }
                else
                {
                    lines.Add(new Line(new Point(firstX, firstY), new Point(lastX, lastY), new Pen(currentColor, width)));
                }

                history.AddHistory(new Command(lines[lines.Count - 1], 1), false);
                history.ClearRedoHistory(); // была совершена "свободная команда", поэтому очищаем стек Redo
            }
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (!isLastWasUndo && !isLastWasRedo && buttonForClearing.Enabled && buttonForRemoving.Enabled)
            {
                if (wasChange) // значит линия сейчас изменяется, поэтому рисуем ее, используя те цвет и толщину, которые у нее были изначально
                {
                    e.Graphics.DrawLine(new Pen(colorOfChangeLine, widthOfChangeLine), new Point(firstX, firstY), new Point(lastX, lastY));
                }
                else
                {
                    e.Graphics.DrawLine(new Pen(currentColor, width), new Point(firstX, firstY), new Point(lastX, lastY));
                }
            }

            buttonForRemoving.Enabled = true;
            buttonForClearing.Enabled = true;
            isLastWasUndo = false;
            isLastWasRedo = false;

            foreach (var line in lines) // изображаем все линии
            {
                e.Graphics.DrawLine(line.Pen, line.FirstPoint, line.SecondPoint);
            }
        }

        /// <summary>
        /// Представляет общее диалоговое окно, в котором отображаются доступные цвета
        /// </summary>
        private void OnColorClick(object sender, EventArgs e)
        {
            DialogResult colorDialog = colorDialog1.ShowDialog();

            if (colorDialog == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// Очищает графическое окно
        /// </summary>
        private void OnClearClick(object sender, EventArgs e)
        {
            if (lines.Count != 0)
            {
                buttonForClearing.Enabled = false;
                actions.RemoveAllLines(ref lines, history);
                pictureBox.Invalidate();
            }
        }

        private void OnRemoveClick(object sender, EventArgs e)
        {
            buttonForRemoving.Enabled = false;
        }

        private void OnUndoClick(object sender, EventArgs e)
        {
            lines = history.Undo(lines);
            isLastWasUndo = true;
            pictureBox.Invalidate();
        }

        private void OnRedoClick(object sender, EventArgs e)
        {
            lines = history.Redo(lines);
            isLastWasRedo = true;
            pictureBox.Invalidate();
        }

        private void OnMoveClick(object sender, EventArgs e)
        {
            buttonForMoving.Enabled = false;
        }

        private void EditorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z) // CTRL + Z
            {
                buttonForUndo.PerformClick(); // имитируем нажатие Undo
            }
            else if (e.Control && e.KeyCode == Keys.Y) // CTRL + Y
            {
                buttonForRedo.PerformClick(); // имитируем нажатие Redo
            }
        }

        private void ToolStripMenuItemClick(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            width = Convert.ToInt32(toolStripMenuItem.Text);
        }

        /// <summary>
        /// Теперь contextMenuStrip вызывается и по левому клику мыши тоже
        /// </summary>
        private void OnWidthClick(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }
    }
}
