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
            CreateMap<ViewBookVM, Book>();
            CreateMap<Book,ViewBookVM>();
            //CreateMap<List<ViewBookVM>, List<Book>>();
            CreateMap<Member, ViewMemberVM>();
            CreateMap<ViewMemberVM, Member>();
            //CreateMap<List<ViewMemberVM>, List<Member>>();
        }
    }
}
