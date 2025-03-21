﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreGUI.Models
{
    public class Movie
    {
        public  int Id { get; set; }

        [Required(ErrorMessage = "Movie Name is Required.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public int GenreId { get; set; }

        [ValidateNever]
        public Genre? Genre { get; set; }

        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100")]
        public decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
