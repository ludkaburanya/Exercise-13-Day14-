using System;
namespace z2
{
    delegate int ArithmeticOperations(int a, int b);
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите первое число:");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Введите второе число:");
                int b = int.Parse(Console.ReadLine());

                ArithmeticOperations ao = Addition;
                ao += Subtraction;
                ao += Division;

                Actions(a, b, ao);

                void Actions(int a, int b, ArithmeticOperations ao) => Console.WriteLine($"Результат выполнения делегата:{ao(a, b)}");

                static int Addition(int a, int b) => a + b;
                static int Subtraction(int a, int b) => a - b;
                static int Division(int a, int b) => a / b;
            }
            catch (FormatException fx)
            {
                Console.WriteLine("Ошибка!" + fx.Message);
            }

            catch (DivideByZeroException fx)
            {
                Console.WriteLine("Ошибка!" + fx.Message);
            }
            catch (Exception fx)
            {
                Console.WriteLine("Ошибка!" + fx.Message);
            }
            Console.ReadLine();
        }
    }
}