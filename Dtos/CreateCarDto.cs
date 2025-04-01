using piyoz.uz.DataAccess.Entities;

namespace piyoz.uz.Dtos
{
    public class CreateCarDto
    {
        public string Name { get; set; }

        public CarBrand Brand { get; set; }

        public decimal Price { get; set; }

        public int ManufacturedYear { get; set; }
    }
}
