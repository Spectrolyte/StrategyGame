using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Models;
using StrategyGame.DataTransferObjects;
using System.Text;

namespace StrategyGame.Controllers
{
    public class UserAccountsController : Controller
    {
        private readonly GameModelContext _context;
        public UserAccountsController(GameModelContext gameModelContext)
        {
            _context = gameModelContext;
        }

        [HttpGet]
        [Route("api/UserAccounts/GetUserAccount")]
        public UserAccount GetUserAccount(Guid id)
        {
            return _context.UserAccounts.SingleOrDefault(ua => ua.Id == id);
        }

        [HttpPost]
        [Route("api/UserAccounts/CreateUserAccount")]
        public Guid CreateUserAccount([FromBody] CreateUserAccountDTO createUserAccountDTO)
        {
            byte[] salt = new byte[128/8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: createUserAccountDTO.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            var userAccount = new UserAccount
            {
                Name = createUserAccountDTO.Name,
                Email = createUserAccountDTO.Email,
                UserAccountAuthentication = new UserAccountAuthentication
                {
                    EncryptedPassword = hashed,
                    PasswordSalt = Convert.ToBase64String(salt)
                }
            };

            _context.UserAccounts.Add(userAccount);
            _context.UserAccountAuthentications.Add(userAccount.UserAccountAuthentication);
            _context.SaveChanges();

            return userAccount.Id;
        }

        [HttpGet]
        [Route("api/UserAccounts/ValidateUserLogin")]
        public bool ValidateUserLogin (string email, string password)
        {
            // retrieve user account info based on email
            var userAccount =  _context.UserAccounts.SingleOrDefault(ua => ua.Email == email);
            var userAccountGuid = userAccount.Id;
            // retrieve password info based on user account guid
            var hashInfo = _context.UserAccountAuthentications.SingleOrDefault(ua => ua.UserAccount.Id == userAccountGuid);
            
            // hash info password with stored salt string
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(hashInfo.PasswordSalt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // if they match, return true
            if (hashed == hashInfo.EncryptedPassword)
            {
                return true;
            }
            
            return false;
        }
    }
}