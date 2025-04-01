using piyoz.uz.DataAccess.Entities;
using piyoz.uz.Dtos;
using Riok.Mapperly.Abstractions;

namespace piyoz.uz.Maps
{
    [Mapper]
    public partial class DriverMapper
    {
        public partial DriverDto DriverToDriverDto(Driver driver);

        public partial Driver DriverDtoToDriver(DriverDto dto);

        public partial void UpdateDriver(DriverDto dto, Driver driver);

        public partial IList<DriverDto> DriverListToDriverDtoList(IList<Driver> drivers);
    }
}
