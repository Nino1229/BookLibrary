using MessagePack;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        [DisplayName("Naziv")]
        public string Title { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [DisplayName("Godina izdavanja")]
        public string DatePublished { get; set; }

        [DisplayName("Država izdavanja")]
        public string PublishingCountry { get; set; }

        [DisplayName("Količina na stanju")]
        public int Quantity { get; set; }

        public int AuthorId { get; set; }
        public int PublisherId { get; set; }


        [ForeignKey("AuthorId")]
        [DisplayName("Autor")]
        public Author? Author { get; set; }

        [ForeignKey("PublisherId")]
        [DisplayName("Izdavač")]
        public Publisher? Publisher { get; set; }

        public int CurrentQuantity()
        {
            int ck = 0;
            ck = Quantity - 1;
            return ck;
        }
    }
}
