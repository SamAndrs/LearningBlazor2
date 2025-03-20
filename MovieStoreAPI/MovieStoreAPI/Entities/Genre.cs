using System.ComponentModel.DataAnnotations;

namespace MovieStoreAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
