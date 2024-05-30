using System.Data;
using System.Net.Cache;
using System.Net.Http.Headers;

namespace Urok9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //обработка исключений
            //try { }
            //catch (Exception ex)
            //{
            //    throw ex; //для абсолютной обработки исключений
            //}
            //finally{ } //чтобы 100% код внутри него выполнился



            //Task1
            Money money1 = new Money(10, 50);
            Money money2 = new Money(5, 25);

            Console.WriteLine("Деньга 1: " + money1.ToString());
            Console.WriteLine("Деньга 2: " + money2.ToString());

            try
            {

                //Money m = money1 - new Money(100, 0);   //вызываем исключение

                int a = Convert.ToInt32(Console.ReadLine());
                Money sum1 = money1 / a;

                Money sum = money1 + money2;
                Console.WriteLine(sum.ToString());

                Money diff = money1 - money2;
                Console.WriteLine(diff.ToString());

                Money div = money1 / 2;
                Console.WriteLine(div.ToString());

                Money mul = money2 * 3;
                Console.WriteLine(mul.ToString());

                Money inc = ++money1;
                Console.WriteLine(inc.ToString());

                Money dec = --money2;
                Console.WriteLine(dec.ToString());

                Console.WriteLine("Money 1 > Money 2: " + (money1 > money2));
                Console.WriteLine("Money 1 == Money 2: " + (money1 == money2));
                Console.WriteLine("Money 1 < Money 2: " + (money1 < money2));

            }
            catch (BankrupException ex)
            {
                Console.WriteLine("Backrupt ex: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            //Task2
            try
            {
                int b = Convert.ToInt32(Console.ReadLine());
            }
            catch (OverflowException b)
            {
                Console.WriteLine("Неверный ввод: " + b.Message);
            }
            catch (FormatException b)
            {
                Console.WriteLine("Неверный ввод2: " + b.Message);
            }

            //Task3
            try
            {
                int c = int.Parse(Console.ReadLine());
                if (c < 18)
                {
                    throw new Task2("Нельзя");
                }
                Console.WriteLine("Доступ рзрешен");
            }
            catch (Exception c)
            {
                Console.WriteLine("НЕправильный формат " + c.Message);
            }

            //Task4
            var studentSystem = new StudentManagementSystem();

            studentSystem.AddStudent("Alice", 20);
            studentSystem.AddStudent("Kolya", 22);
            studentSystem.AddStudent("Bob", 21);

            studentSystem.Print();
            try
            {

            }
            catch (StudentNotFoundException ex)
            { 
                Console.WriteLine("Error: {ex.Message}");
            }
        }
    }
}
