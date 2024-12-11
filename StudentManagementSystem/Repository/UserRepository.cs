﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit.Cryptography;
using StudentManagementSystem.DTO;
using StudentManagementSystem.Entities;
using StudentManagementSystem.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                                 .Include(u => u.UserRole)
                                 .ThenInclude(z => z.Role)
                                 .SingleOrDefaultAsync(u => u.Email == email);
        }


        public async Task<User> GetUserByEmailForgotPassword(string email)
        {
            var data = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (data == null) throw new Exception("User Not found");
            return data;
        }

        public async Task<OTP> SaveOTP(OTP oTP)
        {
            await _context.OTPs.AddAsync(oTP);
            await _context.SaveChangesAsync();
            return oTP;
        }

        public async Task<OTP> CheckOTPExits(string otp)
        {
            var check = await _context.OTPs.FirstOrDefaultAsync(x => x.Code == otp);
            if (check == null) throw new Exception("OTP Not Found");
            return check;
        }

        public async Task<User> ChangePassword(ChangePasswordDTO dTO)
        {
            var data = await _context.Users.FirstOrDefaultAsync(x => x.Email == dTO.Email);
            if (data == null) throw new Exception("User Not Found");
            data.Password = dTO.Password;
            _context.Users.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }
    }
}

