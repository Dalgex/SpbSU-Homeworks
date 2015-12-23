using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Отвечает за действие над несколькими линиями сразу
    /// </summary>
    public class ActionsOnLines
    {
        // Комментарий к классу:
        // За подготовку линии к перемещению или за удаление конкретной линии, логично, что должен отвечать сам класс Line
        // Но если нам требуется совершить какое-нибудь глобальное действие над линиями (например, удалить их всех),
        // то использовать в этих целях класс Line будет не очень правильно. Поэтому нужно завести отдельный класс,
        // который будет отвечать за подобные действия

        /// <summary>
        /// Удаляет все линии и добавляет соответствующие операции в историю изменений
        /// </summary>
        public void RemoveAllLines(ref List<Shape> shapes, History history)
        {
            // Добавляем в историю удаление каждой линии и при этом указываем, что это является частью одной команды
            for (int i = 0; i < shapes.Count - 1; i++)
            {
                history.AddHistory(new CommandShape(shapes[i], "Удаление"), true);
            }

            // Добавляем в историю последнюю линию и показываем, что на этом целостная команда завершается
            history.AddHistory(new CommandShape(shapes[shapes.Count - 1], "Удаление"), false);
            shapes = new List<Shape>(); // удаляем все линии
            history.ClearRedoHistory(); // при выполнении «свободной» операции стек Redo должен очищаться
        }
    }
}
