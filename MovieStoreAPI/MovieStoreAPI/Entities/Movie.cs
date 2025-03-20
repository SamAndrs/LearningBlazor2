using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [Range(1,100)]
        public decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }

        [ValidateNever]
        public Genre? Genre { get; set; }
        public int GenreId { get; set; }
    }
}
