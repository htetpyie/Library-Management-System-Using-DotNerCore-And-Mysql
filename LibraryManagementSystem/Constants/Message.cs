using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Web.Constants
{
    public  class Message
    {
        #region For Book
        public string BookSaveSuccess = "Book is saved successfully!";
        public string BookUpdateSuccess = "Book is updated successfully!";
        public string BookDeleteSuccess = "Book is deleted successfully!";
        public string BookDuplicate = "The book is already existed!";
        public string BookSaveError = "Book save error!";
        public string BookUpdateError = "Book update error!";
        public string BookDeleteError = "Book delete error!";
        public string BookNotFound = "Book not founded error!";
        public string BookMessageTitle = "Book";
        #endregion

        #region For Member
        public string MemberSaveSuccess = "Member is saved successfully!";
        public string MemberUpdateSuccess = "Member is updated successfully!";
        public string MemberDeleteSuccess = "Member is deleted successfully!";
        public string MemberDuplicate = "The member is already existed!";
        public string MemberSaveError = "Member save error!";
        public string MemberUpdateError = "Member update error!";
        public string MemberDeleteError = "Member delete error!";
        public string MemberNotFound = "Member not found error!";
        #endregion
    }
}
