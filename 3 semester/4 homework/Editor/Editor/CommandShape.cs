using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Выполняет действия, связанные с фигурами
    /// </summary>
    public class CommandShape : Command
    {
        private string commandName;
        private Shape shape;

        /// <summary>
        /// Создает команду вида: фигура и что с ней сделали (добавили/удалили)
        /// </summary>
        public CommandShape(Shape shape, string commandName)
        {
            this.shape = shape;
            this.commandName = commandName;
        }

        public override void UnExecute(List<Shape> shapes)
        {
            if (ReverseExecute() == "Добавление")
            {
                shapes.Add(shape);
            }
            else
            {
                shapes.Remove(shape);
            }
        }

        public override void Execute(List<Shape> shapes)
        {
            if (commandName == "Добавление")
            {
                shapes.Add(shape);
            }
            else
            {
                shapes.Remove(shape);
            }
        }

        /// <summary>
        /// Заменяет команду на противоположную: если было удаление, то теперь считается, что это добавление, и наоборот
        /// </summary>
        private string ReverseExecute()
        {
            return (commandName == "Добавление") ? "Удаление" : "Добавление";
        }
    }
}
