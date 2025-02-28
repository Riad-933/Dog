﻿using System.ComponentModel.DataAnnotations;

namespace DogMVC.Areas.Admin.ViewModels
{
    public class AdminLoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
