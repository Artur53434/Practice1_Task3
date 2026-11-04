namespace Task3
{
    internal sealed class Product
    {
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
                _price = value;
            }
        }

        public string Name { get; }
        public string Manufacturer { get; }
        public int ShelfLifeDays { get; }
        public DateOnly ProductionDate { get; }

        public DateOnly ExpirationDate => ProductionDate.AddDays(ShelfLifeDays);

        public Product(string name, string manufacturer, decimal price, int shelfLifeDays, DateOnly productionDate)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(manufacturer);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(shelfLifeDays);

            Name = name;
            Manufacturer = manufacturer;
            ShelfLifeDays = shelfLifeDays;
            ProductionDate = productionDate;
            Price = price;
        }

        public bool IsSpoiled(DateOnly currentDate) => ExpirationDate < currentDate;

        public bool IsSpoiled() => IsSpoiled(DateOnly.FromDateTime(DateTime.Today));

        public override string ToString() => string.Join(Environment.NewLine,
            $"Наименование: {Name}",
            $"Производитель: {Manufacturer}",
            $"Цена: {Price:F2} руб.",
            $"Срок годности: {ShelfLifeDays} дней",
            $"Дата производства: {ProductionDate:dd.MM.yyyy}");
    }
}