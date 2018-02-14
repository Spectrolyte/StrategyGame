using System;
using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Models
{
    public abstract class Entity
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}