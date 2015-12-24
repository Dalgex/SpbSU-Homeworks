using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    /// <summary>
    /// Определяет некоторые геометрические вычисления
    /// </summary>
    public static class GeometricCalculations
    {
        /// <summary>
        /// Вычисляет расстояние от точки до прямой
        /// </summary>
        private static double FindDistance(Point firstPoint, Point secondPoint, int x, int y)
        {
            // подставляем в уравнение: y = kx + d координаты (x1, y1) и (x2, y2)
            // тогда находим k = (y2-y1)/(x2-x1)
            // но записывать в конечном виде уравнение прямой мы будем так: ax + by + c = 0
            // если привести y = kx + d к этому виду, то получим: -kx + y - d = 0;
            // поэтому b = 1, a = -k, c = -d, где d = y - kx
            // в конце вычисляем и возвращаем расстояние от точки до прямой

            double k = (double)(secondPoint.Y - firstPoint.Y) / (double)(secondPoint.X - firstPoint.X);
            double c = (double)(k * firstPoint.X) - (double)firstPoint.Y;
            int b = 1;
            double a = -k;
            return Math.Abs(a * x + b * y + c) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        /// <summary>
        /// Проверяет, лежит ли точка на линии
        /// </summary>
        public static bool IsPointOnLine(Point firstPoint, Point secondPoint, int x, int y)
        {
            return FindDistance(firstPoint, secondPoint, x, y) < 5; // почему 5? потому что прям чисто на линию мы вряд ли попадем
        }

        /// <summary>
        /// Находит расстояние между двумя точками
        /// </summary>
        private static double FindDistanceBetweenPoints(Point point, int x, int y)
        {
            return Math.Sqrt(Math.Pow(point.X - x, 2) + Math.Pow(point.Y - y, 2));
        }

        /// <summary>
        /// Проверяет, попала ли точка на один из концов линии
        /// </summary>
        public static bool IsPointInPoint(Point point, int x, int y)
        {
            return FindDistanceBetweenPoints(point, x, y) < 5; // оцениваем 5, т.к. ровно в точку вряд ли удастся попасть
        }
    }
}
