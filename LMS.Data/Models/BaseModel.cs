using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Data.Models
{
    public class BaseModel
    {
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
