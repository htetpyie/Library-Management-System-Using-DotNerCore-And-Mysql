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
                Id = reqModel.Id,
                Author = reqModel.Author,
                Description = reqModel.Description,
                ISBN = reqModel.ISBN,
                PublishedDate = reqModel.PublishedDate,
                Publisher = reqModel.Publisher,
                Title = reqModel.Title,
            };
            return model;
        }
    }
}
