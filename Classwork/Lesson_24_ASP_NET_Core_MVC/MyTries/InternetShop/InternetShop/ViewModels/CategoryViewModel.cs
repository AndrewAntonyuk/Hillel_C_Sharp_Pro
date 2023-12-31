﻿using System.ComponentModel.DataAnnotations;

namespace InternetShop.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
