using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HNZ9CU_HFT_2022231.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime RelaseDate { get; set; }
        public int PagenNumber { get; set; }
        public int Rating { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }

        [NotMapped]
        public virtual Author Author { get; set; }

        [NotMapped]
        public virtual Publisher Publisher { get; set; }
    }
}
