﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternetShop.ViewModels
{
    public class CreateProductViewModel: IProductViewModelImage
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Please Choose a Category")]
        public int CategoryId { get; set; }

    }
}
