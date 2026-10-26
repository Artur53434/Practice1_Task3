namespace Task3
{
    internal static class Menu
    {
        private static int _position = 0;
        private const string _line = "---------------------------------------------------------------";

        private static readonly string[] _menuItems =
        [
            "1. Добавить запись",
            "2. Вывести все записи",
            "0. Выход"
        ];
        public static int SelectMenuItem()
        {
            Console.CursorVisible = false;
            ConsoleKey key;

            do
            {
                PrintMenu();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    _position--;
                    if (_position < 0) 
                        _position = _menuItems.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _position++;
                    if (_position >= _menuItems.Length)
                        _position = 0;
                }

            } while (key != ConsoleKey.Enter);
            
            Console.CursorVisible = true;
            
            return _position;
        }
        public static void PrintMenu()
        {
            Console.Clear();

            Console.WriteLine("Для перемещения по меню используйте стрелки вверх и вниз.");
            Console.WriteLine("Для выбора пункта меню нажмите enter.");
            Console.WriteLine(_line);

            for (int i = 0; i < _menuItems.Length; i++)
            { 
                if (i == _position)
                {
                    Console.WriteLine($"-> {_menuItems[i]}");
                }
                else
                {
                    Console.WriteLine($"   {_menuItems[i]}");
                }
            }
        }
        public static void Input<T>(string text, out T value, Func<string, T>? customConvert = null)
        {
            while (true)
            {
                Console.Write(text);
                string? input = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Red;
                try
                {
                    if (customConvert != null)
                    {
                        value = customConvert(input);
                    }
                    else
                    {
                        value = (T)Convert.ChangeType(input, typeof(T))!;
                    }
                    return;
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Некорректный формат для этого типа.");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Некорректный формат числа или даты.");
                    if (customConvert != null) Console.WriteLine(e.Message);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Значение слишком велико или мало.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Пустой ввод не допускается.");
                }
                finally
                {
                    Console.ResetColor();
                }
            }
        }
        public static Product InputNewRecord()
        {
            Console.WriteLine("""
                Введите данные о продукте.
                "Наименование" и "Производитель" - строки.
                "Цена" - положительное вещественное число(через запятую).
                "Срок годности" - целое число дней.
                "Дата производства" - дата в формате ДД.ММ.ГГГГ.
                """);
            Console.WriteLine(_line);

            Input("Введите наименование: ", out string name);
            Input("Введите производителя: ", out string manufacturer);
            Input("Введите цену: ", out decimal price);
            Input("Введите срок годности: ", out int expirationDate);
            Input("Введите дату производства: ", out Date productionDate, Date.Parse);
            
            return new Product(name, manufacturer, price, expirationDate, productionDate);
        }

        public static void Print(List<Product> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine($"{i + 1} продукт: ");
                Console.WriteLine(values[i]);
                Console.WriteLine(_line);
            }
        }
    }
}
