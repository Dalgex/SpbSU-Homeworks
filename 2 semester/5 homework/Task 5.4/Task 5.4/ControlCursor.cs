using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._4
{
    /// <summary>
    /// Реализует движение курсора в консоли
    /// </summary>
    public class ControlCursor
    {
        /// <summary>
        /// Движение вправо
        /// </summary>
        public void Right(object sender, EventArgs args)
        {
            if (Console.CursorLeft < Console.BufferWidth - 1)
            {
                Console.CursorLeft += 1;
            }
        }

        /// <summary>
        /// Движение влево
        /// </summary>
        public void Left(object sender, EventArgs args)
        {
            if (Console.CursorLeft > 0)
            {
                Console.CursorLeft -= 1;
            }
        }

        /// <summary>
        /// Движение вниз
        /// </summary>
        public void Down(object sender, EventArgs args)
        {
            if (Console.CursorTop < Console.BufferHeight - 1)
            {
                Console.CursorTop += 1;
            }
        }

        /// <summary>
        /// Движение вверх
        /// </summary>
        public void Up(object sender, EventArgs args)
        {
            if (Console.CursorTop > 0)
            {
                Console.CursorTop -= 1;
            }
        }
    }
}
