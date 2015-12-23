using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Отвечает за действия над фигурами
    /// </summary>
    public class ActionsOnShapes
    {
        /// <summary>
        /// Удаляет все фигуры и добавляет соответствующие операции в историю изменений
        /// </summary>
        public void RemoveAllLines(ref List<Shape> shapes, History history)
        {
            // Добавляем в историю удаление каждой фигуры и при этом указываем, что это является частью одной команды
            for (int i = shapes.Count - 1; i > 0; i--)
            {
                history.AddHistory(new CommandShape(shapes[i], "Удаление"), true);
            }

            // Добавляем в историю последнюю фигуру и показываем, что на этом целостная команда завершается
            history.AddHistory(new CommandShape(shapes[0], "Удаление"), false);
            shapes = new List<Shape>(); // удаляем все линии
        }
    }
}
