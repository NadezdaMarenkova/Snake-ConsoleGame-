using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_ConsoleGame_
{
    internal class FoodCreator // Класс создания новой еды для Змейки, в рандомных местах, в пределах игрового поля.
    {
        int mapWidth; // Переменные объекта класса FoodCreator
        int mapHeight;
        char sym;

        Random random = new Random();

        /*
         * мы используем ключевое слово - public , для того чтобы мы могли использовать эту информацию в других классах, 
         * но также существует и ключевое слово - private, для невидимости за пределами класса.
         */
        public FoodCreator(int mapWidth, int mapHeight, char sym) // Конструктор, принимает в качестве аргуметов размер игрового поля и символы.
        {
            this.mapWidth = mapWidth; // this.mapWidth - является переменной данного класса. 
            this.mapHeight = mapHeight;
            this.sym = sym;
        }
        public Point CreateFood() 
        {

            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }

    }
}
