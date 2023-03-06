using LMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Data.Context {
    public class DbContextLMS : DbContext {
        public DbContextLMS(DbContextOptions<DbContextLMS> options) : base(options) {
        }
        public DbSet<BookDM> Book { get; set; }
        public DbSet<MemberDM> Member { get; set; }
        public DbSet<LoanDM> Loan { get; set; }
    }
}
