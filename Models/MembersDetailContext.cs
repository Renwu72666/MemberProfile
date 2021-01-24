using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberProfile.Models
{
    public class MembersDetailContext : DbContext
    {
        public MembersDetailContext(DbContextOptions<MembersDetailContext>options):base(options)
        {

        }

        public DbSet<Members> MembersDetails { get; set; }
    }
}
