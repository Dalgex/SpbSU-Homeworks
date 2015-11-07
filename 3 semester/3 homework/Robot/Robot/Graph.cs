using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    /// <summary>
    /// Представляет связный неориентированный граф, в вершинах которого находятся несколько роботов
    /// </summary>
    public class Graph
    {
        private int numberOfVertices;
        private bool[,] graph;
        private bool[] isRobotHere;

        public Graph(bool[,] adjacencyMatrix, bool[] isRobotHere)
        {
            numberOfVertices = isRobotHere.Length;
            this.isRobotHere = isRobotHere;
            graph = adjacencyMatrix;
        }

        /// <summary>
        /// Проверяет, соединены ли вершины ребром
        /// </summary>
        public bool IsConnect(int i, int j)
        {
            return graph[i, j];
        }

        /// <summary>
        /// Проверяет, находится ли в данной вершине робот
        /// </summary>
        public bool IsRobotHere(int number)
        {
            return isRobotHere[number];
        }

        /// <summary>
        /// Возвращает количество вершин в графе
        /// </summary>
        public int GetSize()
        {
            return numberOfVertices;
        }
    }
}
