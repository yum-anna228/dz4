namespace dz
{
    internal class Program
    {
        /// <summary>
        ///  Метод для вывода массива
        /// </summary>
        static void PrintArray(int[] array)
        {
            foreach (var number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Метод CalculateArrayProperties`:
        ///Принимает массив чисел через params int[] numbers.
        ///Использует ref для передачи переменной product, чтобы вернуть произведение.
        ///Использует out для передачи переменной average, чтобы вернуть среднее арифметическое.
        /// </summary>
        static int CalculateArrayProperties(ref int product, out double average, params int[] numbers)
        {
            int sum = 0;
            product = 1; 
            foreach (var number in numbers)
            {
                sum += number;
                product *= number;
            }
            average = (double)sum / numbers.Length;

            return sum; 
        }
        /// <summary>
        ///  Рисуем цифры от 0 до 9 в виде символов #
        /// </summary>
        static void DrawNumber(int number)
        {
            switch (number)
            {
                case 0: Console.WriteLine("###\n# #\n# #\n# #\n###"); break;
                case 1: Console.WriteLine("  #\n  #\n  #\n  #\n  #"); break;
                case 2: Console.WriteLine("###\n  #\n###\n#  \n###"); break;
                case 3: Console.WriteLine("###\n  #\n###\n  #\n###"); break;
                case 4: Console.WriteLine("# #\n# #\n###\n  #\n  #"); break;
                case 5: Console.WriteLine("###\n#  \n###\n  #\n###"); break;
                case 6: Console.WriteLine("###\n#  \n###\n# #\n###"); break;
                case 7: Console.WriteLine("###\n  #\n  #\n  #\n  #"); break;
                case 8: Console.WriteLine("###\n# #\n###\n# #\n###"); break;
                case 9: Console.WriteLine("###\n# #\n###\n  #\n###"); break;
            }
        }
        /// <summary>
        /// Перечисление для уровня ворчливости
        /// </summary>
        public enum Ворчливость
        {
            Низкий,
            Средний,
            Высокий
        }
        /// <summary>
        /// Структура Дед
        /// </summary>
        public struct Ded
        {
            public string Name;
            public Ворчливость Level;
            public string[] Phrases;
            public int fingal;
            /// <summary>
            /// Конструктор для инициализации деда
            /// </summary>
            public Ded(string name, Ворчливость level, string[] phrases)
            {
                Name = name;
                Level = level;
                Phrases = phrases;
                fingal = 0;
            }
            /// <summary>
            /// Метод для подсчета фингалов
            /// </summary>
            public int Countfingal(params string[] swearWords)
            {
                foreach (var phrase in Phrases)
                {
                    foreach (var swearWord in swearWords)
                    {
                        if (phrase.Contains(swearWord, StringComparison.OrdinalIgnoreCase))
                        {
                            fingal++;
                        }
                    }
                }
                return fingal;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Random random = new Random();
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 101); 
            }
            Console.WriteLine("Исходный массив:");
            PrintArray(numbers);
            Console.Write("Введите первое число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int index1 = Array.IndexOf(numbers, firstNumber);
            int index2 = Array.IndexOf(numbers, secondNumber);
            if (index1 != -1 && index2 != -1)
            {
                int t = numbers[index1];
                numbers[index1] = numbers[index2];
                numbers[index2] = t;
                Console.WriteLine("Массив после обмена:");
                PrintArray(numbers);
            }
            else
            {
                Console.WriteLine("Одно или оба числа не найдены в массиве.");
            }

            //Написать метод, где в качества аргумента будет передан массив(ключевое слово
            //params). Вывести сумму элементов массива(вернуть). Вывести(ref) произведение
            //массива.Вывести(out) среднее арифметическое в массиве.
            Console.WriteLine("Задание 2");
            int product = 1; 
            double average;

            int sum = CalculateArrayProperties(ref product, out average, 1, 2, 3, 4, 5);
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Произведение: {product}");
            Console.WriteLine($"Среднее арифметическое: {average}");

            //Пользователь вводит числа.Если числа от 0 до 9, то необходимо в консоли нарисовать
            // изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
            //должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
            //пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
            //завершает работу, если пользователь введёт слово: exit или закрыть(оба варианта
            //должны сработать) - консоль закроется.
            Console.WriteLine("Задание 3");
            while (true)
            {
                Console.Write("Введите число (или 'exit' для выхода): ");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("закрыть", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(input, out int number) && number >= 0 && number <= 9)
                {
                    DrawNumber(number);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.WriteLine("Ошибка: число должно быть от 0 до 9.");
                    System.Threading.Thread.Sleep(3000);
                    Console.ResetColor();
                }
            }

            //Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив
            //фраз для ворчания(прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
            //бабки = 0 по умолчанию. Создать 5 дедов.У каждого деда - разное количество фраз для
            //ворчания.Напишите метод(внутри структуры), который на вход принимает деда,
            //список матерных слов (params).Если дед содержит в своей лексике матерные слова из
            //списка, то бабка ставит фингал за каждое слово.Вернуть количество фингалов.
            Console.WriteLine("Задание 4");
            Ded ded1 = new Ded("Дед Никита", Ворчливость.Средний, new string[] { "Что за гадость!", "Проститутки!" });
            Ded ded2 = new Ded("Дед Игорь", Ворчливость.Средний, new string[] { "Гады!", "С ума посходили!!" });
            Ded ded3 = new Ded("Дед Вася", Ворчливость.Высокий, new string[] { "Как же вы меня достали!", "Афигевшие!" });
            Ded ded4 = new Ded("Дед Паша", Ворчливость.Низкий, new string[] { "Вы козлы!" });
            Ded ded5 = new Ded("Дед Данил", Ворчливость.Средний, new string[] { "Проститутки!", "Гады!", "Идиоты!" });

            // Список матерных слов
            string[] swearWords = { "проститутки", "гады", "идиоты" };

            // Подсчет фингалов для каждого деда
            Console.WriteLine($"{ded1.Name} получил фингалов: {ded1.Countfingal(swearWords)}");
            Console.WriteLine($"{ded2.Name} получил фингалов: {ded2.Countfingal(swearWords)}");
            Console.WriteLine($"{ded3.Name} получил фингалов: {ded3.Countfingal(swearWords)}");
            Console.WriteLine($"{ded4.Name} получил фингалов: {ded4.Countfingal(swearWords)}");
            Console.WriteLine($"{ded5.Name} получил фингалов: {ded5.Countfingal(swearWords)}");


        }
    }
    
}
