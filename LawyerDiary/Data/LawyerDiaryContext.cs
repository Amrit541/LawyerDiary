using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LawyerDiary.Models;

namespace LawyerDiary.Data
{
    public class LawyerDiaryContext : DbContext
    {
        public LawyerDiaryContext (DbContextOptions<LawyerDiaryContext> options)
            : base(options)
        {
        }

        public DbSet<LawyerDiary.Models.CaseDetails> CaseDetails { get; set; }

        public DbSet<LawyerDiary.Models.Lawyer> Lawyer { get; set; }

        public DbSet<LawyerDiary.Models.FeedBack> FeedBack { get; set; }

        public DbSet<LawyerDiary.Models.Login> Login { get; set; }
        public object Message { get; internal set; }
    }
}
