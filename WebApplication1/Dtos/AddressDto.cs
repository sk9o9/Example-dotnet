using System.ComponentModel.DataAnnotations;
using WebApplication1.Model;

namespace WebApplication1.Dtos
{
    public class AddressDto
    {
        [Required] 
        public string Address1{get;set;}
        [Required] 
        public string Address2{get;set;}
        [Required] 
        public string City{get;set;}
        [Required] 
        public string State{get;set;}
        [Required] 
        public string Zip{get;set;}
        [Required] 
        public Guid PersonId { get; set; }

    }
}
