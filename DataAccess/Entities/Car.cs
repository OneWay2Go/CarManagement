namespace piyoz.uz.DataAccess.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CarBrand Brand { get; set; }

        public decimal Price { get; set; }

        public int ManufacturedYear { get; set; }
    }
}
