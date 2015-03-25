using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var cursor = new ControlCursor();

            eventLoop.DownHandler += cursor.Down;
            eventLoop.UpHandler += cursor.Up;
            eventLoop.LeftHandler += cursor.Left;
            eventLoop.RightHandler += cursor.Right;

            eventLoop.Run();
        }
    }
}
