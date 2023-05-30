using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame_
{
    internal class Point // Класс точка, который используется для создания объектов точек на экране консоли в игре "Змейка".
    {
        public int x; // Класс имеет три поля: x, y и sym (символ), которые определяют координаты точки на экране и ее символ (то, что будет отображаться на экране в данной точке).
        public int y;
        public char sym;

        public Point() // Пример пустого конструктора
        {

        }
        /* 
         * NB! Конструктор никогда не имеет возвращаемого значения. 
         * При использовании в функции, ключевого слово void, также не будет возвращаемого значения.
         * 
         * Конструкторы класса используются для создания объектов точек с заданными координатами и символами.
         */
        public Point(int _x, int _y, char _sym) 
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        public Point(Point p) // Конструктор, в котором создаем точки хвоста Змейки.
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        /*
         * Метод Move, (позволяет переместить Змейку в нужном направлении), 
         * перемещает точку на экране на заданное расстояние в соответствии с заданным направлением (Direction). 
         * Если направление - RIGHT, то координата x увеличится на offset (расстояние между началом объекта и точкой), 
         * если LEFT, то уменьшится, если UP, то уменьшится координата y, а если DOWN, то увеличится.
         */
        public void Move(int offset, Direction direction) 
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        /*
         * Метод IsHit используется для проверки столкновения змеи со своим телом при движении. 
         * Если координаты двух точек совпадают, то метод вернет true, что будет означать столкновение.
         */
        public bool IsHit(Point p) 
        {
            return p.x == this.x && p.y == this.y;
        }

        public void Draw() // Отрисовка точки на экране.
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear() // Метод, который стирает точку хвоста Змейки, при ее смещении.
        {
            sym = ' ';
            Draw();
        }

        public override string ToString() 
        {
            return x + ", " + y + ", " + sym;
        }
    }
}