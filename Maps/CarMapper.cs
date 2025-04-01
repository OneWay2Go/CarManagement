using piyoz.uz.DataAccess.Entities;
using piyoz.uz.Dtos;
using Riok.Mapperly.Abstractions;

namespace piyoz.uz.Maps
{
    [Mapper]
    public partial class CarMapper
    {
        public partial CreateCarDto CarToCarDto(Car car);

        public partial Car CarDtoToCar(CreateCarDto dto);

        public partial void UpdateCar(CreateCarDto dto, Car car);

        public partial IList<CreateCarDto> CarListToCarDtoList(IList<Car> cars);
    }
}
