using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Models
{
    public class UserAccountAuthentication : Entity
    {
        [Required]
        public string EncryptedPassword { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
        [Required]
        public UserAccount UserAccount { get; set; }
    }
}