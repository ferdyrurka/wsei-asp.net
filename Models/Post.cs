using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using wsei_asp.net.Util;

namespace wsei_asp.net.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string Title { get; set; }

        [MaxLength(10000)]
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool Published { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Post()
        {
            this.CreatedAt = DateTime.Now;
        }

        public string getShortContent()
        {
            return this.Content.Truncate(this.Content.Length > 1024 ? 1024 : this.Content.Length);
        }
    }
}
