﻿namespace piyoz.uz.Dtos
{
    public class CreateRentalDto
    {
        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
