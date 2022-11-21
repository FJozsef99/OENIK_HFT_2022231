using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HNZ9CU_HFT_2022231.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [MaxLength]
        public string Name { get; set; }
        public int BirthDate { get; set; }
        public bool IsAlive { get; set; }
        public string Country { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
