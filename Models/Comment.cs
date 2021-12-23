using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace wsei_asp.net.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1024)]
        [Required]
        public string Content { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }


        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        public Post Post { get; set; }

        [Required]
        public bool Published { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Comment()
        {
            this.CreatedAt = DateTime.Now;
            this.Published = true;
        }
    }
}
