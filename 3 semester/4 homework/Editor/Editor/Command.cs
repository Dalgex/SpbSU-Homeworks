using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Представляет команду (добавление, удаление)
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Представляет номер команды: 1 - произошло добавление, 2 - удаление
        /// </summary>
        public int NumberOfCommand { get; set; }

        /// <summary>
        /// Объект-линия
        /// </summary>
        public Line Line { get; set; }

        /// <summary>
        /// Создает команду вида: линия и что с ней сделали (добавили/удалили)
        /// </summary>
        public Command(Line line, int numberOfCommand)
        {
            NumberOfCommand = numberOfCommand;
            Line = line;
        }

        /// <summary>
        /// Заменяет команду на противоположную: если было удаление, то теперь считается, что это добавление, и наоборот
        /// </summary>
        public int ReverseExecute()
        {
            if (NumberOfCommand == 1)
            {
                return 2;
            }

            return 1;
        }
    }
}
