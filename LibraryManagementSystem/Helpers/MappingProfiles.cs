using AutoMapper;
using LMS.Data.Models;
using LMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Web.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookVM, BookDM>();
            CreateMap<BookDM,BookVM>();
            //CreateMap<List<ViewBookVM>, List<Book>>();
            CreateMap<MemberDM, MemberVM>();
            CreateMap<MemberVM, MemberDM>();
            //CreateMap<List<ViewMemberVM>, List<Member>>();
        }
    }
}
