using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Models
{
    public class UserAccount : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public UserAccountAuthentication UserAccountAuthentication { get; set; }
    }
}