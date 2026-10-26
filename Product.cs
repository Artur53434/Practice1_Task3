namespace Task3
{
    struct Date(int day, int month, int year)
    {
        public int day = day;
        public int month = month;
        public int year = year;
        
        public override string ToString() => $"{day:D2}.{month:D2}.{year}";
        
        public static Date Parse(string text)
        {
            if (text == null) 
                throw new ArgumentNullException(nameof(text));

            string[] splitText = text.Split('.');
            if (splitText.Length != 3)
                throw new FormatException("Формат должен быть ДД.ММ.ГГГГ");

            int day = Convert.ToInt32(splitText[0]);
            int month = Convert.ToInt32(splitText[1]);
            int year = Convert.ToInt32(splitText[2]);

            if ((day > 31) || (month > 12))
                throw new FormatException("Некорректный номер дня или месяца.");

            return new Date(day, month, year);
        }
    }

    internal class Product
    {
        private string _name;
        private string _manufacturer;
        private decimal _price;
        private int _expirationDate;
        private Date _productionDate;

        public Product(string name, string manufacturer, decimal price, int expirationDate, Date productionDate)
        {
            _name = name;
            _expirationDate = expirationDate;
            _manufacturer = manufacturer;
            _price = price;
            _productionDate = productionDate;
        }
        public override string ToString()
        {
            return 
                $"Наименование: {_name}\n" +
                $"Производитель: {_manufacturer}\n" +
                $"Цена: {_price} руб.\n" +
                $"Срок годности: {_expirationDate} дней\n" +
                $"Дата производство: {_productionDate}\n";
        }
    }
}
