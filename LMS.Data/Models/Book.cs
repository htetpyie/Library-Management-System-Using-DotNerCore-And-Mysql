using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class Book : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Author { get; set; }
        [StringLength(100)]
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        [StringLength(20)]
        public string ISBN { get; set; }
    }
}
