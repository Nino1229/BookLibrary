using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Izdavač")]
        public string PublisherName { get; set; }
    }
}
