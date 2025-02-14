﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LMS.Data.Models
{
    [Table("Loans")]
    public class LoanDM
    {
        [Key]
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
