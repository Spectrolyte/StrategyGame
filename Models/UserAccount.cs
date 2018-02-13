using System;
using Microsoft.EntityFrameworkCore;

namespace StrategyGame.Models
{
    public class UserAccount : Entity
    {
        public string Name { get; set; }
    }
}