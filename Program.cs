using Task3;

bool isExit = false;
List<Product> products = new List<Product>();

while (isExit == false)
{
    int selectedAction = Menu.SelectMenuItem();

    Console.Clear();

    switch (selectedAction)
    {
        case 0:
            products.Add(Menu.InputNewRecord());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nНовый продукт успешно добавлен.");
            Console.ResetColor();
            break;
        case 1:
            if (products.Count > 0)
                Menu.Print(products);
            else
                Console.WriteLine("Список пуст.");
            break;
        case 2:
            isExit = true;
            break;
    }

    if (isExit == false)
    {
        Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
        Console.ReadKey();
    }
}