using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Data.ViewModels
{
    public class DataTableModel
    {
        public string SortColumn { get; set; }
        public string SortedDirection{ get; set; }
        public string SearchValue{ get; set; }
        public int PageNumber{ get; set; }
        public int Skip{ get; set; }
        public int RowCount{ get; set; }
        public List<BookVM> ResultList { get; set; }

    }
}
