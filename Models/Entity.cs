using System;
using System.ComponentModel.DataAnnotations;

namespace StrategyGame.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        
        [Timestamp]
        public DateTime Created { get; set; }
    }
}