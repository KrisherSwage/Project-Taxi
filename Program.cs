using System;
using System.Collections.Generic;
using System.Linq;

namespace Taxi
{
    public class Test
    {
        public int Check()
        {
            int prvrk;
            
            while (true) //цикл проверки числа
            {
                
                if ((int.TryParse(Console.ReadLine(), out int x)) && (x >= 1) && (x <= 1000)) //условие проверки
                {
                    prvrk = x;
                    break; //выход из цикла проверки
                }
            }
            return prvrk;
        }

        public int Check2()
        {
            int prvrk;
            
            while (true) //цикл проверки числа
            {

                
                if ((int.TryParse(Console.ReadLine(), out int x)) && (x >= 1) && (x <= 10000)) //условие проверки
                {
                    prvrk = x;
                    break; //выход из цикла проверки
                }
            }
            return prvrk;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();

            Console.WriteLine("Введите N");
            Console.WriteLine("(Целое число не меньше 1 и не больше 1000)");
            int N;
            N = test.Check(); //количество людей
            
            List<int> distance = new List<int>(); //список (динамический массив) для расстояния
            List<int> price = new List<int>(); //список (динамический массив) для цен

            int i, j, k;
            Console.WriteLine("Введите дистанцию");
            Console.WriteLine("(Целые числа не меньше 1 и не больше 1000)");
            for (i = 0; i < N; i++)
            {
                distance.Add(test.Check());
            }

            Console.WriteLine("Введите цену");
            Console.WriteLine("(Целые числа не меньше 1 и не больше 10000)");
            for (j = 0; j < N; j++)
            {  
                price.Add(test.Check2());
            }

         // List<int> Sortdistance = new List<int>();
         // List<int> Sortprice = new List<int>();
         // Sortdistance = distance;                //нерабочее копирование (происходит передача по ссылке, а нужна по значению)
         // Sortprice = price;

            List<int> Sortprice = price.ToList(); //правильное копирование
            List<int> Sortdistance = distance.ToList();
            List<int> Dupliprice = price.ToList();

            for (i = 0; i < N - 1; i++) //сортировка дистанции по убыванию в отдельный список
            {
                for (j = 0; j < N - 1; j++)
                    if (Sortdistance[j + 1] > Sortdistance[j])
                    {
                        int tmp = Sortdistance[j];
                        Sortdistance[j] = Sortdistance[j + 1];
                        Sortdistance[j + 1] = tmp;
                    }
            }

            for (i = 0; i < N - 1; i++) //сортировка цен по возрастанию в отдельный список
            {
                for (j = 0; j < N - 1; j++)
                    if (Sortprice[j + 1] < Sortprice[j])
                    {
                        int tmp = Sortprice[j];
                        Sortprice[j] = Sortprice[j + 1];
                        Sortprice[j + 1] = tmp;
                    }
            }

            Console.WriteLine();

            for (i = 0; i < N; i++) //логика вывода =D
            {
                for (j = 0; j < N; j++)
                {
                    if(distance[i] == Sortdistance[j])
                    {
                        for (k = 0; k < N; k++)
                        {
                            if (Sortprice[j] == Dupliprice[k])
                            {
                                Console.Write($"{k+1} ");
                                Dupliprice[k] = 0; //чтобы номер такси выводился единажды
                                break;
                            }
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }
}