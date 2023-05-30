using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame_
{
    internal class Snake : Figure // Класс наследует свойства и методы от класса "Фигура" (Figure).
    {
        Direction direction; // Класс Snake содержит информацию о направлениях, в которых Змейка может двигаться.

        /*
         * В конструкторе класса Snake объявляются переменные и создается список (List) pList точек (Point), 
         * отображающих положение Змейки. В переменной direction сохраняется переданное через параметр направление движения Змейки.
         */
        public Snake(Point tail, int lenght, Direction _direction)  
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);

            }
        }

        /*
         * Метод Move() отвечает за движение Змейки, записывает координаты начального конца Змейки в переменную tail, 
         * удаляет её из списка pList, определяет координаты нового начала Змейки методом GetNextPoint() и добавляет 
         * его в список pList. Затем метод "стирает" предыдущий хвост и рисует новую голову Змейки.
         */
        internal void Move() 
        {
            Point tail = pList.First(); 
            pList.Remove(tail);
            Point head = GetNextPoint(); 
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        /*
         * Метод GetNextPoint() определяет следующую точку, в которой будет находиться голова Змейки после перемещения
         * на одну клетку в том направлении, которое задано переменной direction.
         */
        public Point GetNextPoint() 

        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        /*
         * Метод IsHitTail() проверяет, не пересекает ли голова Змейки (последняя точка списка pList) своё тело. 
         * Для этого он проходит циклом по всем точкам списка pList (кроме головы и предшествующей её точки) и проверяет, 
         * не совпадает ли голова Змейки со всеми остальными точками.
         */
        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        /*
         * Метод HandleKey() отвечает за обработку нажатий клавиш пользователем. 
         * В зависимости от того, какая клавиша была нажата, он изменяет переменную direction, 
         * задавая новое направление движения Змейки.
         */
        public void HandleKey(ConsoleKey key) 
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }

        /*
         * Метод Eat() определяет, съест ли змея еду. Для этого он с помощью метода GetNextPoint() находит координаты,
         * в которых окажется голова Змейки после её перемещения. Если эти координаты совпадают с координатами еды, 
         * то еда добавляется в список pList Змейки, она удлиняется, и метод возвращает true. Если же еда не была съедена, метод возвращает false.
         */
        internal bool Eat(Point food) 
        {
            Point head = GetNextPoint(); 
            if (head.IsHit(food)) 
            {
                food.sym = head.sym; 
                pList.Add(food);
                return true;
            }
            else
                return false; 
        }
    }
}