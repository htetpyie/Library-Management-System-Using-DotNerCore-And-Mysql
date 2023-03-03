using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.ViewModels
{
    public class ViewBookVM
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [Required]
        [Display(Name ="ISBN Number")]
        public string ISBN { get; set; }

        public string Description { get; set; }
    }
}
