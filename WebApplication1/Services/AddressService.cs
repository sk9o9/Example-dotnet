using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Model;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _context;
        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddAddress(AddressDto addressDto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == addressDto.PersonId);

            if (user is null) throw new Exception("User not found");

            Address address = new Address
            {
                Id = Guid.NewGuid(),
                Address1 = addressDto.Address1,
                Address2 = addressDto.Address2,
                City = addressDto.City,
                State = addressDto.State,
                Zip = addressDto.Zip,
                PersonId = addressDto.PersonId
            };

            _context.Address.Add(address);

            if (_context.SaveChanges() > 0) return true;
            return false;

        }
    }
}
