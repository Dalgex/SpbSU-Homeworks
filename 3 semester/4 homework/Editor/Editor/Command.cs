using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Объявляет интерфейс для отмены и повторения действий пользователя
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Выполняет команду
        /// </summary>
        public abstract void Execute(List<Shape> shapes);

        /// <summary>
        /// Отменяет команду
        /// </summary>
        public abstract void UnExecute(List<Shape> shapes);
    }
}
