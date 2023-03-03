using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Data.Models
{
    public class BaseModel
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
