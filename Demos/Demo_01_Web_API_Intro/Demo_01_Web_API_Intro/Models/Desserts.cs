namespace Demo_01_Web_API_Intro.Models
{
    public class Dessert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DessertType { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }

        public Dessert(int id, string name, string dessertType, decimal price, bool available)
        {
            Id = id;
            Name = name;
            DessertType = dessertType;
            Price = price;
            Available = available;
        }

        public static List<Dessert> Desserts = new List<Dessert>
        {
            new Dessert(1, "Chocolate Cake", "Cake", 10.50m, true),
            new Dessert(2, "Strawberry Cheesecake", "Cheesecake", 12.00m, true),
            new Dessert(3, "Lemon Tart", "Tart", 8.25m, true),
            new Dessert(4, "Apple Pie", "Pie", 9.75m, false),
            new Dessert(5, "Vanilla Ice Cream", "Ice Cream", 4.50m, true),
            new Dessert(6, "Chocolate Chip Cookie", "Cookie", 1.50m, true),
            new Dessert(7, "Blueberry Muffin", "Muffin", 2.75m, true),
            new Dessert(8, "Tiramisu", "Cake", 11.00m, true),
            new Dessert(9, "Pecan Pie", "Pie", 10.00m, false),
            new Dessert(10, "Carrot Cake", "Cake", 10.50m, true),
            new Dessert(11, "Raspberry Sorbet", "Sorbet", 4.00m, true),
            new Dessert(12, "Creme Brulee", "Custard", 6.50m, true),
            new Dessert(13, "Brownie", "Bar", 2.00m, true),
            new Dessert(14, "Peanut Butter Cookie", "Cookie", 1.75m, true),
            new Dessert(15, "Red Velvet Cake", "Cake", 11.50m, false),
            new Dessert(16, "Key Lime Pie", "Pie", 9.50m, true),
            new Dessert(17, "Banana Bread", "Bread", 7.00m, true),
            new Dessert(18, "Black Forest Cake", "Cake", 12.00m, true),
            new Dessert(19, "Mango Ice Cream", "Ice Cream", 4.75m, true),
            new Dessert(20, "Chocolate Eclair", "Pastry", 3.50m, true),
            new Dessert(21, "Oatmeal Raisin Cookie", "Cookie", 1.50m, true),
            new Dessert(22, "Pumpkin Pie", "Pie", 9.00m, false),
            new Dessert(23, "Cupcake", "Cupcake", 2.50m, true),
            new Dessert(24, "Bread Pudding", "Pudding", 6.00m, true),
            new Dessert(25, "Gelato", "Ice Cream", 4.25m, true)
        };
    }
}
