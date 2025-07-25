
using System.Net;
using System.Numerics;

namespace Representational_State_Transfer.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string mail { get; set; }
        public required string gender { get; set; }
        public required Address Address { get; set; }
        public required long phone { get; set; }
        public string? description { get; set; }
    }


}