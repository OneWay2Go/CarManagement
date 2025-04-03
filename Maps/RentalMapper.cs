using piyoz.uz.DataAccess.Entities;
using piyoz.uz.Dtos;
using Riok.Mapperly.Abstractions;

namespace piyoz.uz.Maps
{
    [Mapper]
    public partial class RentalMapper
    {
        public partial Rental RentalDtoToRental(CreateRentalDto dto);

        public partial RentalDto RentalToRentalDto(Rental rental);

        public partial void UpdateRental(CreateRentalDto dto, Rental rental);

        public partial IList<RentalDto> RentalListToRentalDtoList(IList<Rental> rentals);
    }
}
