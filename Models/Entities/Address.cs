using Microsoft.EntityFrameworkCore;

namespace Representational_State_Transfer.Models.Entities
{
    [Owned]
    public class Address
    {
        public required string street { get; set; }
        public required string city { get; set; }
        public required string country { get; set; }
    }
}
