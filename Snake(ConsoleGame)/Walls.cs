using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame_
{
    internal class Walls // Класс Walls, который используется для создания границ поля игры (стен).
    {
        List<Figure> wallList;

        // wallList - список объектов класса Figure, который содержит все созданные границы поля игры.
        public Walls(int mapWidth, int mapHeight) // mapWidth и mapHeight - параметры, передаваемые в конструктор класса Walls и определяющие размеры поля игры.
        {
            wallList = new List<Figure>();

            /*
             * Конструктор класса Walls используется для создания стен и добавления их в wallList. 
             * Для этого создаем четыре объекта классов HorizontalLine и VerticalLine, 
             * которые представляют собой линии на поле игры. Затем добавляем созданные линии в список wallList.
             */
            //Отрисовка рамки.
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }


        /*
         * Метод IsHit() проверяет, пересекается ли переданный ему объект класса Figure с какой-либо из границ поля игры. 
         * Если пересечение обнаружено, метод возвращает значение true, в противном случае - false.
         */
        internal bool IsHit(Figure figure) 
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Метод Draw() вызывает метод Draw() для каждого объекта в списке wallList, чтобы отрисовать все созданные границы на поле игры.
         */
        public void Draw() 
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
