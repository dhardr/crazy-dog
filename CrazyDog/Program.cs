using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace CrazyDog
{
    class Program
    {
        static List<Pill> pills;
        static DateTime lastPillAdded;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            pills = new List<Pill>();
            lastPillAdded = DateTime.Now;

            var dog = new Dog();
            dog.Draw();

            var life = new Life();
            life.Draw();
            
            while (true)
            {
                AddPills();
                RemoveExpiredPills();

                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    if (key==ConsoleKey.RightArrow)
                    {
                        dog.MoveRight();
                    } else if (key==ConsoleKey.LeftArrow)
                    {
                        dog.MoveLeft();
                    } else if (key==ConsoleKey.UpArrow)
                    {
                        dog.Jump();
                    }
                }

                dog.Update();
                
                Thread.Sleep(50);
            }
        }

        static void RemoveExpiredPills() => pills.RemoveAll(x => x.ClearIfExpired());


        static void AddPills()
        {
            //Agregado de Pills cada 3 segundos
            if ((DateTime.Now - lastPillAdded).TotalSeconds > 3)
            {
                var p = new Pill();
                pills.Add(p);
                p.Draw();
                lastPillAdded = DateTime.Now;
            }
        }
    }
}
