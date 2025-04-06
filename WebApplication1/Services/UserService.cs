﻿using System.Reflection;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Model;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddUser(InsertUserDto userDto)
        {
            try
            {
                var user = new User 
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    ImageURL = userDto.ImageURL,
                    RegisteredDate = userDto.RegisteredDate,
                    IsActive = true
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user: " + ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                    throw new Exception("User not found");

                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception("Error deleting user: " + ex.Message);
            }
        }

        public List<GetAllUser> GetAllUsers()
        {
            try
            {
                var users = _context.Users.ToList();

                if (users == null)
                    throw new Exception("No active users found");

                //var result = new GetAllUser()
                //{
                //    FirstName = users.FirstName,
                //    LastName = users.LastName,
                //    Gender = users.Gender,
                //    ImageURL = users.ImageURL,
                //    RegisteredDate = users.RegisteredDate
                //};

                //return result;

                List<GetAllUser> allUsers = new List<GetAllUser>();

                foreach (var user in users)
                {
                    allUsers.Add(new GetAllUser
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Gender = user.Gender,
                        ImageURL = user.ImageURL,
                        RegisteredDate = user.RegisteredDate,
                    });
                }

                return allUsers;
                           
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }

        public GetAllUser GetById(Guid id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                throw new Exception("No active users found");

            var result = new GetAllUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                ImageURL = user.ImageURL,
                RegisteredDate = user.RegisteredDate
            };

            return result;
        }

        public void UpdateUser(Guid id, UpdateUserDto userDto)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                    throw new Exception("User not found");

                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Gender = userDto.Gender;
                user.ImageURL = userDto.ImageURL;

                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user: " + ex.Message);
            }
        }
    }
}
