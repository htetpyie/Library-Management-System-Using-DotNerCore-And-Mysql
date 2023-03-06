using LMS.Data.Models;
using LMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LMS.Service {
    public static class ChangeModel {
        public static BookVM Change(this BookDM reqModel) {
            BookVM model = new BookVM {
                BookId = reqModel.BookId,
                Author = reqModel.Author,
                ISBN = reqModel.ISBN,
                PublishDate = reqModel.PublishDate,
                Publisher = reqModel.Publisher,
                Title = reqModel.Title,
            };
            return model;
        }
    }
}
