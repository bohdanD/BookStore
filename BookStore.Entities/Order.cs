using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
