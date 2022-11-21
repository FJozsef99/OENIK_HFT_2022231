using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HNZ9CU_HFT_2022231.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int Price { get; set; }
        
        public int RelaseDate { get; set; }
        public int PagenNumber { get; set; }
        public double Rating { get; set; }

        [ForeignKey(nameof(Author))]
        [Required]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }
    }
}
