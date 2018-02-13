using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StrategyGame.Models;

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
        public UserAccount CreateUserAccount((string name, string email, string password) userAccountData)
        {
            var userAccount = new UserAccount
            {
                Name = userAccountData.name,
                Email = userAccountData.email,
                UserAccountAuthentication = new UserAccountAuthentication
                {
                    EncryptedPassword = "TODO",
                    PasswordSalt = "TODO"
                }
            };
            _context.UserAccounts.Add(userAccount);
            _context.SaveChanges();

            return userAccount;
        }
    }
}