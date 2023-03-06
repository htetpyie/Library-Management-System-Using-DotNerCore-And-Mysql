using LMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Data.Context {
    public class LMSDbContext : DbContext {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) {
        }
        public DbSet<BookDM> Book { get; set; }
        public DbSet<MemberDM> Member { get; set; }
        public DbSet<LoanDM> Loan { get; set; }
    }
}
