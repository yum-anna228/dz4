namespace tumakov
{
    internal class Program
    {
        /// <summary>
        /// Метод для нахождения наибольшего из двух чисел
        /// </summary> 
        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        /// <summary>
        /// Метод для обмена значениями двух переменных
        /// </summary>
        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;   
        }
        /// <summary>
        /// Метод для вычисления факториала
        /// </summary>
        static bool TryCalculateFactorial(int number, out long factorial)
        {
            factorial = 1; 
            if (number < 0)
            {
                return false;
            }
            try
            {
                for (int i = 1; i <= number; i++)
                {
                    factorial = checked(factorial * i); 
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }
        /// <summary>
        /// Метод для вычисления факториала
        /// </summary>
        static long Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
        /// <summary>
        /// Метод для вычисления НОД двух натуральных чисел
        /// </summary>
        static int НОД(int a, int b)
        {
            if (b == 0)
                return a; 
            return НОД(b, a % b); 
        }
        /// <summary>
        /// Метод для вычисления НОД трёх натуральных чисел
        /// </summary>
        static int НОД3(int a, int b, int c)
        {
            return НОД(НОД(a, b), c); // Сначала находим НОД двух чисел, затем с третьим
        }
        /// <summary>
        /// Рекурсивный метод для вычисления n-го числа Фибоначчи
        /// </summary> 
        static int Fibonacci(int k)
        {
            if (k == 1 || k == 2)
                return 1;
            return Fibonacci(k - 1) + Fibonacci(k - 2);
        }
        static void Main(string[] args)
        {
            //Написать метод, возвращающий наибольшее из двух чисел. Входные
            //параметры метода – два целых числа.Протестировать метод.
            Console.WriteLine("Упражнение 5.1");
            Console.WriteLine("Введите два целых числа:");

            Console.Write("Первое число: ");
            int first = int.Parse(Console.ReadLine());

            Console.Write("Второе число: ");
            int second = int.Parse(Console.ReadLine());

            int maxNumber = Max(first, second);
            Console.WriteLine($"Наибольшее из двух чисел: {maxNumber}");

            //Написать метод, который меняет местами значения двух передаваемых
            //параметров.Параметры передавать по ссылке. Протестировать метод.
            Console.WriteLine("Упражнение 5.2");
            Console.Write("Введите первое число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"До обмена: a = {firstNumber}, b = {secondNumber}");
            Swap(ref firstNumber, ref secondNumber);
            Console.WriteLine($"После обмена: a = {firstNumber}, b = {secondNumber}");

            //Написать метод вычисления факториала числа, результат вычислений
            //передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
            //если в процессе вычисления возникло переполнение, то вернуть значение false.Для
            //отслеживания переполнения значения использовать блок checked.
            Console.WriteLine("Упражнение 5.3");
            Console.Write("Введите число для вычисления факториала: ");
            int number = int.Parse(Console.ReadLine());
            if (TryCalculateFactorial(number, out long result))
            {
                Console.WriteLine($"Факториал {number} = {result}");
            }
            else
            {
                Console.WriteLine("Произошло переполнение при вычислении факториала.");
            }

            //Написать рекурсивный метод вычисления факториала числа.
            Console.WriteLine("Упражнение 5.4");
            Console.Write("Введите число для вычисления факториала: ");
            int number4 = int.Parse(Console.ReadLine());

            if (number4 < 0)
            {
                Console.WriteLine("Факториал не определен для отрицательных чисел");
            }
            else
            {
                long factorial = Factorial(number4);
                Console.WriteLine($"Факториал {number4} равен {factorial}");
            }

            //Написать метод, который вычисляет НОД двух натуральных чисел
            //(алгоритм Евклида).Написать метод с тем же именем, который вычисляет НОД трех
            //натуральных чисел.
            Console.WriteLine("Домашнее задание 5.1");
            Console.Write("Введите первое натуральное число: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Введите второе натуральное число: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Введите третье натуральное число (или нажмите Enter, чтобы пропустить): ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                int result2 = НОД(num1, num2);
                Console.WriteLine($"НОД {num1} и {num2} = {result2}");
            }
            else
            {
                int num3 = int.Parse(input);
                int result3 = НОД3(num1, num2, num3);
                Console.WriteLine($"НОД {num1}, {num2} и {num3} = {result3}");
            }

            //Написать рекурсивный метод, вычисляющий значение n - го числа
            //ряда Фибоначчи.Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
            //13... Для таких чисел верно соотношение Fk = Fk - 1 + Fk - 2.
            Console.WriteLine("Домашнее задание 5.2");
            Console.Write("Введите номер числа Фибоначчи: ");
            int k = int.Parse(Console.ReadLine());

            if (k <= 0)
            {
                Console.WriteLine("Введите положительное число.");
            }
            else
            {
                int res = Fibonacci(k);
                Console.WriteLine($"Число Фибоначчи под номером {k} равно {res}");
            }
        }  
    }
}
