using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Models
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime EstablishDate { get; set; }
        public int Address { get; set; }
        public int Rating { get; set; }
        public int PublishedBooks { get; set; }
        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }
    }
}
