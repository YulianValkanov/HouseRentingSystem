﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentingSystem.Infrastructure.Data
{
    public class House
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(150)]
        public string Address { get; set; } = null!;

        [Required]
        [MinLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        [MinLength(200)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Column(TypeName="money")]
        [Precision(19,2)]

        public decimal PricePerMonth { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; }


        public string? RenterId { get; set; }
        [ForeignKey(nameof(RenterId))]
        public IdentityUser? Renter { get; set; }


        public bool isActive { get; set; } = true;




    }
}