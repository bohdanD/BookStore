using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        [JsonIgnore]
        public virtual Author Author { get; set; }
    }
}
