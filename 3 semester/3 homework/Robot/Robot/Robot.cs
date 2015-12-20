using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    /// <summary>
    /// Имитирует телепортацию роботов 
    /// </summary>
    public class TeleportationsRobots
    {
        private Graph graph;

        public TeleportationsRobots(Graph graph)
        {
            this.graph = graph;
        }

        /// <summary>
        /// Проверяет, существует ли такая последовательность телепортаций, при которой все роботы самоуничтожатся
        /// </summary>
        public bool CanAllRobotsBeDestroyed()
        {
            bool[] isRobotDestroyed = new bool[graph.GetSize()];

            for (int i = 0; i < graph.GetSize(); i++)
            {
                if (graph.IsRobotHere(i) && !isRobotDestroyed[i])
                {
                    if (!CanRobotBeDestroyed(i, isRobotDestroyed))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Проверяет, может ли робот быть уничтожен
        /// </summary>
        private bool CanRobotBeDestroyed(int currentRobot, bool[] robotIsDestroyed)
        {
            bool[] isVisited = new bool[graph.GetSize()]; // с помощью данного массива будем определять, какие вершины могут быть посещены currentRobot'ом
            Queue<int> queue = new Queue<int>(); // создаем очередь, в которую будем добавлять номера тех вершин, куда может добраться currentRobot
            queue.Enqueue(currentRobot);
            isVisited[currentRobot] = true;

            while (queue.Count != 0) // если очередь пустая, значит, не существует такой комбинации, при которой currentRobot будет уничтожен
            {
                int currentVertex = queue.Dequeue(); // извлекаем из очереди нормер вершины, в которую может попасть currentRobot

                // если в вершине currentVertex находится робот и это не currentRobot, то значит они оба могут быть уничтожены
                if (graph.IsRobotHere(currentVertex) && currentVertex != currentRobot)
                {
                    robotIsDestroyed[currentVertex] = true;
                    robotIsDestroyed[currentRobot] = true;
                    return true;
                }

                // ищем вершины, в которые робот может попасть из currentVertex
                for (int i = 0; i < graph.GetSize(); i++)
                {
                    if (graph.IsConnect(i, currentVertex) && i != currentVertex)
                    {
                        for (int j = 0; j < graph.GetSize(); j++)
                        {
                            if (graph.IsConnect(i, j) && i != j && !isVisited[j]) // не трудно заметить, что в вершину j можно
                            {                                                     // попасть из currentVertex только через i
                                isVisited[j] = true;
                                queue.Enqueue(j);
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
