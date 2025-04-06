﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Services;
using WebApplication1.Services.Interface;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/home")]
    public class HomeController(IUserService usersService, IAddressService _addressService) : Controller
    {
        [HttpPost("add")]
        public IActionResult AddUser([FromBody] InsertUserDto userDto)
        {
            try
            {
                usersService.AddUser(userDto);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAllUser()
        {
            try
            {
                var users = usersService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                usersService.GetById(id);
                return Ok("user fetch successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                usersService.DeleteUser(id);
                return Ok("user deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                usersService.UpdateUser(id, userDto);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-address")]
        public IActionResult AddAddress(AddressDto dto)
        {
            try
            {
                var result = _addressService.AddAddress(dto);
                if (result)
                {
                    return Ok("Address added successfully.");
                }
                else
                {
                    return BadRequest("Failed to add address.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
