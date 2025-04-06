using WebApplication1.Dtos;

namespace WebApplication1.Services.Interface
{
    public interface IAddressService
    {
        bool AddAddress(AddressDto addressDto);
    }
}
