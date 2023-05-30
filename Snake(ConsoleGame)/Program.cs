using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using System.Threading.Tasks;


// Консольная игра в Змейку

/* От себя:
 * 1. Меню с возможностью выбора начать игру или выйти из консоли.
 * 2. Добавила звуки при поедании Змейкой еды.
 * 3. Добавила звуки при столкновении Змейки со стенкой или при столкновении в свой хвост.
 * 4. Изменила цвета Змейки, еды и Стенок.
 * 5. Добавила вывод на экран об окончании игры (Game Over).
 */

namespace Snake_ConsoleGame_
{
    internal class Program // Класс Program, который содержит метод Main (). Этот метод представляет собой точку входа в программу и управляет выполнением программы.
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Start\n2 - Quit\n");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                Console.Clear(); // Удаляет строки в консоле

                // Меню с двумя выборами, начать игру или выйти из консоли
                if (choice=="1")
                { 
            

                    Console.SetWindowSize(80, 25); // Размер окна, игровое поле змейки
                    Console.SetBufferSize(80, 25);

                    //Отрисовка рамочки
                    Walls walls = new Walls(80, 25);
                    Console.ForegroundColor = ConsoleColor.Red;
                    walls.Draw();


                    // Отрисовка точек Змейки
                    Point p = new Point(4, 5, '*');  // Присудствует инкапсуляция (мы не знаем, что содержит класс Point, как точка выглядит изнутри)
                    Console.ForegroundColor = ConsoleColor.Green;
                    Snake snake = new Snake(p, 4, Direction.RIGHT);
                    snake.Draw();

                    // Отрисовка еды для Змейки
                    FoodCreator foodCreator = new FoodCreator(80, 25, '$'); 
                    Point food = foodCreator.CreateFood();
                    food.Draw();

                    while (true)
                    {
                        if (walls.IsHit(snake) || snake.IsHitTail()) // (Функция бинарного значения) Проверка, столкнулась ли змейка со стенкой (функция в классе walls) ИЛИ(||) с собственным хвостом (функция в классе snake)
                        {
                            SoundPlayer hitPlayer = new SoundPlayer("hit_sound.wav"); // Звук, при столкновении со стенкой или самой собой.
                            hitPlayer.Load();
                            hitPlayer.Play();

                            break; // при выполнении одного из вышеупомянутых условий, игра заканчивается, цикл прекращается
                        }
                        if (snake.Eat(food)) // Функция поедания, находиться в классе Snake
                        {
                            SoundPlayer playerEat = new SoundPlayer("snake_eat_sound.wav"); // Звук, когда змейка "ест" 
                            playerEat.Load();
                            playerEat.Play();

                            food = foodCreator.CreateFood(); // Появление еды для Змейки (Вызываем класс FoodCreator и создаем новую рандомную точку еды)
                            food.Draw();
                        }
                        else
                        {
                            snake.Move();
                        }
                        Thread.Sleep(100); // Задержка по времени движения Змейки в 100 мс(миллисекунд)

                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(); // Обрабатываем нажатие кнопок направления, вызываем метод HandleKey()
                            snake.HandleKey(key.Key);
                        }
                    }
                    WriteGameOver();
                    
                } 

                else if (choice=="2")
                {
                    break; // Выход из меню.
                }
            }
        }
        static void WriteGameOver() // Если игрок прогиграл, показывается экран "GAME OVER", после чего программа заканчивается.
        {
            int xOffset = 25; // расположение меню
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Blue; // цвет меню
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("    G A M E   O V E R", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Author: Nadežda Marenkova", xOffset + 2, yOffset++);
            WriteText("         TARgv22", xOffset + 2, yOffset++);
            WriteText("============================", xOffset, yOffset++);

            Console.ReadLine();
            Console.Clear();
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
            
        }


    }
}

