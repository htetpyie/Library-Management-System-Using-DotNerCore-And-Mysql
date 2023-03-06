using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Data.Models
{
    [Table("Books")]
    public class BookDM 
    {
        [Key]
        public int BookId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        public DateTime PublishDate { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }
       
    }
}
