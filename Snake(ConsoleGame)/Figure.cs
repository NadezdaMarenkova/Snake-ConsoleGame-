using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame_
{
    internal class Figure // Основной класс для ( VerticalLine и HorizontalLine )
    {
        protected List<Point> pList; // Список точек класса Figure

        public void Draw() // Отрисовка Figure, обращаемся к методу отрисовки точки.
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        // Проявление полиморфизма, две функции с одинаковым названием (IsHit) принимают разные аргументы (figure и point).
        internal bool IsHit(Figure figure) // Принимается аргумент - фигура 
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point) // Принимается аргумент - точка
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
