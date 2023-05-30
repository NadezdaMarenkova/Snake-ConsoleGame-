using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame_
{
    internal class VerticalLine : Figure // Класс VerticalLine, который содержит часть свойств от основного класса Figure.
    {

        public VerticalLine(int yUp, int yDown, int x, char sym) // Создание вертикальной линии.
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }
}
