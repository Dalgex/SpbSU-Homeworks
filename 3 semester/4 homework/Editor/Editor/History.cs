using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Отвечает за историю изменений
    /// </summary>
    public class History
    {
        // Пояснение к работе класса:
        // Чем операция проще, тем легче её обратить, тем больше вероятность, что обращение реализуемо. 
        // Поэтому имеет смысл разбивать операцию, которую видит пользователь, на последовательность более мелких, внутренних
        // операций (микро-операций). Перемещение линии мы будем разбивать на две команды: удаление изначальной, а потом добавление конечной.
        // Удаление всех линий мы тоже разбиваем на микрокоманды: идет удаление по одной.
        // Для того чтобы обозначать границы пользовательских операций, в стеки помещаются специальные команды – 
        // контрольные точки (у нас это будет null). Эти специальные команды не исполняются, 
        // они лишь обозначают, что пользовательская операция завершилась. 
        // Операция Undo будет отматывать последовательность микрокоманд до первой встретившийся в стеке Undo контрольной точки. 
        // Аналогично будет работать команда Redo

        private Stack<Command> undo = new Stack<Command>();
        private Stack<Command> redo = new Stack<Command>();

        /// <summary>
        /// Показывает, можно ли отменить действие
        /// </summary>
        private bool CanUndo { get { return undo.Count > 0; } }

        /// <summary>
        /// Показывает, можно ли восстановить отмененное действие
        /// </summary>
        private bool CanRedo { get { return redo.Count > 0; } }

        /// <summary>
        /// Добавляет в историю команду и логический параметр, показывающий, идет добавление целой команды или ее части
        /// </summary>
        public void AddHistory(Command command, bool isPartOfCommand)
        {
            undo.Push(command);
            
            if (!isPartOfCommand)
            {
                undo.Push(null);
            }
        }

        /// <summary>
        /// Отменяет последнюю операцию
        /// </summary>
        public List<Line> Undo(List<Line> lines)
        {
            if (CanUndo)
            {
                undo.Pop(); // удаляем контрольную точку

                while (undo.Count > 0 && undo.Peek() != null)
                {
                    redo.Push(undo.Pop()); // перекладываем команду с вершины стека Undo в стек Redo

                    if (redo.Peek().ReverseExecute() == 1) // выполняем команду, обратную только что переложенной
                    {
                        lines.Add(redo.Peek().Line);
                    }
                    else // значит до этого было добавление, поэтому удаляем
                    {
                        lines.Remove(redo.Peek().Line);
                    }
                }

                redo.Push(null); // добавляем контрольную точку
            }

            return lines;
        }

        /// <summary>
        /// Повторяет последнее действие, которое было отменено
        /// </summary>
        public List<Line> Redo(List<Line> lines)
        {
            if (CanRedo)
            {
                redo.Pop(); // удаляем контрольную точку

                while (redo.Count > 0 && redo.Peek() != null)
                {
                    undo.Push(redo.Pop()); // перекладываем команду обратно в стек Undo, а затем исполняем ее

                    if (undo.Peek().NumberOfCommand == 1) // в Redo обращать команду уже не надо, поэтому просто смотрим, какая операция была последней
                    {
                        lines.Add(undo.Peek().Line);
                    }
                    else
                    {
                        lines.Remove(undo.Peek().Line);
                    }
                }

                undo.Push(null); // добавляем контрольную точку
            }

            return lines;
        }

        /// <summary>
        /// Очищает стек Redo
        /// </summary>
        public void ClearRedoHistory()
        {
            if (redo.Count != 0)
            {
                redo = new Stack<Command>();
            }
        }
    }
}
