﻿using System.ComponentModel.DataAnnotations;

namespace ShopProduct.Api.Dtos
{
    public class ProductUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
