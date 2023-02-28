using LMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Data.Context
{
    public class DbContextLMS : DbContext
    {
        public DbContextLMS( DbContextOptions<DbContextLMS> options) : base(options)
        {
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Loan> Loan { get; set; }
    }
}
