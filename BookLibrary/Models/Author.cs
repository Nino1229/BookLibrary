using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Autor")]
        public string Name { get; set; }
    }
}
